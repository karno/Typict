using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bright.Forms.Grouping
{
    public partial class Duplication : Form
    {
        string src;
        string dest;
        public bool AllTrap
        {
            get { return acceptAll.Checked; }
        }
        public Duplication(string source, string destination)
        {
            src = source;
            dest = destination;
            InitializeComponent();
        }

        private void Duplication_Load(object sender, EventArgs e)
        {
            srcPicture.Image = K.Snippets.Images.ImageSafeReader(src, true);
            destPicture.Image = K.Snippets.Images.ImageSafeReader(dest, true);
        }

        protected override void OnClosed(EventArgs e)
        {
            srcPicture.Dispose();
            destPicture.Dispose();
            base.OnClosed(e);
        }
    }
}
