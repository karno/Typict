using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Bright
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            System.AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.Run(new Forms.Main.MainForm());
        }

        #region 未捕捉例外の処理

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //致命的なほう
            MessageBox.Show(
                "致命的なエラーが発生しました。" + Environment.NewLine +
                "デスクトップの " + Define.FatalBugReportFile + " に詳細を保存して終了します。",
                "致命的なエラー", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            using (var sw = new StreamWriter(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Define.FatalBugReportFile)))
            {
                sw.WriteLine(e.ExceptionObject.ToString());
            }
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            //そうでもないほう
            using (var excp = new Forms.Dialogs.UnhandledExcp(e.Exception))
            {
                var ret = excp.ShowDialog();
            }
        }

        #endregion
    }
}
