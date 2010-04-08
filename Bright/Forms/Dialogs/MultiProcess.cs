using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bright.Forms.Dialogs
{
    public partial class MultiProcess : Form
    {
        public MultiProcess(int remain)
        {
            InitializeComponent();
            numCount.Minimum = 1;
            numCount.Maximum = remain;
            numSlider.Minimum = 1;
            numSlider.Maximum = remain;
            numSlider.ValueChanged += new EventHandler(numSlider_ValueChanged);
        }

        public int GetValue()
        {
            return (int)numCount.Value;
        }

        bool clutch = false;
        private void numCount_ValueChanged(object sender, EventArgs e)
        {
            if (clutch) return;
            clutch = true;
            numSlider.Value = (int)numCount.Value;
            clutch = false;
        }

        void numSlider_ValueChanged(object sender, EventArgs e)
        {
            if (clutch) return;
            clutch = true;
            numCount.Value = numSlider.Value;
            clutch = false;
        }

    }
}
