using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bright.Forms.Config.Pages
{
    public partial class OverlapThumbnail : Bright.Forms.Config.Pages.Overlap
    {
        public OverlapThumbnail()
        {
            InitializeComponent();
        }

        public override string Description
        {
            get
            {
                return "オーバーラップサムネイル";
            }
        }

        private void OverlapThumbnail_Load(object sender, EventArgs e)
        {
            this.LoadConfig(Core.Config.DisplayConfig.OverlapThumbnailConfig);
            ThumbnailSizeW.Value = Core.Config.DisplayConfig.OverlapThumbnailConfig.ThumbnailSize.Width;
            ThumbnailSizeH.Value = Core.Config.DisplayConfig.OverlapThumbnailConfig.ThumbnailSize.Height;
        }

        protected override void OnAccepted()
        {
            Core.Config.DisplayConfig.OverlapThumbnailConfig = this.AcceptConfig<Cores.Config.Display.OverlapThumbnail>(new Cores.Config.Display.OverlapThumbnail());
            Core.Config.DisplayConfig.OverlapThumbnailConfig.ThumbnailSize = new Size((int)ThumbnailSizeW.Value, (int)ThumbnailSizeH.Value);
            base.OnAccepted();
        }
    }
}
