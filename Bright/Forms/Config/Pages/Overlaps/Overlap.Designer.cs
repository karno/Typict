namespace Bright.Forms.Config.Pages
{
    partial class Overlap
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
            this.ShowThis = new System.Windows.Forms.CheckBox();
            this.overlapConfigGroup = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.OffsetY = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.OffsetX = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.DrawLocation = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.overlapConfigGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetX)).BeginInit();
            this.SuspendLayout();
            // 
            // ShowThis
            // 
            this.ShowThis.AutoSize = true;
            this.ShowThis.Location = new System.Drawing.Point(3, 3);
            this.ShowThis.Name = "ShowThis";
            this.ShowThis.Size = new System.Drawing.Size(111, 16);
            this.ShowThis.TabIndex = 0;
            this.ShowThis.Text = "これを表示する(&V)";
            this.ShowThis.UseVisualStyleBackColor = true;
            this.ShowThis.CheckedChanged += new System.EventHandler(this.Show_CheckedChanged);
            // 
            // overlapConfigGroup
            // 
            this.overlapConfigGroup.Controls.Add(this.label4);
            this.overlapConfigGroup.Controls.Add(this.OffsetY);
            this.overlapConfigGroup.Controls.Add(this.label3);
            this.overlapConfigGroup.Controls.Add(this.OffsetX);
            this.overlapConfigGroup.Controls.Add(this.label2);
            this.overlapConfigGroup.Controls.Add(this.DrawLocation);
            this.overlapConfigGroup.Controls.Add(this.label1);
            this.overlapConfigGroup.Location = new System.Drawing.Point(3, 25);
            this.overlapConfigGroup.Name = "overlapConfigGroup";
            this.overlapConfigGroup.Size = new System.Drawing.Size(444, 76);
            this.overlapConfigGroup.TabIndex = 1;
            this.overlapConfigGroup.TabStop = false;
            this.overlapConfigGroup.Text = "表示設定";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "Y方向:";
            // 
            // OffsetY
            // 
            this.OffsetY.Location = new System.Drawing.Point(261, 44);
            this.OffsetY.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.OffsetY.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.OffsetY.Name = "OffsetY";
            this.OffsetY.Size = new System.Drawing.Size(72, 19);
            this.OffsetY.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "X方向:";
            // 
            // OffsetX
            // 
            this.OffsetX.Location = new System.Drawing.Point(139, 44);
            this.OffsetX.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.OffsetX.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.OffsetX.Name = "OffsetX";
            this.OffsetX.Size = new System.Drawing.Size(72, 19);
            this.OffsetX.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "位置の調整(px)";
            // 
            // DrawLocation
            // 
            this.DrawLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DrawLocation.FormattingEnabled = true;
            this.DrawLocation.Items.AddRange(new object[] {
            "左上",
            "左下",
            "右上",
            "右下"});
            this.DrawLocation.Location = new System.Drawing.Point(65, 18);
            this.DrawLocation.Name = "DrawLocation";
            this.DrawLocation.Size = new System.Drawing.Size(153, 20);
            this.DrawLocation.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "表示位置";
            // 
            // Overlap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Controls.Add(this.overlapConfigGroup);
            this.Controls.Add(this.ShowThis);
            this.Name = "Overlap";
            this.overlapConfigGroup.ResumeLayout(false);
            this.overlapConfigGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OffsetX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ShowThis;
        private System.Windows.Forms.GroupBox overlapConfigGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DrawLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown OffsetY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown OffsetX;
        private System.Windows.Forms.Label label2;
    }
}
