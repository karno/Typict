using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bright.Forms.Main.Docks
{
    public partial class PictureView : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        protected override string GetPersistString()
        {
            return "pictureview";
        }

        public event Action<bool> ImageLoadingChanged;
        public event Action<string> FileChanged;

        public bool ZoomPicture
        {
            get { return renderer.ZoomPicture; }
            set
            {
                renderer.ZoomPicture = value;
                renderer.Refresh();
            }
        }
        public bool KeepProportion
        {
            get { return renderer.KeepProportion; }
            set
            {
                renderer.KeepProportion = value;
                renderer.Refresh();
            }
        }
        public bool ZoomSmallPicture
        {
            get { return renderer.ZoomSmallPicture; }
            set
            {
                renderer.ZoomSmallPicture = value;
                renderer.Refresh();
            }
        }
        public string AdditionalString
        {
            get { return renderer.AdditionalString; }
            set
            {
                renderer.AdditionalString = value;
                renderer.Refresh();
            }
        }

        public PictureView()
        {
            InitializeComponent();
            horzScroll.GotFocus += new EventHandler(restoreFocus);
            vertScroll.GotFocus += new EventHandler(restoreFocus);
            renderer.ChangeShowScroll += new Action<bool>(renderer_ChangeShowScroll);
            renderer.UpdateImageSize += new Action(renderer_UpdateImageSize);
            renderer.ImageLoadingChanged += new Action<bool>((b) => { if (ImageLoadingChanged != null)ImageLoadingChanged.Invoke(b); });
            renderer.FileChanged += new Action<string>((s) => { if (FileChanged != null) FileChanged.Invoke(s); });
            renderer.PositionUpdateRequired += new Action<Point>(renderer_PositionUpdateRequired);
        }

        bool silentScrollUpdate = false;
        void renderer_PositionUpdateRequired(Point obj)
        {
            silentScrollUpdate = true;
            Point nv = new Point();
            if (horzScroll.Enabled)
            {
                int npos = horzScroll.Value + obj.X;
                if (npos > horzScroll.Maximum)
                    npos = horzScroll.Maximum;
                else if (npos < 0)
                    npos = 0;
                horzScroll.Value = npos;
                nv.X = npos;
            }
            if (vertScroll.Enabled)
            {
                int npos = vertScroll.Value + obj.Y;
                if (npos > vertScroll.Maximum)
                    npos = vertScroll.Maximum;
                else if (npos < 0)
                    npos = 0;
                vertScroll.Value = npos;
                nv.Y = npos;
            }
            renderer.SetPoint(nv.X, nv.Y);
            silentScrollUpdate = false;
        }

        void restoreFocus(object sender, EventArgs e)
        {
            if (!this.renderer.Focus())
                System.Diagnostics.Debug.WriteLine("focus set failed!");
        }

        void renderer_UpdateImageSize()
        {
            horzScroll.Value = 0;
            vertScroll.Value = 0;
            RecalcuateScroll();
        }

        void RecalcuateScroll()
        {
            horzScroll.Enabled = renderer.ImageSize.Width > renderer.Width;
            if (horzScroll.Enabled)
            {
                horzScroll.Maximum = renderer.ImageSize.Width - renderer.Width;
                horzScroll.LargeChange = renderer.Width;
                if (horzScroll.Value > horzScroll.Maximum)
                    horzScroll.Value = horzScroll.Maximum;
            }
            vertScroll.Enabled = renderer.ImageSize.Height > renderer.Height;
            if (vertScroll.Enabled)
            {
                vertScroll.Maximum = renderer.ImageSize.Height - renderer.Height;
                vertScroll.LargeChange = renderer.Height;
                if (vertScroll.Value > vertScroll.Maximum)
                    vertScroll.Value = vertScroll.Maximum;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            renderer.ClientAreaSize = this.ClientSize;
            base.OnResize(e);
            Refresh();
            RecalcuateScroll();
        }

        void renderer_ChangeShowScroll(bool obj)
        {
            horzScroll.Visible = obj;
            vscPanel.Visible = obj;
            RecalcuateScroll();
        }

        private void vertScroll_Scroll(object sender, ScrollEventArgs e)
        {
            renderer.YPosition = vertScroll.Value;
        }

        private void vertScroll_ValueChanged(object sender, EventArgs e)
        {
            if (silentScrollUpdate) return;
            renderer.YPosition = vertScroll.Value;
        }

        private void horzScroll_Scroll(object sender, ScrollEventArgs e)
        {
            renderer.XPosition = horzScroll.Value;
        }

        private void horzScroll_ValueChanged(object sender, EventArgs e)
        {
            if (silentScrollUpdate) return;
            renderer.XPosition = horzScroll.Value;
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                case Keys.Tab:
                case Keys.Enter:
                case Keys.Escape:
                    e.IsInputKey = true;
                    break;
            }
            base.OnPreviewKeyDown(e);
        }
    }
}
