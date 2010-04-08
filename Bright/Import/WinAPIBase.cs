using System;
using System.Runtime.InteropServices;

//K LIBRARY
namespace K
{
    /// <summary>
    /// Windows APIを利用する際に必ず含めるようにする。
    /// つまり、このファイルを除外すればWindowsAPIを利用しているコントロールを検出できる。
    /// もしくは、他の環境への移植が楽になる。(かもしれない。)
    /// </summary>
    static class WinAPI
    {
        #region Declarations

        #region user32.dll

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr h, int m, IntPtr w, IntPtr l);
        [DllImport("user32.dll")]
        extern public static bool GetWindowPlacement(int hWnd, ref WINDOWPLACEMENT lpwndpl);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        extern public static IntPtr LoadImage(IntPtr Instance, String Name, uint Type, int xDesired, int yDesired, uint LoadOption);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        extern public static IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wp, IntPtr lp);

        #endregion

        #region comctl32.dll

        [DllImport("comctl32.dll")]
        public static extern bool InitCommonControls();

        #endregion

        #endregion

        #region Structs

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x, y;
            public POINT(int x, int y) { this.x = x; this.y = y; }
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left; public int top; public int right; public int bottom;
            public RECT(int left, int top, int right, int bottom) { this.left = left; this.top = top; this.right = right; this.bottom = bottom; }
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPLACEMENT { public int Length; public int flags; public int showCmd; public POINT ptMinPosition; public POINT ptMaxPosition; public RECT rcNormalPosition; }
        #endregion

        #region Macros

        public static IntPtr MakeLong(int a, int b)
        {
            return (IntPtr)((long)(((ushort)(a)) | ((uint)((ushort)(b))) << 16));
        }

        public static int GetHiWord(IntPtr word)
        {
            return (int)((ushort)((uint)(word) >> 16));
        }

        public static int GetLoWord(IntPtr word)
        {
            return (int)((ushort)((uint)(word) & 0xffff));
        }

        #endregion

        #region constant values

        public const int WM_HSCROLL = 0x114;
        public const int WM_VSCROLL = 0x115;
        public const int UDM_SETRANGE = 0x0465;
        public const int UDM_GETRANGE = 0x0466;
        public const int UDM_SETPOS = 0x0467;
        public const int UDM_GETPOS = 0x0468;

        #endregion
    }
}