namespace Bright.Forms.Dialogs
{
    partial class UnhandledExcp
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.errorPicture = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.ignoreButton = new System.Windows.Forms.Button();
            this.reportLink = new System.Windows.Forms.LinkLabel();
            this.detailText = new System.Windows.Forms.TextBox();
            this.saveText = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorPicture)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.titleLabel.Location = new System.Drawing.Point(66, 12);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(221, 28);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "エラーが発生しました。";
            // 
            // errorPicture
            // 
            this.errorPicture.Image = global::Bright.Properties.Resources.error;
            this.errorPicture.Location = new System.Drawing.Point(12, 12);
            this.errorPicture.Name = "errorPicture";
            this.errorPicture.Size = new System.Drawing.Size(48, 48);
            this.errorPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.errorPicture.TabIndex = 1;
            this.errorPicture.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(66, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "データが失われた可能性があります。";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.saveText);
            this.groupBox1.Controls.Add(this.detailText);
            this.groupBox1.Location = new System.Drawing.Point(12, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 148);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "詳細";
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.exitButton.Location = new System.Drawing.Point(224, 220);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(121, 31);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "終了";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // ignoreButton
            // 
            this.ignoreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ignoreButton.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.ignoreButton.Location = new System.Drawing.Point(351, 220);
            this.ignoreButton.Name = "ignoreButton";
            this.ignoreButton.Size = new System.Drawing.Size(121, 31);
            this.ignoreButton.TabIndex = 5;
            this.ignoreButton.Text = "無視して続行";
            this.ignoreButton.UseVisualStyleBackColor = true;
            this.ignoreButton.Click += new System.EventHandler(this.ignoreButton_Click);
            // 
            // reportLink
            // 
            this.reportLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.reportLink.AutoSize = true;
            this.reportLink.Location = new System.Drawing.Point(12, 229);
            this.reportLink.Name = "reportLink";
            this.reportLink.Size = new System.Drawing.Size(88, 12);
            this.reportLink.TabIndex = 3;
            this.reportLink.TabStop = true;
            this.reportLink.Text = "バグ報告の方法...";
            this.reportLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.reportLink_LinkClicked);
            // 
            // detailText
            // 
            this.detailText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.detailText.Location = new System.Drawing.Point(6, 20);
            this.detailText.Multiline = true;
            this.detailText.Name = "detailText";
            this.detailText.Size = new System.Drawing.Size(448, 122);
            this.detailText.TabIndex = 1;
            // 
            // saveText
            // 
            this.saveText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveText.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveText.Image = global::Bright.Properties.Resources.save;
            this.saveText.Location = new System.Drawing.Point(433, 0);
            this.saveText.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.saveText.Name = "saveText";
            this.saveText.Size = new System.Drawing.Size(21, 21);
            this.saveText.TabIndex = 0;
            this.saveText.UseVisualStyleBackColor = true;
            this.saveText.Click += new System.EventHandler(this.saveText_Click);
            // 
            // UnhandledExcp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.Controls.Add(this.reportLink);
            this.Controls.Add(this.ignoreButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.errorPicture);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "UnhandledExcp";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "エラー";
            this.Load += new System.EventHandler(this.UnhandledExcp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorPicture)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.PictureBox errorPicture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button ignoreButton;
        private System.Windows.Forms.LinkLabel reportLink;
        private System.Windows.Forms.TextBox detailText;
        private System.Windows.Forms.Button saveText;
    }
}