namespace Bright.Forms.Main.Docks
{
    partial class OperationView
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperationView));
            this.opvContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moveToSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteGrouping = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.listHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.elemList = new Bright.Forms.Main.Docks.OpView.ElementList();
            this.vertScroll = new K.Controls.VScrollBarPlus();
            this.horzScroll = new K.Controls.HScrollBarPlus();
            this.opvContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // opvContext
            // 
            this.opvContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveToSelected,
            this.deleteGrouping,
            this.toolStripMenuItem1,
            this.listHorizontal});
            this.opvContext.Name = "opvContext";
            this.opvContext.Size = new System.Drawing.Size(263, 76);
            this.opvContext.Opening += new System.ComponentModel.CancelEventHandler(this.opvContext_Opening);
            // 
            // moveToSelected
            // 
            this.moveToSelected.Name = "moveToSelected";
            this.moveToSelected.Size = new System.Drawing.Size(262, 22);
            this.moveToSelected.Text = "選択中のアイテムに移動する(&M)";
            this.moveToSelected.Click += new System.EventHandler(this.moveToSelected_Click);
            // 
            // deleteGrouping
            // 
            this.deleteGrouping.Name = "deleteGrouping";
            this.deleteGrouping.Size = new System.Drawing.Size(262, 22);
            this.deleteGrouping.Text = "このアイテムの割り当てを削除(&R)";
            this.deleteGrouping.Click += new System.EventHandler(this.deleteGrouping_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(259, 6);
            // 
            // listHorizontal
            // 
            this.listHorizontal.CheckOnClick = true;
            this.listHorizontal.Name = "listHorizontal";
            this.listHorizontal.Size = new System.Drawing.Size(262, 22);
            this.listHorizontal.Text = "リストを左右方向にする(&H)";
            this.listHorizontal.Click += new System.EventHandler(this.listHorizontal_Click);
            // 
            // elemList
            // 
            this.elemList.ContextMenuStrip = this.opvContext;
            this.elemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elemList.Location = new System.Drawing.Point(0, 0);
            this.elemList.Name = "elemList";
            this.elemList.OffsetPosition = 0;
            this.elemList.SelectedIndex = -1;
            this.elemList.Size = new System.Drawing.Size(267, 319);
            this.elemList.TabIndex = 1;
            this.elemList.Text = "opList";
            this.elemList.DrawItemHorizontal += new System.Windows.Forms.DrawItemEventHandler(this.elemList_DrawItemHorizontal);
            this.elemList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.elemList_DrawItem);
            // 
            // vertScroll
            // 
            this.vertScroll.AutoEnabledControl = true;
            this.vertScroll.Dock = System.Windows.Forms.DockStyle.Right;
            this.vertScroll.Location = new System.Drawing.Point(267, 0);
            this.vertScroll.Maximum = 0;
            this.vertScroll.Name = "vertScroll";
            this.vertScroll.Size = new System.Drawing.Size(17, 336);
            this.vertScroll.TabIndex = 2;
            this.vertScroll.ValueChanged += new System.EventHandler(this.scroll_ValueChanged);
            // 
            // horzScroll
            // 
            this.horzScroll.AutoEnabledControl = true;
            this.horzScroll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.horzScroll.Location = new System.Drawing.Point(0, 319);
            this.horzScroll.Maximum = 0;
            this.horzScroll.Name = "horzScroll";
            this.horzScroll.Size = new System.Drawing.Size(267, 17);
            this.horzScroll.TabIndex = 3;
            this.horzScroll.Visible = false;
            this.horzScroll.ValueChanged += new System.EventHandler(this.scroll_ValueChanged);
            // 
            // OperationView
            // 
            this.ClientSize = new System.Drawing.Size(284, 336);
            this.Controls.Add(this.elemList);
            this.Controls.Add(this.horzScroll);
            this.Controls.Add(this.vertScroll);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OperationView";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.Text = "オペレーション ビュー";
            this.Load += new System.EventHandler(this.OperationView_Load);
            this.opvContext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip opvContext;
        private System.Windows.Forms.ToolStripMenuItem moveToSelected;
        private System.Windows.Forms.ToolStripMenuItem deleteGrouping;
        private Bright.Forms.Main.Docks.OpView.ElementList elemList;
        private K.Controls.VScrollBarPlus vertScroll;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem listHorizontal;
        private K.Controls.HScrollBarPlus horzScroll;

    }
}
