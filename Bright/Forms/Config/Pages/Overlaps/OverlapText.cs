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
    public partial class OverlapText : Bright.Forms.Config.Pages.Overlap
    {
        public OverlapText()
        {
            InitializeComponent();
        }

        public override string Description
        {
            get
            {
                return "オーバーラップテキスト";
            }
        }

        Font UsingFont = null;
        private void OverlapText_Load(object sender, EventArgs e)
        {
            this.LoadConfig(Core.Config.DisplayConfig.FileNameTextConfig);
            UsingFont = Core.Config.DisplayConfig.FileNameTextConfig.UsingFont.Value;
            UseAntiAlias.Checked = Core.Config.DisplayConfig.FileNameTextConfig.UseAntiAlias;
            FileNameTextFullpath.Checked = Core.Config.DisplayConfig.FileNameTextConfig.FileNameTextFullpath;
        }

        protected override void OnAccepted()
        {
            Core.Config.DisplayConfig.FileNameTextConfig = this.AcceptConfig<Cores.Config.Display.OverlapText>(new Cores.Config.Display.OverlapText());
            Core.Config.DisplayConfig.FileNameTextConfig.FileNameTextFullpath = FileNameTextFullpath.Checked;
            Core.Config.DisplayConfig.FileNameTextConfig.UseAntiAlias = UseAntiAlias.Checked;
            Core.Config.DisplayConfig.FileNameTextConfig.UsingFont.Value = UsingFont;

        }

        private void ChangeUsingFont_Click(object sender, EventArgs e)
        {
            using (var fd = new FontDialog())
            {
                fd.Font = UsingFont;
                fd.AllowSimulations = true;
                fd.AllowVectorFonts = true;
                fd.AllowVerticalFonts = false;
                fd.FontMustExist = true;
                fd.ShowEffects = true;
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    UsingFont = fd.Font;
                    previewBox.Refresh();
                }
            }
        }

        private void previewBox_Paint(object sender, PaintEventArgs e)
        {
            if (UseAntiAlias.Checked)
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            else
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            using (GraphicsPath gp = new GraphicsPath())
            {
                using (var sf = new StringFormat(StringFormatFlags.NoClip | StringFormatFlags.NoWrap))
                {
                    gp.AddString("TESTtestテストてすと",
                        UsingFont.FontFamily, 
                        (int)(UsingFont.Style),
                        UsingFont.Size, new Point(), sf);
                    e.Graphics.FillPath(Brushes.White, gp);
                    e.Graphics.DrawPath(Pens.Black, gp);
                }
            }

        }

        private void UseAntiAlias_CheckedChanged(object sender, EventArgs e)
        {
            previewBox.Refresh();
        }
    }
}
