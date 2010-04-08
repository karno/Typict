using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Bright.Forms.Dialogs
{
    public partial class KeySetup : Form
    {
        string[] targets;
        int curIdx;
        Keys prevKey;
        Dictionary<Keys, string> mapping;


        public Dictionary<Keys, string> MappingTable
        {
            get { return mapping; }
        }

        public void SetMapping(Keys[] kmap)
        {
            foreach (var k in kmap)
            {
                if (!mapping.ContainsKey(k))
                    mapping.Add(k, String.Empty);
            }
        }

        public KeySetup(string targetDir)
        {
            InitializeComponent();
            DialogResult = DialogResult.OK;
            List<string> tgcds = new List<string>();
            try
            {
                tgcds.AddRange(K.Snippets.Files.GetAllDirectories(targetDir));
            }
            catch (UnauthorizedAccessException uae)
            {
                MessageBox.Show(
                    "ディレクトリ " + targetDir + "へアクセスできません。",
                    "アクセスエラー", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                DialogResult = DialogResult.Cancel;
                throw uae;
            }
            targets = tgcds.ToArray();
            curIdx = 0;
            prevKey = Keys.None;
            mapping = new Dictionary<Keys, string>();
        }

        private void SetLabel(string label, bool warning)
        {
            if (String.IsNullOrEmpty(label))
            {
                label4.Text = "に割り当てました";
                warning = false;
            }
            else
            {
                label4.Text = label;
            }
            if (warning)
            {
                label4.ForeColor = Color.Red;
            }
            else
            {
                label4.ForeColor = Color.Black;
            }
        }

        private void KeySetup_Load(object sender, EventArgs e)
        {
            UpdateView();
        }

        private void UpdateView()
        {
            pathText.Text = targets[curIdx];
            if (prevKey != Keys.None)
                keyText.Text = new EnumConverter(typeof(Keys)).ConvertToString(prevKey);
            else
                keyText.Text = String.Empty;
            prevBtn.Enabled = curIdx > 0;
            nextBtn.Enabled = curIdx - 1 < targets.Length;
        }

        Keys buffering = Keys.None;
        private void KeySetup_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keys.D0 <= e.KeyCode && e.KeyCode <= Keys.D9) ||
                (Keys.A <= e.KeyCode && e.KeyCode <= Keys.Z))
            {
                var k = e.Shift ? e.KeyCode | Keys.Shift : e.KeyCode;
                if (mapping.ContainsKey(k) && buffering != k)
                {
                    keyText.Text = new EnumConverter(typeof(Keys)).ConvertToString(k);
                    SetLabel("すでに割り当てられています。もう一度押すと確定します", true);
                    buffering = k;
                }
                else
                {
                    if (mapping.ContainsKey(k))
                        mapping[k] = targets[curIdx];
                    else
                        mapping.Add(k, targets[curIdx]);
                    buffering = Keys.None;
                    prevKey = k;
                    GoNext();

                }
            }
            else
            {
                if (e.KeyData == Keys.Back && prevBtn.Enabled)
                    prevBtn_Click(sender, e);
                else if (e.KeyData == Keys.Space && nextBtn.Enabled)
                    nextBtn_Click(sender, e);
                else if (e.KeyData == Keys.Enter)
                    okBtn_Click(sender, e);
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            prevKey = Keys.None;
            GoNext();
        }

        private void GoNext()
        {
            curIdx++;
            if (curIdx >= targets.Length)
            {
                okBtn_Click(null, null);
            }
            else
            {
                SetLabel(null, false);
                UpdateView();
            }
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (curIdx == 0)
                throw new InvalidOperationException();
            curIdx--;
            foreach (var s in mapping.Keys)
            {
                if (mapping[s] == targets[curIdx])
                {
                    mapping.Remove(s);
                    break;
                }
            }
            prevKey = Keys.None;
            UpdateView();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
