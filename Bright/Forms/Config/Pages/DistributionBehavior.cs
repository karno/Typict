using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bright.Forms.Config.Pages
{
    public partial class DistributionBehavior : Bright.Forms.Config.ConfigPage
    {
        public DistributionBehavior()
        {
            InitializeComponent();
        }

        public override string Description
        {
            get { return "振り分け"; }
        }

        private void DistributionBehavior_Load(object sender, EventArgs e)
        {
            WaitExternalApp.Checked = Core.Config.BehaviorConfig.WaitExternalApp;
            WaitExternalAppIdling.Checked = Core.Config.BehaviorConfig.WaitExternalAppIdling;
            MultiCopyTreatsReference.Checked = Core.Config.BehaviorConfig.MultiCopyTreatsReference;
        }

        protected override void OnAccepted()
        {
            Core.Config.BehaviorConfig.WaitExternalApp = WaitExternalApp.Checked;
            Core.Config.BehaviorConfig.WaitExternalAppIdling = WaitExternalAppIdling.Checked;
            Core.Config.BehaviorConfig.MultiCopyTreatsReference = MultiCopyTreatsReference.Checked;
        }

        private void WaitExternalApp_CheckedChanged(object sender, EventArgs e)
        {
            if (WaitExternalApp.Checked)
                WaitExternalAppIdling.Checked = false;
        }

        private void WaitExternalAppIdling_CheckedChanged(object sender, EventArgs e)
        {
            if (WaitExternalAppIdling.Checked)
                WaitExternalApp.Checked = false;
        }
    }
}
