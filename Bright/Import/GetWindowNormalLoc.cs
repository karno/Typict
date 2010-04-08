using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace K.Snippets
{
    static partial class WinForms
    {
        /// <summary>
        /// �E�B���h�E�̕W�����̑傫�����擾���܂��B
        /// </summary>
        /// <param name="form">�擾���錳�̃E�B���h�E</param>
        /// <returns>�W�����̃T�C�Y</returns>
        public static Rectangle GetNormalWindowLocation(Form form)
        {
            //WinAPI GetWindowPlacement�֐����g���ƁA�E�B���h�E�̏�ԂɊ֌W�Ȃ��A
            //�u�ʏ펞�v�̃E�B���h�E�̃T�C�Y���擾�ł��܂��B
            K.WinAPI.WINDOWPLACEMENT wndpl = new WinAPI.WINDOWPLACEMENT();
            wndpl.Length = Marshal.SizeOf(wndpl);
            K.WinAPI.GetWindowPlacement((int)form.Handle, ref wndpl);
            return new System.Drawing.Rectangle(
                wndpl.rcNormalPosition.left,
                wndpl.rcNormalPosition.top,
                wndpl.rcNormalPosition.right - wndpl.rcNormalPosition.left,
                wndpl.rcNormalPosition.bottom - wndpl.rcNormalPosition.top);
        }
    }
}