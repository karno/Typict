using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bright.Forms.Config.Pages
{
    public partial class Prefetch : Bright.Forms.Config.ConfigPage
    {
        public Prefetch()
        {
            InitializeComponent();
        }

        public override string Description
        {
            get
            {
                return "先読み";
            }
        }

        private void Prefetch_Load(object sender, EventArgs e)
        {
            EnablePrefetch.Checked = Core.Config.BehaviorConfig.PrefetchConfig.EnablePrefetch;
            PrefetchLength.Value = Core.Config.BehaviorConfig.PrefetchConfig.PrefetchLength;
            PrefetchKeepMaximum.Value = Core.Config.BehaviorConfig.PrefetchConfig.PrefetchKeepMaximum;
            EnableThumbnailPrefetch.Checked = Core.Config.BehaviorConfig.PrefetchConfig.EnableThumbnailPrefetch;
            ThumbnailPrefetchLength.Value = Core.Config.BehaviorConfig.PrefetchConfig.ThumbnailPrefetchLength;
            ThumbnailKeepMaximum.Value = Core.Config.BehaviorConfig.PrefetchConfig.ThumbnailKeepMaximum;
            KeepAllThumbnail.Checked = Core.Config.BehaviorConfig.PrefetchConfig.KeepAllThumbnail;
            PrefetchAllThumbnail.Checked = Core.Config.BehaviorConfig.PrefetchConfig.PrefetchAllThumbnail;
            prefetchDetal.Enabled = EnablePrefetch.Checked;
        }

        private void EnablePrefetch_CheckedChanged(object sender, EventArgs e)
        {
            prefetchDetal.Enabled = EnablePrefetch.Checked;
        }

        private void EnableThumbnailPrefetch_CheckedChanged(object sender, EventArgs e)
        {
            thumbPrefetchDetail.Enabled = EnableThumbnailPrefetch.Checked;
        }

        private void KeepAllThumbnail_CheckedChanged(object sender, EventArgs e)
        {
            ThumbnailKeepMaximum.Enabled = !KeepAllThumbnail.Checked;
        }

        private void PrefetchAllThumbnail_CheckedChanged(object sender, EventArgs e)
        {
            ThumbnailPrefetchLength.Enabled = !PrefetchAllThumbnail.Checked;
            ThumbnailKeepMaximum.Enabled = !PrefetchAllThumbnail.Checked;
            KeepAllThumbnail.Enabled = !PrefetchAllThumbnail.Checked;
            if (PrefetchAllThumbnail.Checked)
                KeepAllThumbnail.Checked = true;
        }

        protected override void OnAccepted()
        {
            Core.Config.BehaviorConfig.PrefetchConfig.EnablePrefetch = EnablePrefetch.Checked;
            Core.Config.BehaviorConfig.PrefetchConfig.EnableThumbnailPrefetch = EnableThumbnailPrefetch.Checked;
            Core.Config.BehaviorConfig.PrefetchConfig.KeepAllThumbnail = KeepAllThumbnail.Checked;
            Core.Config.BehaviorConfig.PrefetchConfig.PrefetchAllThumbnail = PrefetchAllThumbnail.Checked;
            Core.Config.BehaviorConfig.PrefetchConfig.PrefetchKeepMaximum = (int)PrefetchKeepMaximum.Value;
            Core.Config.BehaviorConfig.PrefetchConfig.PrefetchLength = (int)PrefetchLength.Value;
            Core.Config.BehaviorConfig.PrefetchConfig.ThumbnailKeepMaximum = (int)ThumbnailKeepMaximum.Value;
            Core.Config.BehaviorConfig.PrefetchConfig.ThumbnailPrefetchLength = (int)ThumbnailKeepMaximum.Value;
        }
    }
}
