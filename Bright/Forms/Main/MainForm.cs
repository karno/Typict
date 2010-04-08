using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using WeifenLuo.WinFormsUI.Docking;

namespace Bright.Forms.Main
{
    public partial class MainForm : Form
    {
        Docks.KeyView kv = new Bright.Forms.Main.Docks.KeyView();
        Docks.PictureView pv = new Bright.Forms.Main.Docks.PictureView();
        Docks.OperationView ov = new Bright.Forms.Main.Docks.OperationView();
        public MainForm()
        {
            InitializeComponent();
            pv.ImageLoadingChanged += new Action<bool>((b) =>
            {
                if (b)
                    statusLabel.Text = "画像をロードしています...";
                else
                    statusLabel.Text = "完了";
                this.imageLoading.Visible = b;
                mainStatus.Refresh();
                pv.Refresh();
            });
            this.Text = Define.AppName;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Core.Config.StateConfig.DockData != null)
            {
                MemoryStream ms = new MemoryStream(Core.Config.StateConfig.DockData);
                DeserializeDockContent deserializeDockContent
                    = new DeserializeDockContent(GetDockContentFromPersistString);
                this.mainDock.LoadFromXml(ms, deserializeDockContent);
            }
            else
            {
                kv.Show(this.mainDock);
                pv.Show(this.mainDock);
                ov.Show(this.mainDock);
            }
            kv.DockStateChanged += new EventHandler(kv_DockStateChanged);
            kv_DockStateChanged(null, null);
            ov.DockStateChanged += new EventHandler(ov_DockStateChanged);
            ov_DockStateChanged(null, null);
            pv.FileChanged += new Action<string>(pv_FileChanged);
            Core.Distributed += new Action<Keys>(Core_Distributed);
            //reflect state
            {
                SetCurrentMode(Core.Config.StateConfig.DistributionMode);
                menuKeepProp.Checked = Core.Config.StateConfig.KeepProportion;
                menuKeepProp_Click(null, null);
                menuPictureZoom.Checked = Core.Config.StateConfig.ZoomPicture;
                menuPictureZoom_Click(null, null);
                menuZoom.Checked = Core.Config.StateConfig.ZoomPicture;
                menuZoom_Click(null, null);
                this.Location = Core.Config.StateConfig.WindowPosition.Location;
                this.Size = Core.Config.StateConfig.WindowPosition.Size;
                this.WindowState = Core.Config.StateConfig.WindowState;
            }
            try
            {
                Subsystem.Prefetch.Instance.PrefetchingUpdate += new Action<bool>((b) => this.Invoke(new Action<bool>((v) => imagePrefetching.Visible = v), b));
            }
            catch { }
            Core.CurrentOperationUpdated += new Action(ItemLengthLabelUpdate);
            Core.CurrentOperationUpdated += new Action(UpdateControlItems);
            ItemLengthLabelUpdate();
            UpdateControlItems();
        }

        void pv_FileChanged(string obj)
        {
            if (String.IsNullOrEmpty(obj))
                this.Text = Define.AppName;
            else
                this.Text = obj + " - " + Define.AppName;
        }

        // ウィンドウの名称に対応するDockContentを返す
        IDockContent GetDockContentFromPersistString(string persistString)
        {
            switch (persistString)
            {
                case "keyview":  // GetPersistStringメソッドが返すウィンドウ名称
                    return this.kv;

                case "operationview":
                    return this.ov;

                case "pictureview":
                    return this.pv;
            }
            return null;
        }

        enum MultipleMode { None, FolderMulti, NumericMulti };
        MultipleMode multiMode = MultipleMode.None;

        void UpdateAdditionalString()
        {
            pv.AdditionalString = "";

            if (multiMode == MultipleMode.FolderMulti)
            {
                pv.AdditionalString += "<以降の同じフォルダーのファイルがすべて処理されます>";
                pv.AdditionalString += Environment.NewLine;
            }
            else if (multiMode == MultipleMode.NumericMulti)
            {
                pv.AdditionalString += "<" + setMultiValue.ToString() + "枚が一斉に処理されます>";
                pv.AdditionalString += Environment.NewLine;
            }
            if (multiCopy)
            {
                pv.AdditionalString += "[マルチコピー]";
                if (multiDests.Count > 0)
                {
                    var keyStrs = from ks in multiDests
                                  select ks.GetString();
                    pv.AdditionalString += String.Join(",", keyStrs.ToArray<string>());
                }
                pv.AdditionalString += Environment.NewLine;
            }
        }

