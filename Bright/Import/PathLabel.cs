using System;
using System.Drawing;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;

namespace K.Controls
{
    public class PathLabel : Label
    {
        public PathLabel()
        {
            //InitializeComponent();
        }

        public override bool AutoSize
        {
            get { return false; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            RectangleF rect = new RectangleF(ClientRectangle.X,
                                         ClientRectangle.Y,
                                         ClientRectangle.Width,
                                         ClientRectangle.Height);
            e.Graphics.DrawString(
                AdjustPathString(e.Graphics, this.Text),
                Font, new SolidBrush(ForeColor), rect
            );
        }

        private string AdjustPathString(Graphics grx, string text)
        {
            SizeF size = grx.MeasureString(text, this.Font);
            while (this.Size.Width < size.Width)
            {
                string text2 = ShortenPathString(text);
                if (text == text2)
                    break;
                size = grx.MeasureString(text2, this.Font);
                text = text2;
            }

            return text;
        }

        private string ShortenPathString(string text)
        {
            List<string> list = new List<string>(text.Split('\\'));
            int i = list.Count / 2;
            if (list[i] != "...")
            {
                list[i] = "...";
            }
            else
            {
                if (list.Count % 2 == 0 && i > 1)
                    list.RemoveAt(i - 1);
                else if (list.Count % 2 == 1 && i < list.Count - 2)
                    list.RemoveAt(i + 1);
            }

            StringBuilder sb = new StringBuilder(list[0]);
            for (int n = 1; n < list.Count; n++)
            {
                sb.Append('\\').Append(list[n]);
            }
            return sb.ToString();
        }
    }
}
