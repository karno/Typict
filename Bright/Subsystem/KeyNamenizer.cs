using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bright
{
    public static class KeyNamenizer
    {
        public static string GetString(this Keys key)
        {
            return ((key & Keys.Shift) == Keys.Shift ? "S-" : "") +
                new KeysConverter().ConvertToString(key & ~Keys.Shift);

        }
    }
}
