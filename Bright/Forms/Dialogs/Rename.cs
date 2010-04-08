using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Bright.Forms.Dialogs
{
    public partial class Rename : Form
    {
        Data.GroupingElement elem;
        public Rename(Data.GroupingElement elem)
        {
            if (elem == null)
                throw new ArgumentNullException("elem");
            this.elem = elem;
            InitializeComponent();
            if (String.IsNullOrEmpty(elem.NewName))
            {
                nameBox.Text = Path.GetFileNameWithoutExtension(elem.ImageSourcePath);
                extLabel.Text = Path.GetExtension(elem.ImageSourcePath);
            }
            else
            {
                nameBox.Text = Path.GetFileNameWithoutExtension(elem.NewName);
                extLabel.Text = Path.GetExtension(elem.NewName);
            }
        }

        public string GetNewName()
        {
            return nameBox.Text + Path.GetExtension(elem.ImageSourcePath);
        }

        private void Rename_Shown(object sender, EventArgs e)
        {
            if (elem.IsBuffered)
                previewBox.Image = elem.BufferedImage;
            else
                previewBox.BackColor = Color.Black;
            nameBox_TextChanged(null, null);
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            okBtn.Enabled = nameBox.Text != String.Empty && nameBox.Text != Path.GetFileNameWithoutExtension(elem.ImageSourcePath);
        }
    }
}
