using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace K.Snippets
{
    static partial class Files
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        extern public static IntPtr LoadImage(IntPtr Instance, String Name, uint Type, int xDesired, int yDesired, uint LoadOption);

        public static Cursor LoadCursor(String LoadCursorName)
        {
            IntPtr ptr = LoadImage(IntPtr.Zero, LoadCursorName, 2, 0, 0, 0x10 | 0x40);
            if (ptr == IntPtr.Zero)
            {
                throw new Exception("カーソルのロードに失敗しました。(" + Marshal.GetLastWin32Error() + ")");
            }
            return new Cursor(ptr);
        }

        public static Cursor LoadCursorPackaged(Stream cursorStream)
        {
            string temp = Path.GetTempFileName();
            using (FileStream fs = new FileStream(temp, FileMode.Create, FileAccess.ReadWrite))
            {
                byte[] copybuf = new byte[cursorStream.Length];
                cursorStream.Read(copybuf,0, copybuf.Length);
                fs.Write(copybuf, 0, copybuf.Length);
                fs.Flush();
            }
            Cursor ret = LoadCursor(temp);
            File.Delete(temp);
            return ret;
        }
    }
}
