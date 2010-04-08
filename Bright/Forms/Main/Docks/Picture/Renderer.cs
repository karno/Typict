using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace Bright.Forms.Main.Docks.Picture
{
    public partial class Renderer : Control
    {
        public event Action<bool> ChangeShowScroll;

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

        public event Action<bool> ImageLoadingChanged;
        public event Action<string> FileChanged;

        bool _showScroll = true;
        public bool ShowScroll
        {
            get { return _showScroll; }
            private set
            {
                if (value == _showScroll) return;
                _showScroll = value;
                if (ChangeShowScroll != null)
                    ChangeShowScroll.Invoke(value);
            }
        }

        public event Action UpdateImageSize;

        private int xpos = 0;
        public int XPosition
        {
            get { return this.xpos; }
            set
            {
                xpos = value;
                this.Refresh();
            }
        }
        private int ypos = 0;
        public int YPosition
        {
            get { return ypos; }
            set
            {
                ypos = value;
                this.Refresh();
            }
        }
        public void SetPoint(int x, int y)
        {
            xpos = x;
            ypos = y;
            this.Refresh();
        }
        public event Action<Point> PositionUpdateRequired;
        public Size ImageSize
        {
            get
            {
                if (curElem == null || curElem.BufferedImage == null || curElem.BILocking)
                    return new Size();
                else
                    return curElem.BufferedImage.Size;
            }
        }
        public Size ClientAreaSize { get; set; }
        private bool _zoompicture = false;
        public bool ZoomPicture
        {
            get { return _zoompicture; }
            set
            {
                _zoompicture = value;
                if (!value && Core.Config.BehaviorConfig.UseHandMoveOnNotZooming)
                    this.Cursor = handCursor;
                else
                    this.Cursor = Cursors.Default;
            }
        }
        public bool ZoomSmallPicture { get; set; }
        public bool KeepProportion { get; set; }
        public string AdditionalString { get; set; }

        public Cursor handCursor = null;
        public Cursor grabCursor = null;

        public Renderer()
        {
            InitializeComponent();
            handCursor = K.Snippets.Files.LoadCursorPackaged(new MemoryStream(Properties.Resources.open));
            grabCursor = K.Snippets.Files.LoadCursorPackaged(new MemoryStream(Properties.Resources.grab));
            Subsystem.Prefetch.Instance.PrefetchCompleted += new Action<Bright.Data.GroupingElement>(Instance_PrefetchCompleted);
            Core.CurrentOperationUpdated += new Action(Core_CurrentOperationUpdated);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.StandardClick, true);
            this.SetStyle(ControlStyles.ContainerControl, false);
        }

        Data.GroupingElement curElem = null;
        Data.GroupingElement nextElem = null;
        void Core_CurrentOperationUpdated()
        {
            if (Core.CurrentOperation != null)
            {
                Core.CurrentOperation.IndexUpdated += new Action(CurrentOperation_IndexUpdated);
                CurrentOperation_IndexUpdated();
            }
        }

        void CurrentOperation_IndexUpdated()
        {
            curElem = Core.CurrentOperation.GetCurrentElement();
            //バッファリングされているかのチェック
            if (curElem != null && !curElem.IsBuffered && !curElem.LoadFailed)
            {
                if (ImageLoadingChanged != null)
                    ImageLoadingChanged.Invoke(true);
                System.Diagnostics.Debug.WriteLine("Self fetch start... =>" + curElem.ImageSourcePath);
                var invoke = new Action<Data.GroupingElement>(Subsystem.Prefetch.Instance.Loader.LoadImageByElem);
                invoke.BeginInvoke(curElem, (iar) =>
                {
                    ((Action<Data.GroupingElement>)iar.AsyncState).EndInvoke(iar);
                    this.Invoke(new Action(() =>
                    {
                        if (ImageLoadingChanged != null)
                            ImageLoadingChanged.Invoke(false);
                        if (UpdateImageSize != null)
                            UpdateImageSize.Invoke();
                    }));
                }, invoke);
            }
            if (curElem != null)
            {
                if (FileChanged != null)
                    FileChanged.Invoke(curElem.ImageSourcePath);
            }
            else
            {
                if (FileChanged != null)
                    FileChanged.Invoke(String.Empty);
            }
            if (Core.Config.DisplayConfig.OverlapThumbnailConfig.Show)
            {
                nextElem = Core.CurrentOperation.GetNextElement();
                if (nextElem != null && !nextElem.IsBuffered)
                {
                    System.Diagnostics.Debug.WriteLine("Self thumbnail fetch start... =>" + curElem.ImageSourcePath);
                    var invoke = new Action<Data.GroupingElement>(Subsystem.Prefetch.Instance.Loader.LoadImageByElem);
                    invoke.BeginInvoke(curElem, (iar) =>
                    {
                        ((Action<Data.GroupingElement>)iar.AsyncState).EndInvoke(iar);
                        this.Invoke(new Action(() =>
                        {
                            this.Refresh();
                        }));
                    }, invoke);
                }
            }
            if (UpdateImageSize != null)
                UpdateImageSize.Invoke();
        }

        void Instance_PrefetchCompleted(Bright.Data.GroupingElement obj)
        {
            if (obj == curElem)
                this.Invoke(new Action(Refresh));
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            #region DrawPicture
            pe.Graphics.InterpolationMode = Core.Config.DisplayConfig.InterpolationMode;
            if (curElem == null)
            {
                ShowScroll = false;
            }
            else if (!curElem.IsBuffered || curElem.BILocking)
            {
                ShowScroll = false;
                TextRenderer.DrawText(
                    pe.Graphics, "Loading...",
                    this.Font, ClientRectangle, Color.DimGray,
                    TextFormatFlags.EndEllipsis | TextFormatFlags.HorizontalCenter | TextFormatFlags.NoPrefix | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter);
                if (curElem.BILocking)
                    return;
                else
                    return;

            }
            else if (curElem.LoadFailed)
            {
                ShowScroll = false;
                pe.Graphics.FillRectangle(Brushes.PeachPuff, new Rectangle(0, 0, this.Width, this.Height));
                pe.Graphics.DrawImage(Properties.Resources.error, new Point(20, 20));
                Rectangle dest = new Rectangle(70, 20, this.Width - 70, 48);
                pe.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                using (var f = new Font(this.Font.FontFamily, 20, FontStyle.Bold))
                    TextRenderer.DrawText(
                        pe.Graphics, "Image Load Failed.",
                        f, dest, Color.Red,
                        TextFormatFlags.EndEllipsis | TextFormatFlags.Left | TextFormatFlags.NoPrefix | TextFormatFlags.VerticalCenter);
                dest = new Rectangle(70, 70, this.Width - 70, this.Height - 70);
                TextRenderer.DrawText(
                    pe.Graphics, curElem.ExceptionText,
                    this.Font, dest, Color.Black,
                    TextFormatFlags.Left | TextFormatFlags.Top | TextFormatFlags.NoPrefix);
            }
            else
            {
                if (ZoomPicture &&
                    (ulong)curElem.BufferedImage.Width * (ulong)curElem.BufferedImage.Height > Core.Config.DisplayConfig.SizeBorder)
                {
                    pe.Graphics.InterpolationMode = Core.Config.DisplayConfig.BigImageIntpMode;
                }
                var ClientRectangle = new Rectangle(0, 0, this.Width, this.Height);
                pe.Graphics.FillRectangle(SystemBrushes.Control, ClientRectangle);
                Rectangle imgDest = new Rectangle();
                #region CalcuateProportion
                if (ZoomPicture)
                {
                    ShowScroll = false;
                    if (curElem.BufferedImage.Width > ClientAreaSize.Width ||
                        curElem.BufferedImage.Height > ClientAreaSize.Height)
                    {
                        if (KeepProportion)
                        {
                            double xovf = (double)ClientAreaSize.Width / curElem.BufferedImage.Width;
                            double yovf = (double)ClientAreaSize.Height / curElem.BufferedImage.Height;
                            double rate = xovf < yovf ? xovf : yovf;
                            imgDest.Width = (int)(curElem.BufferedImage.Width * rate);
                            imgDest.Height = (int)(curElem.BufferedImage.Height * rate);
                        }
                        else
                        {
                            imgDest = ClientRectangle;
                        }
                    }
                    else if (ZoomSmallPicture)
                    {
                        if (KeepProportion)
                        {
                            double xovf = (double)ClientAreaSize.Width / curElem.BufferedImage.Width;
                            double yovf = (double)ClientAreaSize.Height / curElem.BufferedImage.Height;
                            double rate = xovf > yovf ? yovf : xovf;
                            imgDest.Width = (int)(curElem.BufferedImage.Width * rate);
                            imgDest.Height = (int)(curElem.BufferedImage.Height * rate);
                        }
                        else
                        {
                            imgDest = ClientRectangle;
                        }
                    }
                    else
                    {
                        imgDest.Width = curElem.BufferedImage.Width;
                        imgDest.Height = curElem.BufferedImage.Height;
                    }
                }
                else
                {
                    if (curElem.BufferedImage.Width > ClientAreaSize.Width ||
                        curElem.BufferedImage.Height > ClientAreaSize.Height)
                    {
                        ShowScroll = true;
                    }
                    else
                    {
                        ShowScroll = false;
                    }
                    imgDest.Width = curElem.BufferedImage.Width;
                    imgDest.Height = curElem.BufferedImage.Height;
                }
                #endregion
                if (Core.Config.DisplayConfig.CenteringImage)
                {
                    imgDest.X = (this.Width - imgDest.Width) / 2;
                    imgDest.Y = (this.Height - imgDest.Height) / 2;
                }
                if (ShowScroll)
                {
                    if (imgDest.X <= 0)
                        imgDest.X = -XPosition;
                    if (imgDest.Y <= 0)
                        imgDest.Y = -YPosition;
                }
                try
                {
                    pe.Graphics.DrawImage(curElem.BufferedImage, imgDest);
                }
                catch (Exception e)
                {
                    TextRenderer.DrawText(pe.Graphics, e.ToString(), this.Font, imgDest, Color.Red);
                }
            }
            #endregion
            #region DrawPreview
            if (nextElem != null && nextElem.IsBuffered && !nextElem.BTLocking && Core.Config.DisplayConfig.OverlapThumbnailConfig.Show)
            {
                Point destination = new Point();
                switch (Core.Config.DisplayConfig.OverlapThumbnailConfig.DrawLocation)
                {
                    case Bright.Cores.Config.Display.OverlapObject.DrawLocations.LeftTop:
                        destination = new Point(0, 0);
                        break;
                    case Bright.Cores.Config.Display.OverlapObject.DrawLocations.LeftBottom:
                        destination = new Point(0, this.Height - Core.Config.DisplayConfig.OverlapThumbnailConfig.ThumbnailSize.Height);
                        break;
                    case Bright.Cores.Config.Display.OverlapObject.DrawLocations.RightTop:
                        destination = new Point(this.Width - Core.Config.DisplayConfig.OverlapThumbnailConfig.ThumbnailSize.Width, 0);
                        break;
                    case Bright.Cores.Config.Display.OverlapObject.DrawLocations.RightBottom:
                        destination = new Point(this.Width - Core.Config.DisplayConfig.OverlapThumbnailConfig.ThumbnailSize.Width,
                                                this.Height - Core.Config.DisplayConfig.OverlapThumbnailConfig.ThumbnailSize.Height);
                        break;
                    default:
                        break;
                }
                destination.X += Core.Config.DisplayConfig.OverlapThumbnailConfig.Offset.X;
                destination.Y += Core.Config.DisplayConfig.OverlapThumbnailConfig.Offset.Y;
                pe.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                pe.Graphics.DrawImage(nextElem.BufferedImage,
                    new Rectangle(destination, Core.Config.DisplayConfig.OverlapThumbnailConfig.ThumbnailSize));
            }
            #endregion
            #region DrawFileName
            if (curElem != null && Core.Config.DisplayConfig.FileNameTextConfig.Show)
            {
                Point destination = new Point();
                string drawText = Path.GetFileName(curElem.ImageSourcePath);
                if (!String.IsNullOrEmpty(curElem.NewName))
                    drawText += " -> " + curElem.NewName;
                if (!String.IsNullOrEmpty(AdditionalString))
                    drawText += Environment.NewLine + AdditionalString;
                if (Core.Config.DisplayConfig.FileNameTextConfig.FileNameTextFullpath)
                    drawText = curElem.ImageSourcePath;
                if (Core.Config.DisplayConfig.FileNameTextConfig.UseAntiAlias)
                    pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                else
                    pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
                switch (Core.Config.DisplayConfig.FileNameTextConfig.DrawLocation)
                {
                    case Bright.Cores.Config.Display.OverlapText.DrawLocations.LeftTop:
                        destination = new Point(0, 0);
                        break;
                    case Bright.Cores.Config.Display.OverlapText.DrawLocations.LeftBottom:
                        destination = new Point(0, this.Height);
                        break;
                    case Bright.Cores.Config.Display.OverlapText.DrawLocations.RightTop:
                        destination = new Point(this.Width, 0);
                        break;
                    case Bright.Cores.Config.Display.OverlapText.DrawLocations.RightBottom:
                        destination = new Point(this.Width, this.Height);
                        break;
                    default:
                        destination = new Point();
                        break;
                }
                destination.X += Core.Config.DisplayConfig.FileNameTextConfig.Offset.X;
                destination.Y += Core.Config.DisplayConfig.FileNameTextConfig.Offset.Y;

                using (GraphicsPath gp = new GraphicsPath())
                {
                    using (var sf = new StringFormat(StringFormatFlags.NoClip | StringFormatFlags.NoWrap))
                    {
                        if (Core.Config.DisplayConfig.FileNameTextConfig.DrawLocation == Bright.Cores.Config.Display.OverlapText.DrawLocations.RightTop ||
                            Core.Config.DisplayConfig.FileNameTextConfig.DrawLocation == Bright.Cores.Config.Display.OverlapText.DrawLocations.RightBottom)
                            sf.Alignment = StringAlignment.Far;
                        if (Core.Config.DisplayConfig.FileNameTextConfig.DrawLocation == Bright.Cores.Config.Display.OverlapText.DrawLocations.LeftBottom ||
                            Core.Config.DisplayConfig.FileNameTextConfig.DrawLocation == Bright.Cores.Config.Display.OverlapText.DrawLocations.RightBottom)
                            sf.LineAlignment = StringAlignment.Far;
                        gp.AddString(drawText,
                            Core.Config.DisplayConfig.FileNameTextConfig.UsingFont.Value.FontFamily,
                            (int)(Core.Config.DisplayConfig.FileNameTextConfig.UsingFont.Value.Style),
                            Core.Config.DisplayConfig.FileNameTextConfig.UsingFont.Value.Size,
                            destination, sf);
                        pe.Graphics.FillPath(Brushes.White, gp);
                        pe.Graphics.DrawPath(Pens.Black, gp);
                    }
                }
            }
            #endregion
            //base.OnPaint(pe);
        }

        #region SupportsGrabbingMove
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (!ZoomPicture &&
                e.Button == MouseButtons.Left && Core.Config.BehaviorConfig.UseHandMoveOnNotZooming)
            {
                this.Cursor = grabCursor;
                prevPoint = e.Location;
            }
            else if (!Core.Config.BehaviorConfig.UseHandMoveOnNotZooming)
            {
                this.Cursor = Cursors.Default;
            }
            base.OnMouseDown(e);
        }

        Point prevPoint = new Point();
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!ZoomPicture &&
                e.Button == MouseButtons.Left && Core.Config.BehaviorConfig.UseHandMoveOnNotZooming)
            {
                Point vector = new Point(prevPoint.X - e.X, prevPoint.Y - e.Y);
                prevPoint = e.Location;
                if (PositionUpdateRequired != null)
                    PositionUpdateRequired(vector);
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (!ZoomPicture &&
                e.Button == MouseButtons.Left && Core.Config.BehaviorConfig.UseHandMoveOnNotZooming)
            {
                this.Cursor = handCursor;
            }
            base.OnMouseUp(e);
        }
        #endregion

    }
}
