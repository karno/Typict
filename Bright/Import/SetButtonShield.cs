using System;
using System.Windows.Forms;

namespace K.Snippets
{
    static partial class WinForms
    {
        /// <summary>
        /// �{�^����UAC�V�[���h��Ԃ�ύX���܂��B
        /// </summary>
        /// <param name="TargetButton">�t������{�^���I�u�W�F�N�g</param>
        /// <param name="Addition">�t�����邩</param>
        public static void SetButtonShieldState(Button target, bool Addition)
        {
            K.WinAPI.SendMessage(target.Handle, (UInt32)0x160c, IntPtr.Zero, (IntPtr)1);
        }
    }
}