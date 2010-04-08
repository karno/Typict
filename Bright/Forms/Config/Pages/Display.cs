using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Bright.Forms.Config.Pages
{
    public partial class Display : Bright.Forms.Config.ConfigPage
    {
        public Display()
        {
            InitializeComponent();
        }

        public override string Description
        {
            get
            {
                return "表示";
            }
        }

        private void Display_Load(object sender, EventArgs e)
        {
            CenteringImage.Checked = Core.Config.DisplayConfig.CenteringImage;
            InterpolationMode.SelectedIndex = (int)Core.Config.DisplayConfig.InterpolationMode;
            UseDynamicInterpolate.Checked = Core.Config.DisplayConfig.UseDynamicInterpolate;
            SizeBorder.Value = Core.Config.DisplayConfig.SizeBorder;
            BigImageIntpMode.SelectedIndex = (int)Core.Config.DisplayConfig.BigImageIntpMode;
            ThumbnailSizeW.Value = Core.Config.DisplayConfig.ThumbnailSize.Width;
            ThumbnailSizeH.Value = Core.Config.DisplayConfig.ThumbnailSize.Height;
            KeyListPoint.Value = (decimal)Core.Config.DisplayConfig.KeyListPoint;
            bigImageGroup.Enabled = UseDynamicInterpolate.Checked;
        }

        protected override void OnAccepted()
        {
            Core.Config.DisplayConfig.CenteringImage = CenteringImage.Checked;
            Core.Config.DisplayConfig.InterpolationMode = (InterpolationMode)InterpolationMode.SelectedIndex;
            Core.Config.DisplayConfig.UseDynamicInterpolate = UseDynamicInterpolate.Checked;
            Core.Config.DisplayConfig.SizeBorder = (ulong)SizeBorder.Value;
            Core.Config.DisplayConfig.BigImageIntpMode = (InterpolationMode)BigImageIntpMode.SelectedIndex;
            Core.Config.DisplayConfig.ThumbnailSize = new Size((int)ThumbnailSizeW.Value, (int)ThumbnailSizeH.Value);
            Core.Config.DisplayConfig.KeyListPoint = (double)KeyListPoint.Value;
            base.OnAccepted();
        }

        private void UseDynamicInterpolate_CheckedChanged(object sender, EventArgs e)
        {
            bigImageGroup.Enabled = UseDynamicInterpolate.Checked;
        }
    }
}
