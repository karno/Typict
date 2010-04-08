using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bright.Data
{
    public class Destination
    {
        public Destination(Keys key, string dest)
        {
            this.LinkedKey = key;
            this.DestPath = dest;
        }

        public Keys LinkedKey { get; private set; }
        public string DestPath { get; private set; }
        Action<string> destPathUpdated;

        public void SetDestPath(string path, bool overwrite)
        {
            this.DestPath = path;
            if (overwrite)
            {
                if (destPathUpdated != null)
                    destPathUpdated.Invoke(path);
            }
            else
            {
                destPathUpdated = null;
            }
        }

        public void SetDestPathWithOverwriteConfirm(string path)
        {
            string keyStr = new KeysConverter().ConvertToString((this.LinkedKey & ~Keys.Shift));
            if ((this.LinkedKey & Keys.Shift) == Keys.Shift)
                keyStr = "Shift + " + keyStr;
            var dr = MessageBox.Show(
                "キー " + LinkedKey.ToString() + "にはすでに設定されているパスがあります。" + Environment.NewLine +
                "すでにこのキーへ振り分けた画像の振り分け先も変更しますか？" + Environment.NewLine +
                "(キャンセルを押すと上書きをしません)",
                "キー設定の上書き",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.Cancel)
                return;
            else
                this.SetDestPath(path, dr == DialogResult.Yes);
        }

        public void SetElementDestination(GroupingElement.DestData dd)
        {
            dd.Destination = this.DestPath;
            this.destPathUpdated += new Action<string>((s) => dd.Destination = s);
            Core.InvokeDistrubited(LinkedKey);
        }
    }
}
