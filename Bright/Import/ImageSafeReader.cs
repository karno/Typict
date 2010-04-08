using System;
using System.Drawing;
using System.IO;

namespace K.Snippets
{
    static partial class Images
    {
        /// <summary>
        /// 画像ファイルをロックせずに読み込みます。
        /// </summary>
        /// <param name="path">画像ファイルのパス</param>
        /// <param name="raiseFileNotFoundException">ファイルが存在しないときにFileNotFoundExceptionを発生させるか(falseの時はnullを返します)</param>
        public static Image ImageSafeReader(string path, bool raiseFileNotFoundException)
        {
            //Image.FromFileを使って読み込むと、アプリケーション終了時まで画像ファイルがロックされます。
            //簡易的に利用する場合を除き、ロックされると非常に困るので、FileStreamを使ってロックされないように読みます。
            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    var ms = new MemoryStream();
                    ms.SetLength(fs.Length);
                    fs.Read(ms.GetBuffer(), 0, (int)fs.Length);
                    ms.Flush();
                    return Image.FromStream(ms);
                }
            }
            else
            {
                if (raiseFileNotFoundException)
                    throw new FileNotFoundException("画像ファイル " + path + " は存在しません。");
                else
                    return null;
            }
        }
    }
}