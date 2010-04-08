using System;
using System.Xml.Serialization;
using System.IO;

namespace K.Snippets
{
    static partial class Files
    {
        /// <summary>
        /// XMLファイルへオブジェクトをシリアライズします。
        /// </summary>
        /// <typeparam name="Type">シリアライズする型</typeparam>
        /// <param name="fpath">保存先のファイルパス</param>
        /// <param name="cfgclass">シリアライズするオブジェクト</param>
        public static void SaveXML<Type>(string fpath, Type cfgclass)
        {
            XmlSerializer xsz = new XmlSerializer(typeof(Type));
            using (FileStream fs = new FileStream(fpath, FileMode.Create, FileAccess.Write))
            {
                xsz.Serialize(fs, cfgclass);
            }
        }

        /// <summary>
        /// XMLファイルからオブジェクトをデシリアライズします。
        /// </summary>
        /// <typeparam name="Type">デシリアライズする型</typeparam>
        /// <param name="fpath">読込先のファイルパス</param>
        /// <param name="raiseFileNotFoundException">ファイルが存在しないときにFileNotFoundExceptionを発生させるか</param>
        /// <returns>デシリアライズしたオブジェクト</returns>
        public static Type LoadXML<Type>(string fpath, bool raiseFileNotFoundException)
        {
            if (!System.IO.File.Exists(fpath))
            {
                if (raiseFileNotFoundException)
                    throw new FileNotFoundException("ファイル " + fpath + "が見つかりません。");
                else
                    return default(Type);
            }
            XmlSerializer xsz = new XmlSerializer(typeof(Type));
            using (FileStream fs = new FileStream(fpath, FileMode.Open, FileAccess.Read))
            {
                return (Type)xsz.Deserialize(fs);
            }
        }
    }
}
