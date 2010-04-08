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
    public partial class UnhandledExcp : Form
    {
        public UnhandledExcp(Exception excp)
        {
            InitializeComponent();
            detailText.Text = excp.ToString();
            if (excp.GetBaseException() != null)
                detailText.AppendText(Environment.NewLine + "--- BASE ---" + Environment.NewLine + excp.GetBaseException().ToString());
        }

        private void UnhandledExcp_Load(object sender, EventArgs e)
        {
            this.Name = "エラー - " + Define.AppName;
        }

        private void saveText_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "bugreport.txt");
                sfd.Filter = "テキストファイル|*.txt|すべての形式|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        sw.Write(detailText.Text);
                    }
                }
            }
            MessageBox.Show("保存しました。", "バグ情報の保存", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void reportLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(
                "1.バグ情報を右上のフロッピーのアイコンをクリックして保存します。" + Environment.NewLine +
                "2.バグ情報をメールに添付し、以下のアドレスへ送信してください。" + Environment.NewLine +
                " " + Define.BugReportFor + Environment.NewLine +
                "(このとき、再現する手順やバグが発生する特定の画像を一緒に送信していただけると助かります。",
                "バグ報告の手順", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var ret = MessageBox.Show(
                "mailto:" + Define.BugReportFor + "を開きますか？" + Environment.NewLine +
                "(はいで開き、いいえでwebmaster@starwing.netをクリップボードへコピー、キャンセルで何もしません。",
                "バグ報告先を開く", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                try
                {
                    System.Diagnostics.Process.Start("mailto:" + Define.BugReportFor);
                }
                catch { }
            }
            else if (ret == DialogResult.No)
            {
                Clipboard.SetText(Define.BugReportFor);
                MessageBox.Show("コピーしました。", "バグ報告先のコピー", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ignoreButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
