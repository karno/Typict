using System;
using System.Drawing;
using System.IO;

namespace K.Snippets
{
    static partial class Images
    {
        /// <summary>
        /// �摜�t�@�C�������b�N�����ɓǂݍ��݂܂��B
        /// </summary>
        /// <param name="path">�摜�t�@�C���̃p�X</param>
        /// <param name="raiseFileNotFoundException">�t�@�C�������݂��Ȃ��Ƃ���FileNotFoundException�𔭐������邩(false�̎���null��Ԃ��܂�)</param>
        public static Image ImageSafeReader(string path, bool raiseFileNotFoundException)
        {
            //Image.FromFile���g���ēǂݍ��ނƁA�A�v���P�[�V�����I�����܂ŉ摜�t�@�C�������b�N����܂��B
            //�ȈՓI�ɗ��p����ꍇ�������A���b�N�����Ɣ��ɍ���̂ŁAFileStream���g���ă��b�N����Ȃ��悤�ɓǂ݂܂��B
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
                    throw new FileNotFoundException("�摜�t�@�C�� " + path + " �͑��݂��܂���B");
                else
                    return null;
            }
        }
    }
}