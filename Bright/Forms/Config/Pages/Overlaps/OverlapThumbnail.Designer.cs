namespace Bright.Forms.Config.Pages
{
    partial class OverlapThumbnail
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
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ThumbnailSizeW = new System.Windows.Forms.NumericUpDown();
            this.ThumbnailSizeH = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ThumbnailSizeW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThumbnailSizeH)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "サムネイルの大きさ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(103, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "幅:";
            // 
            // ThumbnailSizeW
            // 
            this.ThumbnailSizeW.Location = new System.Drawing.Point(128, 107);
            this.ThumbnailSizeW.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.ThumbnailSizeW.Name = "ThumbnailSizeW";
            this.ThumbnailSizeW.Size = new System.Drawing.Size(72, 19);
            this.ThumbnailSizeW.TabIndex = 4;
            // 
            // ThumbnailSizeH
            // 
            this.ThumbnailSizeH.Location = new System.Drawing.Point(239, 107);
            this.ThumbnailSizeH.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.ThumbnailSizeH.Name = "ThumbnailSizeH";
            this.ThumbnailSizeH.Size = new System.Drawing.Size(72, 19);
            this.ThumbnailSizeH.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(206, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "高さ:";
            // 
            // OverlapThumbnail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Controls.Add(this.ThumbnailSizeH);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ThumbnailSizeW);
            this.Controls.Add(this.label6);
            this.Name = "OverlapThumbnail";
            this.Load += new System.EventHandler(this.OverlapThumbnail_Load);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.ThumbnailSizeW, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.ThumbnailSizeH, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ThumbnailSizeW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThumbnailSizeH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown ThumbnailSizeW;
        private System.Windows.Forms.NumericUpDown ThumbnailSizeH;
        private System.Windows.Forms.Label label7;
    }
}
