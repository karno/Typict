using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bright.Forms.Config
{
    public partial class ConfigPage : UserControl
    {
        public ConfigPage()
        {
            InitializeComponent();
        }

        public virtual string Description { get { return String.Empty; } }

        public override string ToString()
        {
            return this.Text;
        }

        private bool loaded = false;
        protected sealed override void OnLoad(EventArgs e)
        {
            loaded = true;
            base.OnLoad(e);
        }

        public void CallAccept()
        {
            if (loaded)
                OnAccepted();
        }

        protected virtual void OnAccepted() { }
    }
}
