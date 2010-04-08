using System.Windows.Forms;

namespace K.Controls
{
    //Scroll.Maximum = SupposedMaximum + Scroll.LargeCange - 1;
    //http://social.msdn.microsoft.com/forums/ja-JP/vbexpressja/thread/ed93e5f5-254c-40bb-bf2e-a871ba6e0f14/

    public class VScrollBarPlus : VScrollBar
    {
        public VScrollBarPlus()
            : base()
        {
            AutoEnabledControl = true;
        }

        private int setMax = 0;
        public new int Maximum
        {
            get { return setMax; }
            set
            {
                setMax = value;
                base.Maximum = setMax + this.LargeChange - 1;
                if (AutoEnabledControl)
                {
                    if (value == 0)
                        this.Enabled = false;
                    else
                        this.Enabled = true;
                }
            }
        }

        public bool AutoEnabledControl { get; set; }
    }

    public class HScrollBarPlus : HScrollBar
    {
        public HScrollBarPlus()
            : base()
        {
            AutoEnabledControl = true;
        }

        private int setMax = 0;
        public new int Maximum
        {
            get { return setMax; }
            set
            {
                setMax = value;
                base.Maximum = setMax + this.LargeChange - 1;
                if (AutoEnabledControl)
                {
                    if (value == 0)
                        this.Enabled = false;
                    else
                        this.Enabled = true;
                }
            }
        }

        public bool AutoEnabledControl { get; set; }
    }
}
