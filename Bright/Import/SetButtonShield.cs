using System;
using System.Windows.Forms;

namespace K.Snippets
{
    static partial class WinForms
    {
        /// <summary>
        /// ボタンのUACシールド状態を変更します。
        /// </summary>
        /// <param name="TargetButton">付加するボタンオブジェクト</param>
        /// <param name="Addition">付加するか</param>
        public static void SetButtonShieldState(Button target, bool Addition)
        {
            K.WinAPI.SendMessage(target.Handle, (UInt32)0x160c, IntPtr.Zero, (IntPtr)1);
        }
    }
}