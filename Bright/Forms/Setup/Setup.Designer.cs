namespace Bright.Forms.Setup
{
    partial class Setup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainTab = new System.Windows.Forms.TabControl();
            this.targetFolderPage = new System.Windows.Forms.TabPage();
            this.deleteFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.addFolder = new System.Windows.Forms.Button();
            this.targetList = new System.Windows.Forms.CheckedListBox();
            this.destinationSetPage = new System.Windows.Forms.TabPage();
            this.allClear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.notFoundFolderAlert = new System.Windows.Forms.Label();
            this.browseFolder = new System.Windows.Forms.Button();
            this.pathText = new System.Windows.Forms.TextBox();
            this.keyList = new System.Windows.Forms.ComboBox();
            this.shiftPrefix = new System.Windows.Forms.CheckBox();
            this.keyFromFolder = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.exMenuLinkLabel = new System.Windows.Forms.LinkLabel();
            this.cfgBtn = new System.Windows.Forms.Button();
            this.saveloadContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.retryGrouping = new System.Windows.Forms.ToolStripMenuItem();
            this.browseFile = new System.Windows.Forms.Button();
            this.additionalTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.mainTab.SuspendLayout();
            this.targetFolderPage.SuspendLayout();
            this.destinationSetPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.saveloadContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.targetFolderPage);
            this.mainTab.Controls.Add(this.destinationSetPage);
            this.mainTab.Location = new System.Drawing.Point(12, 12);
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(477, 247);
            this.mainTab.TabIndex = 0;
            // 
            // targetFolderPage
            // 
            this.targetFolderPage.Controls.Add(this.deleteFolder);
            this.targetFolderPage.Controls.Add(this.label1);
            this.targetFolderPage.Controls.Add(this.addFolder);
            this.targetFolderPage.Controls.Add(this.targetList);
            this.targetFolderPage.Location = new System.Drawing.Point(4, 22);
            this.targetFolderPage.Name = "targetFolderPage";
            this.targetFolderPage.Padding = new System.Windows.Forms.Padding(3);
            this.targetFolderPage.Size = new System.Drawing.Size(469, 221);
            this.targetFolderPage.TabIndex = 0;
            this.targetFolderPage.Text = "対象フォルダー";
            this.targetFolderPage.UseVisualStyleBackColor = true;
            // 
            // deleteFolder
            // 
            this.deleteFolder.Image = global::Bright.Properties.Resources.delete;
            this.deleteFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteFolder.Location = new System.Drawing.Point(292, 6);
            this.deleteFolder.Name = "deleteFolder";
            this.deleteFolder.Size = new System.Drawing.Size(171, 26);
            this.deleteFolder.TabIndex = 3;
            this.deleteFolder.Text = "選択フォルダーを削除(&D)";
            this.deleteFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteFolder.UseVisualStyleBackColor = true;
            this.deleteFolder.Click += new System.EventHandler(this.deleteFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label1.Location = new System.Drawing.Point(4, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(423, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "ドラッグ＆ドロップでも対象フォルダーを追加できます。\r\nチェックを付けたフォルダーは、下層フォルダーに存在する画像も振り分けの対象になります。";
            // 
            // addFolder
            // 
            this.addFolder.Image = global::Bright.Properties.Resources.openf;
            this.addFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addFolder.Location = new System.Drawing.Point(6, 6);
            this.addFolder.Name = "addFolder";
            this.addFolder.Size = new System.Drawing.Size(283, 26);
            this.addFolder.TabIndex = 1;
            this.addFolder.Text = "対象フォルダーを追加(&A)...";
            this.addFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addFolder.UseVisualStyleBackColor = true;
            this.addFolder.Click += new System.EventHandler(this.addFolder_Click);
            // 
            // targetList
            // 
            this.targetList.AllowDrop = true;
            this.targetList.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.targetList.FormattingEnabled = true;
            this.targetList.HorizontalScrollbar = true;
            this.targetList.IntegralHeight = false;
            this.targetList.Location = new System.Drawing.Point(6, 35);
            this.targetList.Name = "targetList";
            this.targetList.Size = new System.Drawing.Size(457, 156);
            this.targetList.TabIndex = 0;
            this.targetList.DragDrop += new System.Windows.Forms.DragEventHandler(this.targetList_DragDrop);
            this.targetList.DragEnter += new System.Windows.Forms.DragEventHandler(this.targetList_DragEnter);
            this.targetList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.targetList_KeyDown);
            // 
            // destinationSetPage
            // 
            this.destinationSetPage.Controls.Add(this.allClear);
            this.destinationSetPage.Controls.Add(this.groupBox1);
            this.destinationSetPage.Controls.Add(this.keyFromFolder);
            this.destinationSetPage.Location = new System.Drawing.Point(4, 22);
            this.destinationSetPage.Name = "destinationSetPage";
            this.destinationSetPage.Padding = new System.Windows.Forms.Padding(3);
            this.destinationSetPage.Size = new System.Drawing.Size(469, 221);
            this.destinationSetPage.TabIndex = 1;
            this.destinationSetPage.Text = "振り分け先";
            this.destinationSetPage.UseVisualStyleBackColor = true;
            // 
            // allClear
            // 
            this.allClear.Location = new System.Drawing.Point(6, 74);
            this.allClear.Name = "allClear";
            this.allClear.Size = new System.Drawing.Size(125, 28);
            this.allClear.TabIndex = 1;
            this.allClear.Text = "すべてクリア(&C)";
            this.allClear.UseVisualStyleBackColor = true;
            this.allClear.Click += new System.EventHandler(this.allClear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.browseFile);
            this.groupBox1.Controls.Add(this.notFoundFolderAlert);
            this.groupBox1.Controls.Add(this.browseFolder);
            this.groupBox1.Controls.Add(this.pathText);
            this.groupBox1.Controls.Add(this.keyList);
            this.groupBox1.Controls.Add(this.shiftPrefix);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(457, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "振り分け先の指定";
            // 
            // notFoundFolderAlert
            // 
            this.notFoundFolderAlert.AutoSize = true;
            this.notFoundFolderAlert.ForeColor = System.Drawing.Color.Red;
            this.notFoundFolderAlert.Location = new System.Drawing.Point(96, 43);
            this.notFoundFolderAlert.Name = "notFoundFolderAlert";
            this.notFoundFolderAlert.Size = new System.Drawing.Size(181, 12);
            this.notFoundFolderAlert.TabIndex = 5;
            this.notFoundFolderAlert.Text = "そのファイル/フォルダーは存在しません";
            this.notFoundFolderAlert.Visible = false;
            // 
            // browseFolder
            // 
            this.browseFolder.Location = new System.Drawing.Point(409, 21);
            this.browseFolder.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.browseFolder.Name = "browseFolder";
            this.browseFolder.Size = new System.Drawing.Size(21, 19);
            this.browseFolder.TabIndex = 3;
            this.browseFolder.Text = "...";
            this.additionalTooltip.SetToolTip(this.browseFolder, "フォルダを選択します。");
            this.browseFolder.UseVisualStyleBackColor = true;
            this.browseFolder.Click += new System.EventHandler(this.browseFolder_Click);
            // 
            // pathText
            // 
            this.pathText.AllowDrop = true;
            this.pathText.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.pathText.Location = new System.Drawing.Point(98, 21);
            this.pathText.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.pathText.Name = "pathText";
            this.pathText.Size = new System.Drawing.Size(311, 19);
            this.pathText.TabIndex = 2;
            this.pathText.TextChanged += new System.EventHandler(this.pathText_TextChanged);
            this.pathText.DragDrop += new System.Windows.Forms.DragEventHandler(this.pathText_DragDrop);
            this.pathText.DragEnter += new System.Windows.Forms.DragEventHandler(this.pathText_DragEnter);
            // 
            // keyList
            // 
            this.keyList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keyList.FormattingEnabled = true;
            this.keyList.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.keyList.Location = new System.Drawing.Point(53, 20);
            this.keyList.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.keyList.Name = "keyList";
            this.keyList.Size = new System.Drawing.Size(42, 20);
            this.keyList.TabIndex = 1;
            this.keyList.SelectedIndexChanged += new System.EventHandler(this.keyListTargetUpdated);
            // 
            // shiftPrefix
            // 
            this.shiftPrefix.Appearance = System.Windows.Forms.Appearance.Button;
            this.shiftPrefix.ForeColor = System.Drawing.SystemColors.ControlText;
            this.shiftPrefix.Location = new System.Drawing.Point(6, 19);
            this.shiftPrefix.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.shiftPrefix.Name = "shiftPrefix";
            this.shiftPrefix.Size = new System.Drawing.Size(47, 22);
            this.shiftPrefix.TabIndex = 0;
            this.shiftPrefix.Text = "Shift+";
            this.shiftPrefix.UseVisualStyleBackColor = true;
            this.shiftPrefix.CheckedChanged += new System.EventHandler(this.keyListTargetUpdated);
            // 
            // keyFromFolder
            // 
            this.keyFromFolder.Location = new System.Drawing.Point(259, 74);
            this.keyFromFolder.Name = "keyFromFolder";
            this.keyFromFolder.Size = new System.Drawing.Size(204, 28);
            this.keyFromFolder.TabIndex = 2;
            this.keyFromFolder.Text = "フォルダーを選択して割り振る(&D)...";
            this.keyFromFolder.UseVisualStyleBackColor = true;
            this.keyFromFolder.Click += new System.EventHandler(this.keyFromFolder_Click);
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Enabled = false;
            this.okBtn.Location = new System.Drawing.Point(269, 265);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(105, 27);
            this.okBtn.TabIndex = 2;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(380, 265);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(105, 27);
            this.exitBtn.TabIndex = 3;
            this.exitBtn.Text = "終了(&X)";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // exMenuLinkLabel
            // 
            this.exMenuLinkLabel.AutoSize = true;
            this.exMenuLinkLabel.Location = new System.Drawing.Point(314, 17);
            this.exMenuLinkLabel.Name = "exMenuLinkLabel";
            this.exMenuLinkLabel.Size = new System.Drawing.Size(169, 12);
            this.exMenuLinkLabel.TabIndex = 1;
            this.exMenuLinkLabel.TabStop = true;
            this.exMenuLinkLabel.Text = "振り分けデータの保存と読み込み...";
            this.exMenuLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.exMenuLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.exMenu_LinkClicked);
            // 
            // cfgBtn
            // 
            this.cfgBtn.Image = global::Bright.Properties.Resources.config;
            this.cfgBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cfgBtn.Location = new System.Drawing.Point(12, 265);
            this.cfgBtn.Name = "cfgBtn";
            this.cfgBtn.Size = new System.Drawing.Size(105, 27);
            this.cfgBtn.TabIndex = 4;
            this.cfgBtn.Text = "設定(&C)...";
            this.cfgBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cfgBtn.UseVisualStyleBackColor = true;
            this.cfgBtn.Click += new System.EventHandler(this.cfgBtn_Click);
            // 
            // saveloadContext
            // 
            this.saveloadContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveSetup,
            this.loadSetup,
            this.toolStripMenuItem1,
            this.retryGrouping});
            this.saveloadContext.Name = "contextMenuStrip1";
            this.saveloadContext.Size = new System.Drawing.Size(275, 76);
            // 
            // saveSetup
            // 
            this.saveSetup.Image = global::Bright.Properties.Resources.save;
            this.saveSetup.Name = "saveSetup";
            this.saveSetup.Size = new System.Drawing.Size(274, 22);
            this.saveSetup.Text = "設定の保存(&S)...";
            this.saveSetup.Click += new System.EventHandler(this.saveSetup_Click);
            // 
            // loadSetup
            // 
            this.loadSetup.Image = global::Bright.Properties.Resources.openf;
            this.loadSetup.Name = "loadSetup";
            this.loadSetup.Size = new System.Drawing.Size(274, 22);
            this.loadSetup.Text = "設定の読み込み(&O)...";
            this.loadSetup.Click += new System.EventHandler(this.loadSetup_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(271, 6);
            // 
            // retryGrouping
            // 
            this.retryGrouping.Name = "retryGrouping";
            this.retryGrouping.Size = new System.Drawing.Size(274, 22);
            this.retryGrouping.Text = "途中保存された振り分けを再開(&R)...";
            this.retryGrouping.Click += new System.EventHandler(this.retryGrouping_Click);
            // 
            // browseFile
            // 
            this.browseFile.Location = new System.Drawing.Point(430, 21);
            this.browseFile.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.browseFile.Name = "browseFile";
            this.browseFile.Size = new System.Drawing.Size(21, 19);
            this.browseFile.TabIndex = 4;
            this.browseFile.Text = "...";
            this.additionalTooltip.SetToolTip(this.browseFile, "アプリケーション ファイルを選択します。\r\nこのアプリケーションへファイルのパスを渡します。");
            this.browseFile.UseVisualStyleBackColor = true;
            this.browseFile.Click += new System.EventHandler(this.browseFile_Click);
            // 
            // Setup
            // 
            this.AcceptButton = this.okBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 304);
            this.ControlBox = false;
            this.Controls.Add(this.cfgBtn);
            this.Controls.Add(this.exMenuLinkLabel);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.mainTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Setup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "スタート";
            this.Load += new System.EventHandler(this.Setup_Load);
            this.mainTab.ResumeLayout(false);
            this.targetFolderPage.ResumeLayout(false);
            this.targetFolderPage.PerformLayout();
            this.destinationSetPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.saveloadContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl mainTab;
        private System.Windows.Forms.TabPage targetFolderPage;
        private System.Windows.Forms.TabPage destinationSetPage;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.LinkLabel exMenuLinkLabel;
        private System.Windows.Forms.Button cfgBtn;
        private System.Windows.Forms.CheckedListBox targetList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addFolder;
        private System.Windows.Forms.Button deleteFolder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox shiftPrefix;
        private System.Windows.Forms.Button keyFromFolder;
        private System.Windows.Forms.ComboBox keyList;
        private System.Windows.Forms.Button browseFolder;
        private System.Windows.Forms.TextBox pathText;
        private System.Windows.Forms.Button allClear;
        private System.Windows.Forms.ContextMenuStrip saveloadContext;
        private System.Windows.Forms.ToolStripMenuItem saveSetup;
        private System.Windows.Forms.ToolStripMenuItem loadSetup;
        private System.Windows.Forms.Label notFoundFolderAlert;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem retryGrouping;
        private System.Windows.Forms.Button browseFile;
        private System.Windows.Forms.ToolTip additionalTooltip;
    }
}