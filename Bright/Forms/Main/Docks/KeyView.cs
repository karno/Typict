using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.Drawing.Drawing2D;

namespace Bright.Forms.Main.Docks
{
    public partial class KeyView : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        protected override string GetPersistString()
        {
            return "keyview";
        }

        const int KeyViewWidth = 30;

        public KeyView()
        {
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            InitializeComponent();
            Core.CurrentOperationUpdated += new Action(Core_CurrentOperationUpdated);
        }

        void Core_CurrentOperationUpdated()
        {
            if (Core.CurrentOperation != null)
                Core.CurrentOperation.Data.DestinationsUpdated += new Action(UpdateKeysList);
            UpdateKeysList();
        }

        public enum KeyViewSortMode { AtoZ, Qwerty, Unknown }
        public KeyViewSortMode GetKVSortMode()
        {
            if (sortByAtoZ.Checked)
                return KeyViewSortMode.AtoZ;
            else
                return KeyViewSortMode.Qwerty;
        }

        private void sortByAtoZ_Click(object sender, EventArgs e)
        {
            sortByAtoZ.Checked = true;
            sortByQwerty.Checked = false;
            UpdateKeysList();
        }

        private void sortByQwerty_Click(object sender, EventArgs e)
        {
            sortByAtoZ.Checked = false;
            sortByQwerty.Checked = true;
            UpdateKeysList();
        }

        private void showFullpath_Click(object sender, EventArgs e)
        {
            keysList.Refresh();
        }

        private void UpdateKeysList()
        {
            keysList.Items.Clear();
            if (Core.CurrentOperation == null)
                return;
            var dests = from key in Core.CurrentOperation.Data.GetDestinationsKeys()
                        select Core.CurrentOperation.Data.GetDestination(key);
            foreach (var d in dests.OrderBy<Data.Destination, Keys>((d) => d.LinkedKey, new KeyListSorter(GetKVSortMode())))
                keysList.Items.Add(d);
        }

        private class KeyListSorter : IComparer<Keys>
        {
            KeyViewSortMode kvsm;
            public KeyListSorter(KeyViewSortMode kvsm)
            {
                this.kvsm = kvsm;
            }
            public Keys[] QwertyArray = new[] { 
                Keys.Q, Keys.W, Keys.E, Keys.R, Keys.T, Keys.Y, Keys.U, Keys.I, Keys.O, Keys.P, 
                Keys.A, Keys.S, Keys.D, Keys.F, Keys.G, Keys.H, Keys.J, Keys.K, Keys.L,
                Keys.Z, Keys.X, Keys.C, Keys.V, Keys.B, Keys.N, Keys.M,
                Keys.D0,Keys.D1,Keys.D2,Keys.D3,Keys.D4,Keys.D5,Keys.D6,Keys.D7,Keys.D8,Keys.D9 };
            public Keys[] AtoZArray = new[] { 
                Keys.A, Keys.B, Keys.C, Keys.D, Keys.E, Keys.F, Keys.G, Keys.H, Keys.I,
                Keys.J, Keys.K, Keys.L, Keys.M, Keys.N, Keys.O, Keys.P, Keys.Q, Keys.R,
                Keys.S, Keys.T, Keys.U, Keys.V, Keys.W, Keys.X, Keys.Y, Keys.Z,
                Keys.D0,Keys.D1,Keys.D2,Keys.D3,Keys.D4,Keys.D5,Keys.D6,Keys.D7,Keys.D8,Keys.D9 };

            //x < y : -1 , x > y : 1, x = y : 0
            public int Compare(Keys x, Keys y)
            {
                bool shiftX = (x & Keys.Shift) == Keys.Shift;
                bool shiftY = (y & Keys.Shift) == Keys.Shift;
                if (shiftX && !shiftY)
                    return 1;
                else if (!shiftX && shiftY)
                    return -1;
                switch (kvsm)
                {
                    case KeyViewSortMode.AtoZ:
                        return Array.IndexOf(AtoZArray, x & ~Keys.Shift) - Array.IndexOf(AtoZArray, y & ~Keys.Shift);
                    case KeyViewSortMode.Qwerty:
                        return Array.IndexOf(QwertyArray, x & ~Keys.Shift) - Array.IndexOf(QwertyArray, y & ~Keys.Shift);
                    default:
                        return x - y;
                }
            }
        }

