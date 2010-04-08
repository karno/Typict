using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bright.Forms.Config.Pages
{
    public partial class Behavior : Bright.Forms.Config.ConfigPage
    {
        public Behavior()
        {
            InitializeComponent();
        }

        public override string Description
        {
            get
            {
                return "動作";
            }
        }

        private void Behavior_Load(object sender, EventArgs e)
        {
            UseHandMoveOnNotZooming.Checked = Core.Config.BehaviorConfig.UseHandMoveOnNotZooming;
            KeyDoubleTypeToRegistNew.Checked = Core.Config.BehaviorConfig.KeyDoubleTypeToRegistNew;
            RememberPreviousOperationConfig.Checked = Core.Config.BehaviorConfig.RememberPreviousOperationConfig;
            KeyListEvent.SelectedIndex = (int)Core.Config.BehaviorConfig.KeyListEvent;
            BackupInterval.Value = Core.Config.BehaviorConfig.BackupInterval;
            ClearDestOnBack.Checked = Core.Config.BehaviorConfig.ClearDestOnBack;
        }

        protected override void OnAccepted()
        {
            Core.Config.BehaviorConfig.UseHandMoveOnNotZooming = UseHandMoveOnNotZooming.Checked;
            Core.Config.BehaviorConfig.RememberPreviousOperationConfig = RememberPreviousOperationConfig.Checked;
            Core.Config.BehaviorConfig.KeyDoubleTypeToRegistNew = KeyDoubleTypeToRegistNew.Checked;
            Core.Config.BehaviorConfig.KeyListEvent = (Bright.Cores.Config.Behavior.KeyListEvents)KeyListEvent.SelectedIndex;
            Core.Config.BehaviorConfig.BackupInterval = (int)BackupInterval.Value;
            Core.Config.BehaviorConfig.ClearDestOnBack = ClearDestOnBack.Checked;
        }
    }
}
