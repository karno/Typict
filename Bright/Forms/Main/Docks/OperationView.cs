using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace Bright.Forms.Main.Docks
{
    public partial class OperationView : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        protected override string GetPersistString()
        {
            return "operationview";
        }

        public OperationView()
        {
            InitializeComponent();
            elemList.ItemSize = Core.Config.DisplayConfig.ThumbnailSize;
            elemList.ItemMargin = 4;
            this.Resize += new EventHandler(OperationView_Resize);
        }

        void OperationView_Resize(object sender, EventArgs e)
        {
            this.UpdateScroll();
        }

        private void OperationView_Load(object sender, EventArgs e)
        {
            if (Core.Config.StateConfig.HorizontalOpView)
            {
                listHorizontal.Checked = true;
                listHorizontal_Click(null, null);
            }
            Core.CurrentOperationUpdated += new Action(Core_CurrentOperationUpdated);
            Subsystem.Prefetch.Instance.PrefetchThumbnailCompleted += new Action<Bright.Data.GroupingElement>(Instance_PrefetchThumbnailCompleted);
        }

        void Core_CurrentOperationUpdated()
        {
            if (Core.CurrentOperation != null)
            {
                Core.CurrentOperation.IndexUpdated += new Action(CurrentOperation_IndexUpdated);
                Core.CurrentOperation.Data.ElementsUpdated += new Action(Data_ElementsUpdated);
            }
            Data_ElementsUpdated();
        }

        void Data_ElementsUpdated()
        {
            UpdateScroll();
            Refresh();
        }

        void UpdateScroll()
        {
            if (Core.CurrentOperation == null)
            {
                horzScroll.Enabled = false;
                vertScroll.Enabled = false;
            }
            else
            {
                vertScroll.Enabled = true;
                horzScroll.Enabled = true;
                if (vertScroll.Visible)
                {
                    vertScroll.Maximum = (Core.Config.DisplayConfig.ThumbnailSize.Height + elemList.ItemMargin) * Core.CurrentOperation.Data.ElementsLength - elemList.Height;
                    if (vertScroll.Maximum < 0)
                    {
                        vertScroll.Maximum = 0;
                        vertScroll.Value = 0;
                        vertScroll.Enabled = false;
                    }
                    else
                    {
                        vertScroll.Enabled = true;
                        if (vertScroll.Value > vertScroll.Maximum)
                            vertScroll.Value = vertScroll.Maximum;
                    }
                }
                else
                {
                    horzScroll.Maximum = (Core.Config.DisplayConfig.ThumbnailSize.Width + elemList.ItemMargin) * Core.CurrentOperation.Data.ElementsLength - elemList.Width;
                    if (horzScroll.Maximum < 0)
                    {
                        horzScroll.Maximum = 0;
                        horzScroll.Value = 0;
                        horzScroll.Enabled = false;
                    }
                    else
                    {
                        horzScroll.Enabled = true;
                        if (horzScroll.Value > horzScroll.Maximum)
                            horzScroll.Value = horzScroll.Maximum;
                    }
                }
            }
        }

        void CurrentOperation_IndexUpdated()
        {
            int tidx = Core.CurrentOperation.Index - 1;
            if (tidx < 0)
                tidx = 0;
            int nval = elemList.GetScrollValue(tidx);
            if (vertScroll.Visible)
            {
                if (nval > vertScroll.Maximum)
                {
                    nval = vertScroll.Maximum;
                    elemList.OffsetPosition = nval;
                }
                vertScroll.Value = nval;
            }
            else
            {
                if (nval > horzScroll.Maximum)
                {
                    nval = horzScroll.Maximum;
                    elemList.OffsetPosition = nval;
                }
                horzScroll.Value = nval;
            }
            this.Refresh();
        }

        void Instance_PrefetchThumbnailCompleted(Bright.Data.GroupingElement obj)
        {
            try
            {
                if (Core.CurrentOperation != null &&
                    elemList.IsVisible(Core.CurrentOperation.Data.IndexOfElement(obj)))
                {
                    this.Invoke(new Action(() => this.Refresh()));
                }
            }
            catch (InvalidOperationException) { }
        }

        volatile bool refreshing = false;
        volatile bool queueing = false;
        public override void Refresh()
        {
            if (refreshing)
            {
                queueing = true;
                return;
            }
            refreshing = true;
            do
            {
                queueing = false;
                base.Refresh();
                Application.DoEvents();
            } while (queueing);
            refreshing = false;
        }

        private void opvContext_Opening(object sender, CancelEventArgs e)
        {
            if (Core.CurrentOperation == null || elemList.SelectedIndex < 0)
            {
                moveToSelected.Enabled = false;
                deleteGrouping.Enabled = false;
            }
            else
            {
                moveToSelected.Enabled = true;
                deleteGrouping.Enabled = Core.CurrentOperation.Data.GetElement(elemList.SelectedIndex).IsGrouped;
            }
        }

        private void moveToSelected_Click(object sender, EventArgs e)
        {
            Core.CurrentOperation.SetIndex(elemList.SelectedIndex);
        }

        private void deleteGrouping_Click(object sender, EventArgs e)
        {
            Core.CurrentOperation.Data.GetElement(elemList.SelectedIndex).Destinations.Clear();
            this.Refresh();
        }

        private void scroll_ValueChanged(object sender, EventArgs e)
        {
            if (vertScroll.Visible)
                elemList.OffsetPosition = vertScroll.Value;
            else
                elemList.OffsetPosition = horzScroll.Value;
        }

        private void listHorizontal_Click(object sender, EventArgs e)
        {
            elemList.HorizontalMode = listHorizontal.Checked;
            vertScroll.Visible = !listHorizontal.Checked;
            horzScroll.Visible = listHorizontal.Checked;
            UpdateScroll();
            Core.Config.StateConfig.HorizontalOpView = listHorizontal.Checked;
            elemList.Refresh();
        }

        private void elemList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (Core.CurrentOperation == null)
                return;
            if (e.Index >= Core.CurrentOperation.Data.ElementsLength)
                return;
            if (e.Index < 0)
                return;
            var item = Core.CurrentOperation.Data.GetElement(e.Index);
            Rectangle dest = e.Bounds;
            if (e.Index == Core.CurrentOperation.Index)
                e.Graphics.FillRectangle(Brushes.Orange, e.Bounds);
            else if (e.Index % 2 == 0)
                e.Graphics.FillRectangle(Brushes.Gainsboro, e.Bounds);
            else
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e.Graphics.FillRectangle(Brushes.RoyalBlue, e.Bounds);
            if (item.IsThumbnailBuffered)
            {
                if (!item.BILocking)
                    e.Graphics.DrawImage(item.BufferedThumbnail, new Rectangle(new Point(dest.X + 2, dest.Y + 2), Core.Config.DisplayConfig.ThumbnailSize));
                dest.X = Core.Config.DisplayConfig.ThumbnailSize.Width + 4;
                dest.Width -= dest.X;
            }
            TextRenderer.DrawText(e.Graphics, item.ImageSourcePath, this.Font, dest, e.ForeColor,
                 TextFormatFlags.PathEllipsis | TextFormatFlags.Left | TextFormatFlags.NoPrefix | TextFormatFlags.SingleLine | TextFormatFlags.Top);
            if (!String.IsNullOrEmpty(item.NewName))
            {
                dest.Y += TextRenderer.MeasureText(item.ImageSourcePath, this.Font).Height;
                TextRenderer.DrawText(e.Graphics, "->" + item.NewName, this.Font, dest, Color.ForestGreen,
                     TextFormatFlags.PathEllipsis | TextFormatFlags.Left | TextFormatFlags.NoPrefix | TextFormatFlags.SingleLine | TextFormatFlags.Top);
                dest.Y = e.Bounds.Top;
            }
            if (item.IsGrouped)
            {
                var dds = from d in item.Destinations
                          select d.Destination;
                var ta = dds.ToArray<string>();
                var str = String.Join(",", ta);
                if (ta.Length > 1)
                    TextRenderer.DrawText(e.Graphics, "(" + ta.Length.ToString() + ")>" + str, this.Font, dest, e.ForeColor,
                         TextFormatFlags.PathEllipsis | TextFormatFlags.Left | TextFormatFlags.NoPrefix | TextFormatFlags.SingleLine | TextFormatFlags.Bottom);
                else
                    TextRenderer.DrawText(e.Graphics, ">" + str, this.Font, dest, e.ForeColor,
                         TextFormatFlags.PathEllipsis | TextFormatFlags.Left | TextFormatFlags.NoPrefix | TextFormatFlags.SingleLine | TextFormatFlags.Bottom);
            }
        }

        private void elemList_DrawItemHorizontal(object sender, DrawItemEventArgs e)
        {
            if (Core.CurrentOperation == null)
                return;
            if (e.Index < 0)
                return;
            if (e.Index >= Core.CurrentOperation.Data.ElementsLength)
                return;
            var item = Core.CurrentOperation.Data.GetElement(e.Index);
            Rectangle dest = e.Bounds;
            if (e.Index == Core.CurrentOperation.Index)
                e.Graphics.FillRectangle(Brushes.Orange, e.Bounds);
            else if (e.Index % 2 == 0)
                e.Graphics.FillRectangle(Brushes.Gainsboro, e.Bounds);
            else
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e.Graphics.FillRectangle(Brushes.RoyalBlue, e.Bounds);
            if (item.IsThumbnailBuffered)
            {
                if (!item.BILocking)
                    e.Graphics.DrawImage(item.BufferedThumbnail, new Rectangle(new Point(dest.X + 2, dest.Y + 2), Core.Config.DisplayConfig.ThumbnailSize));
                dest.Y = Core.Config.DisplayConfig.ThumbnailSize.Height + 4;
                dest.Height -= dest.Y;
            }
            using (var sf = new StringFormat(StringFormatFlags.DirectionVertical | StringFormatFlags.NoWrap))
            {
                using (var fb = new SolidBrush(e.ForeColor))
                {
                    sf.LineAlignment = StringAlignment.Far;
                    e.Graphics.DrawString(item.ImageSourcePath, this.Font, fb, (RectangleF)dest, sf);

                    if (!String.IsNullOrEmpty(item.NewName))
                    {
                        dest.Width -= (int)e.Graphics.MeasureString(item.ImageSourcePath, this.Font).Height;
                        using (var b = new SolidBrush(Color.ForestGreen))
                            e.Graphics.DrawString(item.ImageSourcePath, this.Font, b, (RectangleF)dest, sf);
                    }
                    sf.LineAlignment = StringAlignment.Near;
                    if (item.IsGrouped)
                    {
                        var dds = from d in item.Destinations
                                  select d.Destination;
                        var ta = dds.ToArray<string>();
                        var str = String.Join(",", ta);
                        if (ta.Length > 1)
                            str = "(" + ta.Length.ToString() + ")>" + str;
                        e.Graphics.DrawString(str, this.Font, fb, (RectangleF)dest, sf);
                    }
                }
            }
        }
    }
}