        private void keysList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
                return;
            if (e.Bounds.Width <= 0 || e.Bounds.Height <= 0)
                return;
            if (e.Index % 2 == 1)
                using (var b = new SolidBrush(Color.FromArgb(235, 235, 255)))
                    e.Graphics.FillRectangle(b, e.Bounds);
            else
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                var rec = e.Bounds;
                rec.Y -= 2;
                rec.Height += 4;
                using (var b = new LinearGradientBrush(rec, 
                    Color.FromArgb(200, Color.RoyalBlue), 
                    Color.FromArgb(160, Color.Navy), 90))
                {
                    e.Graphics.FillRectangle(b, e.Bounds);
                }
            }
            var curItem = keysList.Items[e.Index] as Data.Destination;
            Rectangle keymapRectangle = new Rectangle(e.Bounds.Location, new Size(KeyViewWidth, e.Bounds.Height));
            Rectangle destinationRectangle = new Rectangle(keymapRectangle.Right,
                e.Bounds.Top, e.Bounds.Width - keymapRectangle.Width, e.Bounds.Height);

            using (var b = new SolidBrush(Color.RoyalBlue))
                e.Graphics.FillRectangle(b, keymapRectangle);
            string keyFormat = curItem.LinkedKey.GetString();
            TextRenderer.DrawText(e.Graphics, keyFormat, this.Font, keymapRectangle, Color.White);
            if (showFullpath.Checked)
                TextRenderer.DrawText(e.Graphics, curItem.DestPath, this.Font, destinationRectangle, e.ForeColor,
                    TextFormatFlags.PathEllipsis | TextFormatFlags.Left | TextFormatFlags.NoPrefix | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter);
            else
                TextRenderer.DrawText(e.Graphics, Path.GetFileName(curItem.DestPath), this.Font, destinationRectangle, e.ForeColor,
                    TextFormatFlags.EndEllipsis | TextFormatFlags.Left | TextFormatFlags.NoPrefix | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter);

            e.DrawFocusRectangle();
        }

        private void keyContext_Opening(object sender, CancelEventArgs e)
        {
            if (Core.CurrentOperation == null)
                e.Cancel = true;
            groupThis.Enabled = keysList.SelectedIndices.Count > 0;
            editThisKey.Enabled = keysList.SelectedIndices.Count == 1;
            deleteThisKey.Enabled = keysList.SelectedIndices.Count > 0;
            AddNewKey.Enabled = keysList.Items.Count < 72;
        }

        private void groupThis_Click(object sender, EventArgs e)
        {
            if (keysList.SelectedIndices.Count <= 0)
                return;
            var elem = Core.CurrentOperation.GetCurrentElement();
            if (elem == null)
                return;
            elem.Destinations.Clear();
            foreach (var i in keysList.SelectedIndices)
            {
                var item = keysList.Items[((int)i)] as Data.Destination;
                elem.Destinations.Add(new Bright.Data.GroupingElement.DestData(item));
            }

            elem.DistributionMode = Core.DistributionMode;
            Core.CurrentOperation.SetNext();
        }

        private void editThisKey_Click(object sender, EventArgs e)
        {
            if (keysList.SelectedIndex == -1)
                return;
            var item = keysList.Items[keysList.SelectedIndex] as Data.Destination;
            if (item != null)
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "選択中のキーに新しく設定するフォルダーを選択してください。";
                    fbd.RootFolder = Environment.SpecialFolder.Desktop;
                    fbd.SelectedPath = item.DestPath;
                    if (fbd.ShowDialog() == DialogResult.OK)
                        item.SetDestPathWithOverwriteConfirm(fbd.SelectedPath);
                    UpdateKeysList();
                }
            }
        }

        private void deleteThisKey_Click(object sender, EventArgs e)
        {
            if (keysList.SelectedIndices.Count <= 0)
                return;
            foreach (var i in keysList.SelectedIndices)
            {
                var item = keysList.Items[((int)i)] as Data.Destination;
                Core.CurrentOperation.Data.RemoveDestination(item.LinkedKey);
            }
        }

        private void AddNewKey_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.RootFolder = Environment.SpecialFolder.Desktop;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    fbd.Description = "追加するフォルダーを選択してください。";
                    List<Keys> cand = new List<Keys>();
                    var dks = Core.CurrentOperation.Data.GetDestinationsKeys();
                    for (int initPoint = (int)Keys.D0; initPoint <= (int)Keys.D9; initPoint++)
                    {
                        if (!dks.Contains<Keys>((Keys)initPoint))
                            cand.Add((Keys)initPoint);
                        if (!dks.Contains<Keys>((Keys)initPoint | Keys.Shift))
                            cand.Add((Keys)initPoint | Keys.Shift);
                    }
                    for (int initPoint = (int)Keys.A; initPoint <= (int)Keys.Z; initPoint++)
                    {
                        if (!dks.Contains<Keys>((Keys)initPoint))
                            cand.Add((Keys)initPoint);
                        if (!dks.Contains<Keys>((Keys)initPoint | Keys.Shift))
                            cand.Add((Keys)initPoint | Keys.Shift);
                    }

                    using (var ak = new Dialogs.AddKey(cand.ToArray()))
                    {
                        if (ak.ShowDialog() == DialogResult.OK)
                        {
                            Core.CurrentOperation.Data.AddDestination(ak.Selected,
                                new Bright.Data.Destination(ak.Selected, fbd.SelectedPath));
                        }
                    }
                }
            }
        }

        private void setWithFolder_Click(object sender, EventArgs e)
        {
            if(Core.CurrentOperation == null)
                return;
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.RootFolder = Environment.SpecialFolder.Desktop;
                fbd.Description = "追加するフォルダーを選択してください。";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var ksetup = new Dialogs.KeySetup(fbd.SelectedPath))
                        {
                            ksetup.SetMapping(Core.CurrentOperation.Data.GetDestinationsKeys().ToArray<Keys>());
                            if (ksetup.ShowDialog() == DialogResult.OK)
                            {
                                var map = ksetup.MappingTable;
                                foreach (var kmp in map.Keys)
                                {
                                    if (String.IsNullOrEmpty(map[kmp]))
                                        continue;
                                    if (Core.CurrentOperation.Data.IsDestinationExists(kmp))
                                        Core.CurrentOperation.Data.GetDestination(kmp).SetDestPathWithOverwriteConfirm(map[kmp]);
                                    else
                                        Core.CurrentOperation.Data.AddDestination(kmp, new Bright.Data.Destination(kmp, map[kmp]));
                                }
                                UpdateKeysList();
                            }
                        }
                    }
                    catch (UnauthorizedAccessException) { }
                }
            }
        }

        private void keysList_DoubleClick(object sender, EventArgs e)
        {
            switch (Core.Config.BehaviorConfig.KeyListEvent)
            {
                case Bright.Cores.Config.Behavior.KeyListEvents.SetDestination:
                    groupThis_Click(sender, e);
                    break;
                case Bright.Cores.Config.Behavior.KeyListEvents.EditDestination:
                    editThisKey_Click(sender, e);
                    break;
            }
        }

    }
}
