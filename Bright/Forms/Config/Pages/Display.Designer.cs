namespace Bright.Forms.Config.Pages
{
    partial class Display
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
            this.CenteringImage = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.InterpolationMode = new System.Windows.Forms.ComboBox();
            this.UseDynamicInterpolate = new System.Windows.Forms.CheckBox();
            this.bigImageGroup = new System.Windows.Forms.GroupBox();
            this.BigImageIntpMode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SizeBorder = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ThumbnailSizeW = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.ThumbnailSizeH = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.KeyListPoint = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.bigImageGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SizeBorder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThumbnailSizeW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThumbnailSizeH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyListPoint)).BeginInit();
            this.SuspendLayout();
            // 
            // CenteringImage
            // 
            this.CenteringImage.AutoSize = true;
            this.CenteringImage.Location = new System.Drawing.Point(3, 3);
            this.CenteringImage.Name = "CenteringImage";
            this.CenteringImage.Size = new System.Drawing.Size(149, 16);
            this.CenteringImage.TabIndex = 0;
            this.CenteringImage.Text = "画像を中央に表示する(&C)";
            this.CenteringImage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "画像の補完処理モード";
            // 
            // InterpolationMode
            // 
            this.InterpolationMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InterpolationMode.FormattingEnabled = true;
            this.InterpolationMode.Items.AddRange(new object[] {
            "既定",
            "低品質補間(Low)",
            "高品質補間(High)",
            "双一次補間(Bilinear)",
            "双三次補間(Bicubic)",
            "最近傍補間(NearestNeighbor)[最速]",
            "高品質双一次補間(HighQualityBilinear)",
            "高品質双三次補間(HighQualityBicubic)[最遅]"});
            this.InterpolationMode.Location = new System.Drawing.Point(124, 25);
            this.InterpolationMode.Name = "InterpolationMode";
            this.InterpolationMode.Size = new System.Drawing.Size(326, 20);
            this.InterpolationMode.TabIndex = 2;
            // 
            // UseDynamicInterpolate
            // 
            this.UseDynamicInterpolate.AutoSize = true;
            this.UseDynamicInterpolate.Location = new System.Drawing.Point(3, 51);
            this.UseDynamicInterpolate.Name = "UseDynamicInterpolate";
            this.UseDynamicInterpolate.Size = new System.Drawing.Size(236, 16);
            this.UseDynamicInterpolate.TabIndex = 3;
            this.UseDynamicInterpolate.Text = "大きな画像には別の補完処理を適用する(&D)";
            this.UseDynamicInterpolate.UseVisualStyleBackColor = true;
            this.UseDynamicInterpolate.CheckedChanged += new System.EventHandler(this.UseDynamicInterpolate_CheckedChanged);
            // 
            // bigImageGroup
            // 
            this.bigImageGroup.Controls.Add(this.BigImageIntpMode);
            this.bigImageGroup.Controls.Add(this.label3);
            this.bigImageGroup.Controls.Add(this.SizeBorder);
            this.bigImageGroup.Controls.Add(this.label2);
            this.bigImageGroup.Location = new System.Drawing.Point(3, 73);
            this.bigImageGroup.Name = "bigImageGroup";
            this.bigImageGroup.Size = new System.Drawing.Size(444, 72);
            this.bigImageGroup.TabIndex = 4;
            this.bigImageGroup.TabStop = false;
            this.bigImageGroup.Text = "大画像補完設定";
            // 
            // BigImageIntpMode
            // 
            this.BigImageIntpMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BigImageIntpMode.FormattingEnabled = true;
            this.BigImageIntpMode.Items.AddRange(new object[] {
            "既定",
            "低品質補間(Low)",
            "高品質補間(High)",
            "双一次補間(Bilinear)",
            "双三次補間(Bicubic)",
            "最近傍補間(NearestNeighbor)[最速]",
            "高品質双一次補間(HighQualityBilinear)",
            "高品質双三次補間(HighQualityBicubic)[最遅]"});
            this.BigImageIntpMode.Location = new System.Drawing.Point(102, 43);
            this.BigImageIntpMode.Name = "BigImageIntpMode";
            this.BigImageIntpMode.Size = new System.Drawing.Size(326, 20);
            this.BigImageIntpMode.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "補完処理モード";
            // 
            // SizeBorder
            // 
            this.SizeBorder.Location = new System.Drawing.Point(102, 18);
            this.SizeBorder.Maximum = new decimal(new int[] {
            -1530494977,
            232830,
            0,
            0});
            this.SizeBorder.Name = "SizeBorder";
            this.SizeBorder.Size = new System.Drawing.Size(120, 19);
            this.SizeBorder.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "閾地(px)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "サムネイルのサイズ(px)";
            // 
            // ThumbnailSizeW
            // 
            this.ThumbnailSizeW.Location = new System.Drawing.Point(140, 155);
            this.ThumbnailSizeW.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.ThumbnailSizeW.Name = "ThumbnailSizeW";
            this.ThumbnailSizeW.Size = new System.Drawing.Size(61, 19);
            this.ThumbnailSizeW.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(122, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "幅";
            // 
            // ThumbnailSizeH
            // 
            this.ThumbnailSizeH.Location = new System.Drawing.Point(233, 155);
            this.ThumbnailSizeH.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.ThumbnailSizeH.Name = "ThumbnailSizeH";
            this.ThumbnailSizeH.Size = new System.Drawing.Size(61, 19);
            this.ThumbnailSizeH.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(207, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "高さ";
            // 
            // KeyListPoint
            // 
            this.KeyListPoint.DecimalPlaces = 1;
            this.KeyListPoint.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.KeyListPoint.Location = new System.Drawing.Point(181, 180);
            this.KeyListPoint.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.KeyListPoint.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.KeyListPoint.Name = "KeyListPoint";
            this.KeyListPoint.Size = new System.Drawing.Size(61, 19);
            this.KeyListPoint.TabIndex = 10;
            this.KeyListPoint.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(172, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "キー/フォルダー  ビューのフォントサイズ";
            // 
            // Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.KeyListPoint);
            this.Controls.Add(this.ThumbnailSizeH);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ThumbnailSizeW);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bigImageGroup);
            this.Controls.Add(this.UseDynamicInterpolate);
            this.Controls.Add(this.InterpolationMode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CenteringImage);
            this.Name = "Display";
            this.Load += new System.EventHandler(this.Display_Load);
            this.bigImageGroup.ResumeLayout(false);
            this.bigImageGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SizeBorder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThumbnailSizeW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThumbnailSizeH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeyListPoint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CenteringImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox InterpolationMode;
        private System.Windows.Forms.CheckBox UseDynamicInterpolate;
        private System.Windows.Forms.GroupBox bigImageGroup;
        private System.Windows.Forms.ComboBox BigImageIntpMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown SizeBorder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown ThumbnailSizeW;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown ThumbnailSizeH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown KeyListPoint;
        private System.Windows.Forms.Label label7;
    }
}
