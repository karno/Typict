using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bright.Forms.Config.Pages
{
    public partial class Overlap : Bright.Forms.Config.ConfigPage
    {
        public Overlap()
        {
            InitializeComponent();
        }

        protected void LoadConfig(Cores.Config.Display.OverlapObject linkOObj)
        {
            if (linkOObj == null)
                throw new ArgumentNullException("linkOObj");
            ShowThis.Checked = linkOObj.Show;
            overlapConfigGroup.Enabled = ShowThis.Checked;
            DrawLocation.SelectedIndex = (int)linkOObj.DrawLocation;
            OffsetX.Value = linkOObj.Offset.X;
            OffsetY.Value = linkOObj.Offset.Y;
        }

        protected T AcceptConfig<T>(T linkOObj)
            where T:Cores.Config.Display.OverlapObject
        {
            linkOObj.Show = ShowThis.Checked;
            linkOObj.DrawLocation = (Cores.Config.Display.OverlapObject.DrawLocations)DrawLocation.SelectedIndex;
            linkOObj.Offset = new Point((int)OffsetX.Value, (int)OffsetY.Value);
            return linkOObj;
        }

        private void Show_CheckedChanged(object sender, EventArgs e)
        {
            overlapConfigGroup.Enabled = ShowThis.Checked;
        }
    }
}
