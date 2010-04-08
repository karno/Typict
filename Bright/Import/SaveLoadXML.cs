using System;
using System.Xml.Serialization;
using System.IO;

namespace K.Snippets
{
    static partial class Files
    {
        /// <summary>
        /// XML�t�@�C���փI�u�W�F�N�g���V���A���C�Y���܂��B
        /// </summary>
        /// <typeparam name="Type">�V���A���C�Y����^</typeparam>
        /// <param name="fpath">�ۑ���̃t�@�C���p�X</param>
        /// <param name="cfgclass">�V���A���C�Y����I�u�W�F�N�g</param>
        public static void SaveXML<Type>(string fpath, Type cfgclass)
        {
            XmlSerializer xsz = new XmlSerializer(typeof(Type));
            using (FileStream fs = new FileStream(fpath, FileMode.Create, FileAccess.Write))
            {
                xsz.Serialize(fs, cfgclass);
            }
        }

        /// <summary>
        /// XML�t�@�C������I�u�W�F�N�g���f�V���A���C�Y���܂��B
        /// </summary>
        /// <typeparam name="Type">�f�V���A���C�Y����^</typeparam>
        /// <param name="fpath">�Ǎ���̃t�@�C���p�X</param>
        /// <param name="raiseFileNotFoundException">�t�@�C�������݂��Ȃ��Ƃ���FileNotFoundException�𔭐������邩</param>
        /// <returns>�f�V���A���C�Y�����I�u�W�F�N�g</returns>
        public static Type LoadXML<Type>(string fpath, bool raiseFileNotFoundException)
        {
            if (!System.IO.File.Exists(fpath))
            {
                if (raiseFileNotFoundException)
                    throw new FileNotFoundException("�t�@�C�� " + fpath + "��������܂���B");
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
