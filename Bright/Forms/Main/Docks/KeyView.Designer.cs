namespace Bright.Forms.Main.Docks
{
    partial class KeyView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeyView));
            this.kfvTool = new System.Windows.Forms.ToolStrip();
            this.sortByAtoZ = new System.Windows.Forms.ToolStripButton();
            this.sortByQwerty = new System.Windows.Forms.ToolStripButton();
            this.showFullpath = new System.Windows.Forms.ToolStripButton();
            this.keysList = new System.Windows.Forms.ListBox();
            this.keyContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupThis = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.editThisKey = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteThisKey = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.AddNewKey = new System.Windows.Forms.ToolStripMenuItem();
            this.setWithFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.kfvTool.SuspendLayout();
            this.keyContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // kfvTool
            // 
            this.kfvTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sortByAtoZ,
            this.sortByQwerty,
            this.showFullpath});
            this.kfvTool.Location = new System.Drawing.Point(0, 0);
            this.kfvTool.Name = "kfvTool";
            this.kfvTool.Size = new System.Drawing.Size(273, 25);
            this.kfvTool.TabIndex = 0;
            this.kfvTool.Text = "toolStrip1";
            // 
            // sortByAtoZ
            // 
            this.sortByAtoZ.Checked = true;
            this.sortByAtoZ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sortByAtoZ.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sortByAtoZ.Image = global::Bright.Properties.Resources.sort;
            this.sortByAtoZ.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sortByAtoZ.Name = "sortByAtoZ";
            this.sortByAtoZ.Size = new System.Drawing.Size(23, 22);
            this.sortByAtoZ.Text = "A→Zでソート";
            this.sortByAtoZ.Click += new System.EventHandler(this.sortByAtoZ_Click);
            // 
            // sortByQwerty
            // 
            this.sortByQwerty.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sortByQwerty.Image = global::Bright.Properties.Resources.sort_qwerty;
            this.sortByQwerty.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sortByQwerty.Name = "sortByQwerty";
            this.sortByQwerty.Size = new System.Drawing.Size(23, 22);
            this.sortByQwerty.Text = "QWERTYでソート";
            this.sortByQwerty.Click += new System.EventHandler(this.sortByQwerty_Click);
            // 
            // showFullpath
            // 
            this.showFullpath.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.showFullpath.CheckOnClick = true;
            this.showFullpath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showFullpath.Image = global::Bright.Properties.Resources.drive_magnify;
            this.showFullpath.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showFullpath.Name = "showFullpath";
            this.showFullpath.Size = new System.Drawing.Size(23, 22);
            this.showFullpath.Text = "フルパスを表示";
            this.showFullpath.Click += new System.EventHandler(this.showFullpath_Click);
            // 
            // keysList
            // 
            this.keysList.ContextMenuStrip = this.keyContext;
            this.keysList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keysList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.keysList.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.keysList.FormattingEnabled = true;
            this.keysList.IntegralHeight = false;
            this.keysList.ItemHeight = 18;
            this.keysList.Location = new System.Drawing.Point(0, 25);
            this.keysList.Name = "keysList";
            this.keysList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.keysList.Size = new System.Drawing.Size(273, 299);
            this.keysList.TabIndex = 1;
            this.keysList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.keysList_DrawItem);
            this.keysList.DoubleClick += new System.EventHandler(this.keysList_DoubleClick);
            // 
            // keyContext
            // 
            this.keyContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.groupThis,
            this.toolStripMenuItem1,
            this.editThisKey,
            this.deleteThisKey,
            this.toolStripMenuItem2,
            this.AddNewKey,
            this.setWithFolder});
            this.keyContext.Name = "keyContext";
            this.keyContext.Size = new System.Drawing.Size(274, 126);
            this.keyContext.Opening += new System.ComponentModel.CancelEventHandler(this.keyContext_Opening);
            // 
            // groupThis
            // 
            this.groupThis.Image = global::Bright.Properties.Resources.run;
            this.groupThis.Name = "groupThis";
            this.groupThis.Size = new System.Drawing.Size(273, 22);
            this.groupThis.Text = "選択中のキーへ振り分ける(&G)";
            this.groupThis.Click += new System.EventHandler(this.groupThis_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(270, 6);
            // 
            // editThisKey
            // 
            this.editThisKey.Image = global::Bright.Properties.Resources.keywnd;
            this.editThisKey.Name = "editThisKey";
            this.editThisKey.Size = new System.Drawing.Size(273, 22);
            this.editThisKey.Text = "選択中のキーの設定パスを編集(&E)...";
            this.editThisKey.Click += new System.EventHandler(this.editThisKey_Click);
            // 
            // deleteThisKey
            // 
            this.deleteThisKey.Image = global::Bright.Properties.Resources.delete;
            this.deleteThisKey.Name = "deleteThisKey";
            this.deleteThisKey.Size = new System.Drawing.Size(273, 22);
            this.deleteThisKey.Text = "選択中のキーを削除(&D)...";
            this.deleteThisKey.Click += new System.EventHandler(this.deleteThisKey_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(270, 6);
            // 
            // AddNewKey
            // 
            this.AddNewKey.Name = "AddNewKey";
            this.AddNewKey.Size = new System.Drawing.Size(273, 22);
            this.AddNewKey.Text = "新しいキーを追加(&A)...";
            this.AddNewKey.Click += new System.EventHandler(this.AddNewKey_Click);
            // 
            // setWithFolder
            // 
            this.setWithFolder.Image = global::Bright.Properties.Resources.openf;
            this.setWithFolder.Name = "setWithFolder";
            this.setWithFolder.Size = new System.Drawing.Size(273, 22);
            this.setWithFolder.Text = "フォルダーを選択して割り当て(&S)";
            this.setWithFolder.Click += new System.EventHandler(this.setWithFolder_Click);
            // 
            // KeyView
            // 
            this.ClientSize = new System.Drawing.Size(273, 324);
            this.Controls.Add(this.keysList);
            this.Controls.Add(this.kfvTool);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KeyView";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRight;
            this.Text = "キー/フォルダー ビュー";
            this.kfvTool.ResumeLayout(false);
            this.kfvTool.PerformLayout();
            this.keyContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip kfvTool;
        private System.Windows.Forms.ToolStripButton sortByAtoZ;
        private System.Windows.Forms.ToolStripButton sortByQwerty;
        private System.Windows.Forms.ToolStripButton showFullpath;
        private System.Windows.Forms.ListBox keysList;
        private System.Windows.Forms.ContextMenuStrip keyContext;
        private System.Windows.Forms.ToolStripMenuItem groupThis;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editThisKey;
        private System.Windows.Forms.ToolStripMenuItem AddNewKey;
        private System.Windows.Forms.ToolStripMenuItem deleteThisKey;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem setWithFolder;
    }
}
