using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace K.Snippets
{
    static partial class WinForms
    {
        /// <summary>
        /// ウィンドウの標準時の大きさを取得します。
        /// </summary>
        /// <param name="form">取得する元のウィンドウ</param>
        /// <returns>標準時のサイズ</returns>
        public static Rectangle GetNormalWindowLocation(Form form)
        {
            //WinAPI GetWindowPlacement関数を使うと、ウィンドウの状態に関係なく、
            //「通常時」のウィンドウのサイズを取得できます。
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