        void kv_DockStateChanged(object sender, EventArgs e)
        {
            menuShowKFView.Checked = kv.DockState != DockState.Hidden;
        }

        void ov_DockStateChanged(object sender, EventArgs e)
        {
            menuShowOperationView.Checked = ov.DockState != DockState.Hidden;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (File.Exists(Define.AutoBackupFile) && MessageBox.Show(
                    "前回、正常に終了されなかった恐れがあります。" + Environment.NewLine +
                    "バックアップから再開しますか？", "自動バックアップの復元",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Core.CurrentOperation = Subsystem.OperationPackager.Load(Define.AutoBackupFile);
                Core.CurrentOperation.Data.ElementsUpdated += new Action(ItemLengthLabelUpdate);
                Core.CurrentOperation.IndexUpdated += new Action(ItemLengthLabelUpdate);
                Core.CurrentOperation.IndexUpdated += new Action(CheckFinished);
                Core.CurrentOperation.IndexUpdated += new Action(UpdateControlItems);
                ItemLengthLabelUpdate();
                UpdateControlItems();
                this.Enabled = true;
                this.statusLabel.Text = "完了";
                operationStarting.Visible = false;
                this.Refresh();
                Core.CurrentOperation.Reload();
                Application.DoEvents();
            }
            else
                Setup();
            if (Core.Config.IsFirstBoot)
            {
                //Preventing bug
                firstBootToolTip.Show("", mainStatus);
                firstBootToolTip.Show(@"ここをクリックするか、Ctrl+Dキー、または↑キーを押すことによって、振り分け方を変更することができます。
コピー:ファイルを元の場所からコピーします。
移動:ファイルを元の場所から移動します。
リンク:元の場所へのファイルリンクを作成します。", mainStatus, new Point(30, 10), 12000);
            }
        }

        void Setup()
        {
            do
            {
                using (var setup = new Setup.Setup())
                {
                    var ret = setup.ShowDialog();
                    if (ret == DialogResult.OK)
                    {
                        this.statusLabel.Text = "オペレーションを開始しています...";
                        operationStarting.Visible = true;
                        this.Refresh();
                        this.Enabled = false;
                        Application.DoEvents();
                        Core.IsOperationCreated = false;
                        var act = new Func<Data.Operation>(setup.GetOperationData);
                        act.BeginInvoke((iar) =>
                            {
                                this.Invoke(new Action(() =>
                                    {
                                        Core.CurrentOperation = ((Func<Data.Operation>)iar.AsyncState).EndInvoke(iar);
                                        Core.IsOperationCreated = true;
                                    }));
                            }
                            , act);
                        while (!Core.IsOperationCreated)
                        {
                            Application.DoEvents();
                            System.Threading.Thread.Sleep(0);
                        }
                        if (Core.CurrentOperation == null)
                        {
                            MessageBox.Show(
                                "振り分ける対象のファイルがありません。" + Environment.NewLine +
                                "設定し直してください。",
                                "スタートエラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            Core.CurrentOperation.Data.ElementsUpdated += new Action(ItemLengthLabelUpdate);
                            Core.CurrentOperation.IndexUpdated += new Action(ItemLengthLabelUpdate);
                            Core.CurrentOperation.IndexUpdated += new Action(CheckFinished);
                            Core.CurrentOperation.IndexUpdated += new Action(UpdateControlItems);
                            ItemLengthLabelUpdate();
                            UpdateControlItems();
                        }
                        this.Enabled = true;
                        this.statusLabel.Text = "完了";
                        operationStarting.Visible = false;
                        this.Refresh();
                        Application.DoEvents();
                    }
                    else if (ret == DialogResult.Retry)
                    {
                        var retry = setup.RetryOperationDataFile;
                        if (MessageBox.Show(retry + "からデータを読み込んで再開します。" + Environment.NewLine +
                            "よろしいですか？", "振り分けの再開", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Core.CurrentOperation = Subsystem.OperationPackager.Load(retry);
                        }
                        Core.CurrentOperation.Data.ElementsUpdated += new Action(ItemLengthLabelUpdate);
                        Core.CurrentOperation.IndexUpdated += new Action(ItemLengthLabelUpdate);
                        Core.CurrentOperation.IndexUpdated += new Action(CheckFinished);
                        Core.CurrentOperation.IndexUpdated += new Action(UpdateControlItems);
                        ItemLengthLabelUpdate();
                        UpdateControlItems();
                        this.Enabled = true;
                        this.statusLabel.Text = "完了";
                        operationStarting.Visible = false;
                        this.Refresh();
                        Core.CurrentOperation.Reload();
                        Application.DoEvents();
                    }
                    else
                    {
                        Application.Exit();
                        break;
                    }
                }
                Application.DoEvents();
            } while (Core.CurrentOperation == null);
        }

        void UpdateControlItems()
        {
            if (Core.CurrentOperation == null)
            {
                menuAction.Enabled = false;
                menuOpertation.Enabled = false;
                mainTool.Enabled = false;
            }
            else
            {
                menuAction.Enabled = true;
                menuOpertation.Enabled = true;
                mainTool.Enabled = true;
                menuBack.Enabled = Core.CurrentOperation.CanSetPrev();
                menuPrevious.Enabled = Core.CurrentOperation.RewindStackCount > 1;
                toolBack.Enabled = Core.CurrentOperation.RewindStackCount > 1;
            }
        }

        void ItemLengthLabelUpdate()
        {
            multiMode = MultipleMode.None;
            multiCopy = false;
            pv.AdditionalString = null;
            if (menuMultiCopy.Checked)
                menuMultiCopy.Checked = false;
            waitingKey = Keys.None;
            statusLabel.Text = "完了";
            if (Core.CurrentOperation == null)
            {
                itemLengthLabel.Text = "0 / 0";
            }
            else
            {
                itemLengthLabel.Text = (Core.CurrentOperation.Index + 1).ToString() + " / " + Core.CurrentOperation.Data.ElementsLength.ToString();
                if (Core.Config.BehaviorConfig.BackupInterval != 0 &&
                    Core.CurrentOperation.Index % Core.Config.BehaviorConfig.BackupInterval == 0)
                    Subsystem.OperationPackager.DoBackup();
            }
        }

        void Core_Distributed(Keys obj)
        {
            mainStatus.Text = "完了";
            if (obj == Keys.None)
            {
                prevDistributeView.Visible = false;
                return;
            }
            if (obj == Keys.Delete)
            {
                prevDistributeView.Text = "[除外されました]";
            }
            else if (obj == Keys.Space)
            {
                prevDistributeView.Text = "[スキップされました]";
            }
            else if (!Core.CurrentOperation.Data.IsDestinationExists(obj))
                return;
            else
            {
                string KeyFormat = "[" + obj.GetString() + "] -> " +
                    Core.CurrentOperation.Data.GetDestination(obj).DestPath;
                prevDistributeView.Text = KeyFormat;
            }
            prevDistributeView.Visible = true;
        }

        void CheckFinished()
        {
            if (Core.CurrentOperation.Index == Core.CurrentOperation.Data.ElementsLength)
            {
                if (MessageBox.Show(
                    "すべての操作が完了しました。" + Environment.NewLine +
                    "振り分けを開始します。", "操作の完了",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                {
                    Core.CurrentOperation.SetPrev();
                }
                else
                {
                    ExecGrouping();
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing || e.CloseReason == CloseReason.None)
            {
                if (MessageBox.Show(
                    Define.AppName + "を終了してもよろしいですか？" + Environment.NewLine +
                    "保存されていない内容は破棄されます。", Define.AppName + "の終了",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            //state reflection
            Core.Config.StateConfig.DistributionMode = Core.DistributionMode;
            Core.Config.StateConfig.KeepProportion = menuKeepProp.Checked;
            Core.Config.StateConfig.WindowPosition = K.Snippets.WinForms.GetNormalWindowLocation(this);
            Core.Config.StateConfig.WindowState = this.WindowState;
            Core.Config.StateConfig.ZoomPicture = menuPictureZoom.Checked;
            Core.Config.StateConfig.ZoomSmallPicture = menuZoom.Checked;

            MemoryStream ms = new MemoryStream();
            this.mainDock.SaveAsXml(ms, Encoding.Unicode, true);
            ms.Seek(0, SeekOrigin.Begin);
            byte[] buf = new byte[ms.Length];
            ms.Read(buf, 0, (int)ms.Length);
            Core.Config.StateConfig.DockData = buf;

            Core.Config.SaveConfig();
            Subsystem.OperationPackager.RemoveBackup();
        }

        private void menuNewOperation_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("現在のオペレーションを破棄してもよろしいですか？", "新しいオペレーションの作成",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;
            Setup();
        }

        private void menuAddFolder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "追加するフォルダーを選択してください";
                fbd.RootFolder = Environment.SpecialFolder.Desktop;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        List<string> extents = new List<string>();
                        foreach (var ext in Subsystem.ImageReader.Instance.GetSusieAcceptExt())
                        {
                            if (ext.Contains('.'))
                                extents.Add(ext.Split('.')[1].ToUpper());
                            else
                                extents.Add(ext.ToUpper());
                        }
                        foreach (var ext in Subsystem.ImageReader.Instance.GetSystemAcceptExt())
                        {
                            if (ext.Contains('.'))
                                extents.Add(ext.Split('.')[1].ToUpper());
                            else
                                extents.Add(ext.ToUpper());
                        }
                        List<string> files = new List<string>();
                        foreach (var f in Directory.GetFiles(fbd.SelectedPath, "*",
                            MessageBox.Show("下層フォルダーにあるファイルも追加しますか？", "ファイルの追加", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly))
                        {
                            var ext = Path.GetExtension(f);
                            if (String.IsNullOrEmpty(ext))
                                continue;
                            ext = ext.ToUpper().Substring(1);
                            if (extents.Contains(ext))
                                files.Add(f);
                        }
                        Core.CurrentOperation.Data.AddElements(files.ToArray());
                    }
                    catch (UnauthorizedAccessException uae)
                    {
                        MessageBox.Show(
                            "ディレクトリ " + fbd.SelectedPath + Environment.NewLine +
                            "へのアクセスが拒否されたため、振り分けリストに追加できませんでした。" + Environment.NewLine +
                            uae.ToString(),
                            "アクセスエラー", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
            }
        }

        private void menuSaveOperation_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Title = "オペレーションの保存";
                sfd.Filter = Define.AppName + "オペレーションデータ|*" + Define.OpDataFileExt;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Subsystem.OperationPackager.Save(Core.CurrentOperation, sfd.FileName);
                }
            }
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuBack_Click(object sender, EventArgs e)
        {
            if (Core.CurrentOperation != null && Core.CurrentOperation.CanSetPrev())
                Core.CurrentOperation.SetPrev();
        }

        private void menuSkip_Click(object sender, EventArgs e)
        {
            if (Core.CurrentOperation != null)
            {
                Core.InvokeDistrubited(Keys.Space);
                Core.CurrentOperation.SetNext();
            }
        }

        private void menuPrevious_Click(object sender, EventArgs e)
        {
            using (var mul = new Dialogs.MultiProcess(Core.CurrentOperation.RewindStackCount))
            {
                if (mul.ShowDialog() == DialogResult.OK)
                {
                    Core.CurrentOperation.SetRewind(mul.GetValue());
                }
            }

        }

        private void menuRemove_Click(object sender, EventArgs e)
        {
            if (Core.CurrentOperation != null)
            {
                Core.CurrentOperation.GetCurrentElement().SetSingleDirectDest(Define.RemoveIDString);
                Core.InvokeDistrubited(Keys.Delete);
                Core.CurrentOperation.SetNext();
            }
        }

        private void menuMultiCopy_Click(object sender, EventArgs e)
        {
            multiCopy = menuMultiCopy.Checked;
            if (menuMultiCopy.Checked)
            {
                multiDests.Clear();
            }
            else
            {
                if (multiDests.Count > 0 && MessageBox.Show(
                    "マルチコピーの移動先が設定されています。" + Environment.NewLine +
                    "設定を反映しますか？" + Environment.NewLine +
                    "いいえを押すとマルチコピーがキャンセルされます。", "マルチコピーのコミット", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    AcceptMultiCopy();
                }
                else
                {
                    pv.AdditionalString = null;
                }
            }
            UpdateAdditionalString();
        }

        private void menuRename_Click(object sender, EventArgs e)
        {
            using(var rn = new Dialogs.Rename(Core.CurrentOperation.GetCurrentElement()))
            {
                if (rn.ShowDialog() == DialogResult.OK)
                    Core.CurrentOperation.GetCurrentElement().NewName = rn.GetNewName();
                else
                    Core.CurrentOperation.GetCurrentElement().NewName = null;
                ov.Refresh();
                pv.Refresh();
            }
        }

        private void menuSetFolder_Click(object sender, EventArgs e)
        {
            if (multiMode == MultipleMode.FolderMulti)
            {
                multiMode = MultipleMode.None;
                menuSetFolder.Checked = false;
                UpdateAdditionalString();
            }
            else
            {
                multiMode = MultipleMode.FolderMulti;
                menuSetMulti.Checked = false;
                menuSetFolder.Checked = true;
                UpdateAdditionalString();
            }
        }

        int setMultiValue = 0;
        private void menuSetMulti_Click(object sender, EventArgs e)
        {
            if (multiMode == MultipleMode.NumericMulti)
            {
                multiMode = MultipleMode.None;
                menuSetMulti.Checked = false;
                UpdateAdditionalString();
            }
            else
            {
                using (var mul = new Dialogs.MultiProcess(Core.CurrentOperation.Data.ElementsLength - Core.CurrentOperation.Index))
                {
                    if (mul.ShowDialog() == DialogResult.OK)
                    {
                        multiMode = MultipleMode.NumericMulti;
                        setMultiValue = mul.GetValue();
                        menuSetMulti.Checked = true;
                        menuSetFolder.Checked = false;
                        UpdateAdditionalString();
                    }
                }
            }
        }

        private void menuExec_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "予約はまだ完了していません。" + Environment.NewLine +
                "振り分けを実行してもよろしいですか？", "途中実行の確認",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                ExecGrouping();
        }

        private void ExecGrouping()
        {
            using (var exec = new Grouping.GroupingExec(Core.CurrentOperation.Data.GetElementsArray()))
            {
                exec.ShowDialog();
            }
            Setup();
        }

        private void menuInit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("前のファイルへ戻る動作を最初に戻るまで行います。" + Environment.NewLine +
                "よろしいですか？", "最初からやり直す", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Core.CurrentOperation.SetRewind(Core.CurrentOperation.RewindStackCount);
        }

        private void menuShowKFView_Click(object sender, EventArgs e)
        {
            if (menuShowKFView.Checked)
                kv.Activate();
            else
                kv.Hide();
        }

        private void menuShowOperationView_Click(object sender, EventArgs e)
        {
            if (menuShowOperationView.Checked)
                ov.Activate();
            else
                ov.Hide();
        }

        private void menuPictureZoom_Click(object sender, EventArgs e)
        {
            menuZoomConfig.Enabled = menuPictureZoom.Checked;
            Core.Config.StateConfig.ZoomPicture = menuPictureZoom.Checked;
            pv.ZoomPicture = menuPictureZoom.Checked;
        }

        private void menuZoom_Click(object sender, EventArgs e)
        {
            Core.Config.StateConfig.ZoomSmallPicture = menuZoom.Checked;
            pv.ZoomSmallPicture = menuZoom.Checked;
        }

        private void menuKeepProp_Click(object sender, EventArgs e)
        {
            Core.Config.StateConfig.KeepProportion = menuKeepProp.Checked;
            pv.KeepProportion = menuKeepProp.Checked;
        }

        private void menuConfig_Click(object sender, EventArgs e)
        {
            using (var cfg = new Config.Config())
            {
                if (cfg.ShowDialog() == DialogResult.OK)
                    this.Refresh();
            }

        }

        private void menuVersion_Click(object sender, EventArgs e)
        {
            using (var vf = new Dialogs.Version())
            {
                vf.ShowDialog();
            }
        }

        private void cutcopyButton_MouseDown(object sender, MouseEventArgs e)
        {
            switchCutCopyButton.BorderStyle = Border3DStyle.SunkenOuter;
        }

        private void cutcopyButton_MouseUp(object sender, MouseEventArgs e)
        {
            switchCutCopyButton.BorderStyle = Border3DStyle.Etched;
        }

        private void cutcopyButton_Click(object sender, EventArgs e)
        {
            if (Core.DistributionMode == Bright.Data.GroupingElement.DistributionModes.Copy)
                SetCurrentMode(Bright.Data.GroupingElement.DistributionModes.Move);
            else if (Core.DistributionMode == Bright.Data.GroupingElement.DistributionModes.Move)
                SetCurrentMode(Bright.Data.GroupingElement.DistributionModes.Link);
            else
                SetCurrentMode(Bright.Data.GroupingElement.DistributionModes.Copy);
        }

        private void SetCurrentMode(Data.GroupingElement.DistributionModes mode)
        {
            switch (mode)
            {
                case Bright.Data.GroupingElement.DistributionModes.Copy:
                    switchCutCopyButton.Text = "コピー";
                    switchCutCopyButton.Image = Properties.Resources.copy;
                    Core.DistributionMode = Bright.Data.GroupingElement.DistributionModes.Copy;
                    break;
                case Bright.Data.GroupingElement.DistributionModes.Move:
                    switchCutCopyButton.Text = "移動";
                    switchCutCopyButton.Image = Properties.Resources.cut;
                    Core.DistributionMode = Bright.Data.GroupingElement.DistributionModes.Move;
                    break;
                case Bright.Data.GroupingElement.DistributionModes.Link:
                    switchCutCopyButton.Text = "リンク";
                    switchCutCopyButton.Image = Properties.Resources.link;
                    Core.DistributionMode = Bright.Data.GroupingElement.DistributionModes.Link;
                    break;
                default:
                    throw new ArgumentException("Invalid enum argument: value " + ((int)mode).ToString());
            }
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                case Keys.Tab:
                case Keys.Enter:
                case Keys.Escape:
                    e.IsInputKey = true;
                    break;
            }
            base.OnPreviewKeyDown(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (Core.CurrentOperation != null)
            {
                if (e.Control)
                    OnKeyDown_Control(ref e);
                else
                    OnKeyDown_NoPrefix(ref e);
                if (!e.Handled)
                    OnKeyDown_PictureGrouping(ref e);
            }
            base.OnKeyDown(e);
        }

        bool multiCopy = false;
        Keys waitingKey = Keys.None;
        List<Keys> multiDests = new List<Keys>();
        private void OnKeyDown_PictureGrouping(ref KeyEventArgs e)
        {
            if ((e.Modifiers & ~Keys.Shift) != 0) return;
            if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) ||
                (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9))
            {
                if (Core.CurrentOperation.Data.IsDestinationExists(e.KeyData))
                {
                    this.DoGrouping(e.KeyData);
                }
                else
                {
                    if (waitingKey == e.KeyData)
                    {
                        statusLabel.Text = "キー " + e.KeyData.GetString() + " へ登録します...";
                        using (var fbd = new FolderBrowserDialog())
                        {
                            fbd.Description = "キー " + e.KeyData.GetString() + " へ登録するフォルダーの選択";
                            fbd.RootFolder = Environment.SpecialFolder.Desktop;
                            if (fbd.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    Core.CurrentOperation.Data.AddDestination(e.KeyData,
                                        new Bright.Data.Destination(e.KeyData, fbd.SelectedPath));
                                    DoGrouping(e.KeyData);
                                }
                                catch (UnauthorizedAccessException uae)
                                {
                                    MessageBox.Show(
                                        "ディレクトリ " + fbd.SelectedPath + Environment.NewLine +
                                        "へアクセスできません。" + Environment.NewLine +
                                        uae.ToString(),
                                        "アクセスエラー", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    DialogResult = DialogResult.Cancel;
                                }
                            }
                        }
                        statusLabel.Text = "完了";
                        waitingKey = Keys.None;
                    }
                    else
                    {
                        waitingKey = e.KeyData;
                        statusLabel.Text = "キー " + e.KeyData.GetString() + " は登録されていません。もう一度押すとフォルダー選択して登録します...";
                    }
                }
            }
        }

        private void DoGrouping(Keys k)
        {
            if (multiCopy)
            {
                if (multiDests.Contains(k))
                    multiDests.Remove(k);
                else
                    multiDests.Add(k);
                UpdateAdditionalString();
                return;
            }
            else
            {
                ParseMulti(k);
            }
        }

        private void ParseMulti(Keys k)
        {
            if (multiMode == MultipleMode.FolderMulti)
            {
                int i = 0;
                Data.GroupingElement elem = Core.CurrentOperation.GetCurrentElement();
                string dir = Path.GetDirectoryName(elem.ImageSourcePath);
                while (Path.GetDirectoryName(elem.ImageSourcePath) == dir)
                {
                    SetElemDestination(elem, k);
                    i++;
                    if (Core.CurrentOperation.Index + i >= Core.CurrentOperation.Data.ElementsLength)
                        break;
                    elem = Core.CurrentOperation.Data.GetElement(Core.CurrentOperation.Index + i);
                }
            }
            else if (multiMode == MultipleMode.NumericMulti)
            {
                for (int i = 0; i < setMultiValue; i++)
                {
                    SetElemDestination(Core.CurrentOperation.Data.GetElement(Core.CurrentOperation.Index + i), k);
                }
            }
            else
            {
                SetElemDestination(Core.CurrentOperation.GetCurrentElement(), k);
            }
            Core.CurrentOperation.SetNext();
        }

        private void SetElemDestination(Data.GroupingElement elem, Keys k)
        {
            elem.Destinations.Clear();
            if (Accepting)
            {
                foreach (var ki in multiDests)
                {
                    if (!Core.CurrentOperation.Data.IsDestinationExists(ki))
                        MessageBox.Show("キー " + k.GetString() + " に関連づけられたフォルダーはありません。" + Environment.NewLine +
                            "このキーへの振り分けは無視されます。", "マルチコピーの設定エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        elem.Destinations.Add(new Data.GroupingElement.DestData(Core.CurrentOperation.Data.GetDestination(ki)));
                }
            }
            else
            {
                elem.Destinations.Add(new Data.GroupingElement.DestData(Core.CurrentOperation.Data.GetDestination(k)));
            }
            elem.DistributionMode = Core.DistributionMode;
        }

        bool Accepting = false;
        private void AcceptMultiCopy()
        {
            Accepting = true;
            ParseMulti(Keys.None);
            Accepting = false;
        }

        private void OnKeyDown_Control(ref KeyEventArgs e)
        {
            e.Handled = true;
            switch (e.KeyCode)
            {
                case Keys.D:
                    cutcopyButton_Click(null, null);
                    break;
                case Keys.F:
                    menuSetFolder_Click(null, null);
                    break;
                case Keys.M:
                    menuSetMulti_Click(null, null);
                    break;
                case Keys.N:
                    menuNewOperation_Click(null, null);
                    break;
                case Keys.O:
                    menuAddFolder_Click(null, null);
                    break;
                case Keys.R:
                    menuRename_Click(null, null);
                    break;
                case Keys.S:
                    menuSaveOperation_Click(null, null);
                    break;
                case Keys.ShiftKey:
                    menuMultiCopy.Checked = !menuMultiCopy.Checked;
                    menuMultiCopy_Click(null, null);
                    break;
                default:
                    e.Handled = false;
                    break;
            }
        }

        private void OnKeyDown_NoPrefix(ref KeyEventArgs e)
        {
            e.Handled = true;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    cutcopyButton_Click(null, null);
                    break;
                case Keys.Escape:
                    menuInit_Click(null, null);
                    break;
                case Keys.Enter:
                    if (multiCopy)
                    {
                        AcceptMultiCopy();
                    }
                    else
                    {
                        menuExec_Click(null, null);
                    }
                    break;
                case Keys.Tab:
                    break;
                case Keys.Space:
                case Keys.Right:
                    menuSkip_Click(null, null);
                    break;
                case Keys.Back:
                case Keys.Left:
                    menuBack_Click(null, null);
                    break;
                case Keys.Delete:
                case Keys.Down:
                    menuRemove_Click(null, null);
                    break;
                case Keys.F2:
                    menuShowKFView.Checked = !menuShowKFView.Checked;
                    menuShowKFView_Click(null, null);
                    break;
                case Keys.F3:
                    menuShowOperationView.Checked = !menuShowOperationView.Checked;
                    menuShowOperationView_Click(null, null);
                    break;
                case Keys.F10:
                    menuPictureZoom.Checked = !menuPictureZoom.Checked;
                    menuPictureZoom_Click(null, null);
                    break;
                case Keys.F12:
                    menuConfig_Click(null, null);
                    break;
                default:
                    e.Handled = false;
                    break;
            }
        }
    }
}
