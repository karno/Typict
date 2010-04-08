using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Bright.Forms.Setup
{
    public partial class Setup : Form
    {
        public Data.Operation GetOperationData()
        {
            Core.Config.StateConfig.PrevSetupData = GetSetupData();
            var op = new Data.Operation();
            var dirs = targetList.Items.Cast<string>();
            List<string> extents = new List<string>();
            foreach(var ext in Subsystem.ImageReader.Instance.GetSusieAcceptExt())
            {
                if (ext.Contains('.'))
                    extents.Add(ext.Split('.')[1].ToUpper());
                else
                    extents.Add(ext.ToUpper());
            }
            foreach(var ext in Subsystem.ImageReader.Instance.GetSystemAcceptExt())
            {
                if (ext.Contains('.'))
                    extents.Add(ext.Split('.')[1].ToUpper());
                else
                    extents.Add(ext.ToUpper());
            }
            for(int i = 0; i < targetList.Items.Count; i++)
            {
                var dir = targetList.Items[i] as string;
                try
                {
                    foreach(var f in targetList.CheckedIndices.Contains(i)?
                        K.Snippets.Files.GetAllFiles(dir):
                        Directory.GetFiles(dir))
                    {
                        var ext = Path.GetExtension(f);
                        if (String.IsNullOrEmpty(ext))
                            continue;
                        ext = ext.ToUpper().Substring(1);
                        if (extents.Contains(ext))
                            op.Data.AddElement(f);
                    }
                }
                catch (UnauthorizedAccessException uae)
                {
                    MessageBox.Show(
                        "ディレクトリ " + dir + "へのアクセスが拒否されたため、振り分けリストに追加できませんでした。" + Environment.NewLine +
                        uae.Message,
                        "アクセスエラー", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            List<Keys> empties = new List<Keys>();
            foreach (var k in destinations.Keys)
            {
                if (String.IsNullOrEmpty(destinations[k]))
                {
                    empties.Add(k);
                }
            }
            foreach (var k in empties)
            {
                destinations.Remove(k);
            }
            if (op.Data.ElementsLength == 0)
                return null;
            op.Data.SetDestinations(destinations, false);
            return op;
        }

        public string RetryOperationDataFile { get; set; }

        public Setup()
        {
            InitializeComponent();
        }

        private void Setup_Load(object sender, EventArgs e)
        {
            this.Text = Define.AppName + "のスタート";
            if (Core.Config.BehaviorConfig.RememberPreviousOperationConfig &&
                !String.IsNullOrEmpty(Core.Config.StateConfig.PrevSetupData))
            {
                destinations.Clear();
                this.LoadSetupData(Core.Config.StateConfig.PrevSetupData);
                if (targetList.Items.Count != 0)
                    okBtn.Enabled = true;
            }
            keyList.SelectedIndex = 0;
        }

        private void addFolder_Click(object sender, EventArgs e)
        {
            using (var folder = new FolderBrowserDialog())
            {
                folder.Description = "追加するフォルダーを選択してください。";
                folder.RootFolder = Environment.SpecialFolder.Desktop;
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    if (targetList.Items.Contains(folder.SelectedPath))
                        MessageBox.Show("すでに含まれています。", "フォルダーの追加エラー",
                            MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    else
                    {
                        targetList.Items.Add(folder.SelectedPath, true);
                        okBtn.Enabled = true;
                    }
                }
            }
        }

        private void deleteFolder_Click(object sender, EventArgs e)
        {
            if (targetList.SelectedIndex >= 0)
            {
                targetList.Items.RemoveAt(targetList.SelectedIndex);
                if (targetList.Items.Count == 0)
                    okBtn.Enabled = false;
            }
        }

        #region DragDropSupport
        private void targetList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                foreach (var d in e.Data.GetData(DataFormats.FileDrop) as string[])
                {
                    if (!Directory.Exists(d))
                        return;
                }
            }
            e.Effect = DragDropEffects.Copy;
        }

        private void targetList_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                foreach (var d in e.Data.GetData(DataFormats.FileDrop) as string[])
                {
                    if (Directory.Exists(d))
                    {
                        targetList.Items.Add(d, true);
                        okBtn.Enabled = true;
                    }
                }
            }
        }
        #endregion

        private void targetList_KeyDown(object sender, KeyEventArgs e)
        {
            deleteFolder_Click(sender, e);
        }


        Dictionary<Keys, string> destinations = new Dictionary<Keys, string>();
        private Keys GetCurrentKey()
        {
            Keys k = Keys.None;
            var kc = new KeysConverter();
            k = (Keys)kc.ConvertFromString(keyList.Items[keyList.SelectedIndex] as string);
            return shiftPrefix.Checked ? k | Keys.Shift : k;
        }

        private void keyListTargetUpdated(object sender, EventArgs e)
        {
            var k = GetCurrentKey();
            if (destinations.ContainsKey(k))
                pathText.Text = destinations[k];
            else
            {
                destinations.Add(k, String.Empty);
                pathText.Text = String.Empty;
            }
        }

        private void pathText_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(pathText.Text) || Directory.Exists(pathText.Text) || pathText.Text == String.Empty)
            {
                pathText.BackColor = Color.White;
                pathText.ForeColor = Color.Black;
                destinations[GetCurrentKey()] = pathText.Text;
                notFoundFolderAlert.Visible = false;
            }
            else
            {
                pathText.BackColor = Color.Red;
                pathText.ForeColor = Color.White;
                notFoundFolderAlert.Visible = true;
            }
        }

        private void browseFolder_Click(object sender, EventArgs e)
        {
            using (var folder = new FolderBrowserDialog())
            {
                folder.Description = "このキーに設定するフォルダーを選択してください。";
                folder.RootFolder = Environment.SpecialFolder.Desktop;
                if (folder.ShowDialog() == DialogResult.OK)
                    pathText.Text = folder.SelectedPath;
            }
        }

        private void browseFile_Click(object sender, EventArgs e)
        {
            using (var file = new OpenFileDialog())
            {
                file.CheckFileExists = true;
                file.CheckPathExists = true;
                file.DereferenceLinks = true;
                file.Filter = "アプリケーション|*.exe|すべてのファイル|*.*";
                file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                file.RestoreDirectory = true;
                file.Title = "パスを渡すアプリケーション ファイルの選択";
                if (file.ShowDialog() == DialogResult.OK)
                    pathText.Text = file.FileName;
            }
        }
        
        private void allClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("キー設定をすべてクリアします。", "設定のクリア", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                pathText.Text = String.Empty;
                destinations.Clear();
                keyListTargetUpdated(sender, e);
            }
        }

        private void exMenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            saveloadContext.Show(exMenuLinkLabel, new Point(exMenuLinkLabel.Width, exMenuLinkLabel.Height), ToolStripDropDownDirection.BelowLeft);
        }

        private void cfgBtn_Click(object sender, EventArgs e)
        {
            using (var cfg = new Config.Config())
            {
                cfg.ShowDialog();
            }
        }

        private void keyFromFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "設定するルートフォルダーを選択してください。";
                fbd.RootFolder = Environment.SpecialFolder.Desktop;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var map = new Dialogs.KeySetup(fbd.SelectedPath))
                        {
                            if (map.ShowDialog() == DialogResult.OK)
                            {
                                pathText.Text = String.Empty;
                                destinations.Clear();
                                destinations = map.MappingTable;
                                keyListTargetUpdated(sender, e);
                            }
                        }
                    }
                    catch (UnauthorizedAccessException) { }
                }
            }
        }

        private void saveSetup_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                sfd.Title = "設定の保存先を指定";
                sfd.DefaultExt = ".tsd";
                sfd.FileName = "distribute";
                sfd.Filter = "Typict Setup Data|*.tsd";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var sw = new StreamWriter(sfd.FileName))
                    {
                        sw.WriteLine(GetSetupData());
                    }
                }
            }
        }

        public string GetSetupData()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < targetList.Items.Count; i++)
            {
                sb.AppendLine(
                    targetList.CheckedIndices.Contains(i) ?
                    "+" + targetList.Items[i] as string :
                    "-" + targetList.Items[i] as string
                    );
            }
            sb.AppendLine("*");
            foreach (var k in destinations.Keys)
            {
                if (String.IsNullOrEmpty(destinations[k]))
                    continue;
                sb.AppendLine(k.ToString() + "\t" + destinations[k]);
            }
            return sb.ToString();
        }

        private void loadSetup_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                ofd.Title = "設定の読み込み";
                ofd.DefaultExt = ".tsd";
                ofd.Filter = "Typict Setup Data(*.tsd)|*.tsd";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    destinations.Clear();
                    targetList.Items.Clear();
                    using (var sr = new StreamReader(ofd.FileName))
                        LoadSetupData(sr.ReadToEnd());
                    if (targetList.Items.Count != 0)
                        okBtn.Enabled = true;
                    keyListTargetUpdated(sender, e);
                }
            }
        }

        public void LoadSetupData(string data)
        {
            bool foundAsterisk = false;
            var kc = new KeysConverter();
            System.Diagnostics.Debug.WriteLine(data);
            foreach (var str in data.Split(new[] { "\n","\r", Environment.NewLine }, StringSplitOptions.None))
            {
                var cs = str.Replace("\r", "").Replace("\n", "");
                if (String.IsNullOrEmpty(cs))
                    continue;
                if (cs == "*")
                {
                    foundAsterisk = true;
                    continue;
                }
                if (!foundAsterisk)
                {
                    if (cs.StartsWith("+"))
                        targetList.Items.Add(cs.Substring(1), true);
                    else
                        targetList.Items.Add(cs.Substring(1), false);
                }
                else
                {
                    var sp = cs.Split('\t');
                    if (sp.Length != 2)
                        continue;
                    var keyk = (Keys)kc.ConvertFromString(sp[0]);
                    if (destinations.ContainsKey(keyk))
                        MessageBox.Show(
                            "データのフォーマットにエラーがあります。" + Environment.NewLine +
                            "エラーのある箇所をスキップしてロードします。" + Environment.NewLine +
                            "(詳細:キー " + keyk.GetString() + " にデータが多重登録されています。" + Environment.NewLine +
                            "後から登録される情報は破棄されます。)",
                            "ロードエラー", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    else
                        destinations.Add(keyk, sp[1]);
                }
            }
        }

        private void pathText_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                foreach (var d in e.Data.GetData(DataFormats.FileDrop) as string[])
                {
                    if (!Directory.Exists(d))
                        return;
                }
            }
            e.Effect = DragDropEffects.Copy;
        }

        private void pathText_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var dirs = e.Data.GetData(DataFormats.FileDrop) as string[];
                if (dirs != null && dirs.Length > 0)
                {
                    if (Directory.Exists(dirs[0]))
                        pathText.Text = dirs[0];
                    else
                        MessageBox.Show("ディレクトリ" + dirs[0] + "は存在しないか、ディレクトリではありません。",
                            "設定エラー", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Define.AppName + "を終了してもよろしいですか？", Define.AppName + "の終了",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void retryGrouping_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = Define.AppName + " オペレーションデータ|*" + Define.OpDataFileExt;
                ofd.Title = "オペレーションの再開";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    RetryOperationDataFile = ofd.FileName;
                    DialogResult = DialogResult.Retry;
                    this.Close();
                }
            }
        }

    }
}
