using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace K.Snippets
{
    static partial class Files
    {
        private static bool ignoreError = false;
        private static bool isRoot = false;
        public static IEnumerable<string> GetAllDirectories(string root)
        {
            bool isThisRoot = false;
            if (!isRoot)
            {
                isRoot = true;
                ignoreError = false;
                isThisRoot = true;
            }
            if (String.IsNullOrEmpty(root))
                throw new ArgumentNullException("root");
            if (!Directory.Exists(root))
                throw new ArgumentException("そのディレクトリは存在しません。", "root");
            string[] sub = null;
            try
            {
                sub = Directory.GetDirectories(root);
            }
            catch (UnauthorizedAccessException e)
            {
                if (!ignoreError)
                {
                    switch (MessageBox.Show(
                        "ディレクトリ " + root + "へのアクセス権限がありません。" + Environment.NewLine +
                        "このディレクトリは読み書きできません。" + Environment.NewLine +
                        "再試行でこのディレクトリ以降の列挙を引き続き行い、" + Environment.NewLine +
                        "無視でこの種類のエラーをすべて無視、中止を押すと列挙を中止します。", "ディレクトリ情報の取得エラー",
                        MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Hand))
                    {
                        case DialogResult.Abort:
                            ignoreError = false;
                            isRoot = false;
                            throw e;
                        case DialogResult.Ignore:
                            ignoreError = true;
                            break;
                    }
                }
                yield break;
            }
            yield return root;
            foreach (var s in sub)
            {
                foreach (var d in GetAllDirectories(s))
                    yield return d;
            }
            if (isThisRoot)
                isRoot = false;
            yield break;
        }

        public static IEnumerable<string> GetAllFiles(string rootFolder)
        {
            foreach (var d in GetAllDirectories(rootFolder))
            {
                string[] files = Directory.GetFiles(d);
                foreach (var f in files)
                    yield return f;
            }
        }
    }
}
