namespace Bright.Forms.Config.Pages
{
    partial class Prefetch
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
            this.EnablePrefetch = new System.Windows.Forms.CheckBox();
            this.prefetchDetal = new System.Windows.Forms.GroupBox();
            this.PrefetchKeepMaximum = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.PrefetchLength = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.EnableThumbnailPrefetch = new System.Windows.Forms.CheckBox();
            this.thumbPrefetchDetail = new System.Windows.Forms.GroupBox();
            this.KeepAllThumbnail = new System.Windows.Forms.CheckBox();
            this.PrefetchAllThumbnail = new System.Windows.Forms.CheckBox();
            this.ThumbnailKeepMaximum = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.ThumbnailPrefetchLength = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.prefetchDetal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrefetchKeepMaximum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrefetchLength)).BeginInit();
            this.thumbPrefetchDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThumbnailKeepMaximum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThumbnailPrefetchLength)).BeginInit();
            this.SuspendLayout();
            // 
            // EnablePrefetch
            // 
            this.EnablePrefetch.AutoSize = true;
            this.EnablePrefetch.Location = new System.Drawing.Point(3, 3);
            this.EnablePrefetch.Name = "EnablePrefetch";
            this.EnablePrefetch.Size = new System.Drawing.Size(135, 16);
            this.EnablePrefetch.TabIndex = 0;
            this.EnablePrefetch.Text = "先読みを有効にする(&P)";
            this.EnablePrefetch.UseVisualStyleBackColor = true;
            this.EnablePrefetch.CheckedChanged += new System.EventHandler(this.EnablePrefetch_CheckedChanged);
            // 
            // prefetchDetal
            // 
            this.prefetchDetal.Controls.Add(this.PrefetchKeepMaximum);
            this.prefetchDetal.Controls.Add(this.label2);
            this.prefetchDetal.Controls.Add(this.PrefetchLength);
            this.prefetchDetal.Controls.Add(this.label1);
            this.prefetchDetal.Location = new System.Drawing.Point(3, 25);
            this.prefetchDetal.Name = "prefetchDetal";
            this.prefetchDetal.Size = new System.Drawing.Size(447, 70);
            this.prefetchDetal.TabIndex = 1;
            this.prefetchDetal.TabStop = false;
            this.prefetchDetal.Text = "先読みの詳細設定";
            // 
            // PrefetchKeepMaximum
            // 
            this.PrefetchKeepMaximum.Location = new System.Drawing.Point(167, 43);
            this.PrefetchKeepMaximum.Name = "PrefetchKeepMaximum";
            this.PrefetchKeepMaximum.Size = new System.Drawing.Size(54, 19);
            this.PrefetchKeepMaximum.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "データを保持する最大ファイル数";
            // 
            // PrefetchLength
            // 
            this.PrefetchLength.Location = new System.Drawing.Point(167, 18);
            this.PrefetchLength.Name = "PrefetchLength";
            this.PrefetchLength.Size = new System.Drawing.Size(54, 19);
            this.PrefetchLength.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "先読みするファイル数";
            // 
            // EnableThumbnailPrefetch
            // 
            this.EnableThumbnailPrefetch.AutoSize = true;
            this.EnableThumbnailPrefetch.Location = new System.Drawing.Point(3, 110);
            this.EnableThumbnailPrefetch.Name = "EnableThumbnailPrefetch";
            this.EnableThumbnailPrefetch.Size = new System.Drawing.Size(226, 16);
            this.EnableThumbnailPrefetch.TabIndex = 2;
            this.EnableThumbnailPrefetch.Text = "サムネイルの先読みを有効にする(&T)[推奨]";
            this.EnableThumbnailPrefetch.UseVisualStyleBackColor = true;
            this.EnableThumbnailPrefetch.CheckedChanged += new System.EventHandler(this.EnableThumbnailPrefetch_CheckedChanged);
            // 
            // thumbPrefetchDetail
            // 
            this.thumbPrefetchDetail.Controls.Add(this.KeepAllThumbnail);
            this.thumbPrefetchDetail.Controls.Add(this.PrefetchAllThumbnail);
            this.thumbPrefetchDetail.Controls.Add(this.ThumbnailKeepMaximum);
            this.thumbPrefetchDetail.Controls.Add(this.label3);
            this.thumbPrefetchDetail.Controls.Add(this.ThumbnailPrefetchLength);
            this.thumbPrefetchDetail.Controls.Add(this.label4);
            this.thumbPrefetchDetail.Location = new System.Drawing.Point(3, 132);
            this.thumbPrefetchDetail.Name = "thumbPrefetchDetail";
            this.thumbPrefetchDetail.Size = new System.Drawing.Size(447, 69);
            this.thumbPrefetchDetail.TabIndex = 3;
            this.thumbPrefetchDetail.TabStop = false;
            this.thumbPrefetchDetail.Text = "サムネイル先読みの詳細設定";
            // 
            // KeepAllThumbnail
            // 
            this.KeepAllThumbnail.AutoSize = true;
            this.KeepAllThumbnail.Location = new System.Drawing.Point(227, 44);
            this.KeepAllThumbnail.Name = "KeepAllThumbnail";
            this.KeepAllThumbnail.Size = new System.Drawing.Size(180, 16);
            this.KeepAllThumbnail.TabIndex = 5;
            this.KeepAllThumbnail.Text = "すべてのサムネイルを保持する(&A)";
            this.KeepAllThumbnail.UseVisualStyleBackColor = true;
            this.KeepAllThumbnail.CheckedChanged += new System.EventHandler(this.KeepAllThumbnail_CheckedChanged);
            // 
            // PrefetchAllThumbnail
            // 
            this.PrefetchAllThumbnail.AutoSize = true;
            this.PrefetchAllThumbnail.Location = new System.Drawing.Point(227, 19);
            this.PrefetchAllThumbnail.Name = "PrefetchAllThumbnail";
            this.PrefetchAllThumbnail.Size = new System.Drawing.Size(191, 16);
            this.PrefetchAllThumbnail.TabIndex = 2;
            this.PrefetchAllThumbnail.Text = "すべてのサムネイルを先読みする(&A)";
            this.PrefetchAllThumbnail.UseVisualStyleBackColor = true;
            this.PrefetchAllThumbnail.CheckedChanged += new System.EventHandler(this.PrefetchAllThumbnail_CheckedChanged);
            // 
            // ThumbnailKeepMaximum
            // 
            this.ThumbnailKeepMaximum.Location = new System.Drawing.Point(167, 43);
            this.ThumbnailKeepMaximum.Name = "ThumbnailKeepMaximum";
            this.ThumbnailKeepMaximum.Size = new System.Drawing.Size(54, 19);
            this.ThumbnailKeepMaximum.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "データを保持する最大ファイル数";
            // 
            // ThumbnailPrefetchLength
            // 
            this.ThumbnailPrefetchLength.Location = new System.Drawing.Point(167, 18);
            this.ThumbnailPrefetchLength.Name = "ThumbnailPrefetchLength";
            this.ThumbnailPrefetchLength.Size = new System.Drawing.Size(54, 19);
            this.ThumbnailPrefetchLength.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "先読みするファイル数";
            // 
            // Prefetch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Controls.Add(this.thumbPrefetchDetail);
            this.Controls.Add(this.EnableThumbnailPrefetch);
            this.Controls.Add(this.prefetchDetal);
            this.Controls.Add(this.EnablePrefetch);
            this.Name = "Prefetch";
            this.Load += new System.EventHandler(this.Prefetch_Load);
            this.prefetchDetal.ResumeLayout(false);
            this.prefetchDetal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrefetchKeepMaximum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrefetchLength)).EndInit();
            this.thumbPrefetchDetail.ResumeLayout(false);
            this.thumbPrefetchDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThumbnailKeepMaximum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThumbnailPrefetchLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox EnablePrefetch;
        private System.Windows.Forms.GroupBox prefetchDetal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown PrefetchKeepMaximum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown PrefetchLength;
        private System.Windows.Forms.CheckBox EnableThumbnailPrefetch;
        private System.Windows.Forms.GroupBox thumbPrefetchDetail;
        private System.Windows.Forms.NumericUpDown ThumbnailKeepMaximum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown ThumbnailPrefetchLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox KeepAllThumbnail;
        private System.Windows.Forms.CheckBox PrefetchAllThumbnail;
    }
}
