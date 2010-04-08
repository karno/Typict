using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bright.Forms.Main.Docks.OpView
{
    public partial class ElementList : Control
    {
        public ElementList()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.StandardClick, true);
            this.SetStyle(ControlStyles.ContainerControl, false);
            this.Resize += new EventHandler(ElementList_Resize);
        }

        public Size ItemSize = new Size(40, 40);
        public int ItemMargin = 1;
        private int ItemDirectionalSize
        {
            get
            {
                if (HorizontalMode)
                    return ItemSize.Width + ItemMargin;
                else
                    return ItemSize.Height + ItemMargin;
            }
        }

        private int offsetPosition = 0;
        public int OffsetPosition
        {
            get { return offsetPosition; }
            set
            {
                offsetPosition = value;
                this.Refresh();
            }
        }

        public int GetScrollValue(int index)
        {
            return index * ItemDirectionalSize;
        }

        public void ApplyScrollByIndex(int index)
        {
            OffsetPosition = GetScrollValue(index);
        }

        public bool HorizontalMode = false;

        void ElementList_Resize(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private int DirectionSize { get { return HorizontalMode ? this.Width : this.Height; } }
        private int NoDirectionSize { get { return HorizontalMode ? this.Height : this.Width; } }

        private int selectedIndex = -1;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                Refresh();
            }
        }

        public bool IsVisible(int index)
        {
            if ((index + 1) * ItemDirectionalSize < OffsetPosition)
                return false;
            if (index * ItemDirectionalSize > OffsetPosition + DirectionSize)
                return false;
            return true;
        }

        public event DrawItemEventHandler DrawItem;
        public event DrawItemEventHandler DrawItemHorizontal;

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.FillRectangle(Brushes.White, this.ClientRectangle);
            int startPoint = -(offsetPosition % ItemDirectionalSize);
            Rectangle area = new Rectangle();
            for (int index = offsetPosition / ItemDirectionalSize;
                startPoint < OffsetPosition + DirectionSize;
                index++)
            {
                System.Diagnostics.Debug.WriteLine(index);
                if (HorizontalMode)
                {
                    area = new Rectangle(startPoint, 0, ItemDirectionalSize, this.Height);
                    if (DrawItemHorizontal != null)
                        DrawItemHorizontal.Invoke(this, new DrawItemEventArgs(
                            pe.Graphics, this.Font,
                            area, index, SelectedIndex == index ? DrawItemState.Selected : DrawItemState.None));
                }
                else
                {
                    area = new Rectangle(0, startPoint, this.Width, ItemDirectionalSize);
                    if (DrawItem != null)
                        DrawItem.Invoke(this, new DrawItemEventArgs(
                            pe.Graphics, this.Font,
                            area, index, SelectedIndex == index ? DrawItemState.Selected : DrawItemState.None));
                }
                startPoint += ItemDirectionalSize;
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (HorizontalMode)
            {
                this.SelectedIndex = (OffsetPosition + e.X) / ItemDirectionalSize;
            }
            else
            {
                this.SelectedIndex = (OffsetPosition + e.Y) / ItemDirectionalSize;
            }
            base.OnMouseClick(e);
        }
    }
}
