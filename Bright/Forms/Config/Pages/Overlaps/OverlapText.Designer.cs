namespace Bright.Forms.Config.Pages
{
    partial class OverlapText
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.FileNameTextFullpath = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.previewBox = new System.Windows.Forms.PictureBox();
            this.UseAntiAlias = new System.Windows.Forms.CheckBox();
            this.ChangeUsingFont = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.FileNameTextFullpath);
            this.groupBox2.Location = new System.Drawing.Point(3, 215);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 47);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "その他";
            // 
            // FileNameTextFullpath
            // 
            this.FileNameTextFullpath.AutoSize = true;
            this.FileNameTextFullpath.Location = new System.Drawing.Point(6, 18);
            this.FileNameTextFullpath.Name = "FileNameTextFullpath";
            this.FileNameTextFullpath.Size = new System.Drawing.Size(165, 16);
            this.FileNameTextFullpath.TabIndex = 0;
            this.FileNameTextFullpath.Text = "ファイル名をフルパスで表示(&S)";
            this.FileNameTextFullpath.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.UseAntiAlias);
            this.groupBox3.Controls.Add(this.ChangeUsingFont);
            this.groupBox3.Location = new System.Drawing.Point(3, 107);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(444, 102);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "フォントとデザイン";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.previewBox);
            this.groupBox4.Location = new System.Drawing.Point(177, 18);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(261, 78);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "プレビュー";
            // 
            // previewBox
            // 
            this.previewBox.BackColor = System.Drawing.Color.White;
            this.previewBox.Location = new System.Drawing.Point(6, 18);
            this.previewBox.Name = "previewBox";
            this.previewBox.Size = new System.Drawing.Size(249, 54);
            this.previewBox.TabIndex = 0;
            this.previewBox.TabStop = false;
            this.previewBox.Paint += new System.Windows.Forms.PaintEventHandler(this.previewBox_Paint);
            // 
            // UseAntiAlias
            // 
            this.UseAntiAlias.AutoSize = true;
            this.UseAntiAlias.Location = new System.Drawing.Point(6, 53);
            this.UseAntiAlias.Name = "UseAntiAlias";
            this.UseAntiAlias.Size = new System.Drawing.Size(138, 16);
            this.UseAntiAlias.TabIndex = 1;
            this.UseAntiAlias.Text = "アンチエイリアスを使う(&A)";
            this.UseAntiAlias.UseVisualStyleBackColor = true;
            this.UseAntiAlias.CheckedChanged += new System.EventHandler(this.UseAntiAlias_CheckedChanged);
            // 
            // ChangeUsingFont
            // 
            this.ChangeUsingFont.Location = new System.Drawing.Point(6, 18);
            this.ChangeUsingFont.Name = "ChangeUsingFont";
            this.ChangeUsingFont.Size = new System.Drawing.Size(165, 29);
            this.ChangeUsingFont.TabIndex = 0;
            this.ChangeUsingFont.Text = "フォントの選択(&F)...";
            this.ChangeUsingFont.UseVisualStyleBackColor = true;
            this.ChangeUsingFont.Click += new System.EventHandler(this.ChangeUsingFont_Click);
            // 
            // OverlapText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "OverlapText";
            this.Load += new System.EventHandler(this.OverlapText_Load);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.previewBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox FileNameTextFullpath;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button ChangeUsingFont;
        private System.Windows.Forms.CheckBox UseAntiAlias;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox previewBox;
    }
}
