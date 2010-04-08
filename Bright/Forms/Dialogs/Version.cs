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
    public partial class Version : Form
    {
        public Version()
        {
            InitializeComponent();
        }

        private void Version_Load(object sender, EventArgs e)
        {
            appNameLabel.Text = Define.AppName;
            verLabel.Text = "Version " + Define.Version.ToString("0.00") + " " + Define.Suffix;
            supportLink.Text = Define.ReleaseURI;
        }

        private void supportLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(supportLink.Text);
            }
            catch { }
        }

        private void detailTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(e.LinkText);
            }
            catch { }

        }
    }
}
