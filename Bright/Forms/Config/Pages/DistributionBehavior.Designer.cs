namespace Bright.Forms.Config.Pages
{
    partial class DistributionBehavior
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
            this.label3 = new System.Windows.Forms.Label();
            this.WaitExternalAppIdling = new System.Windows.Forms.CheckBox();
            this.MultiCopyTreatsReference = new System.Windows.Forms.CheckBox();
            this.WaitExternalApp = new System.Windows.Forms.CheckBox();
            this.externalAppBox = new System.Windows.Forms.GroupBox();
            this.externalAppBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(20, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(401, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "[リンク先となるべきコピー先にアプリケーションが指定されるなど、参照不可能な場合は\r\n二番目、三番目と順番に繰り下げます。]";
            // 
            // WaitExternalAppIdling
            // 
            this.WaitExternalAppIdling.AutoSize = true;
            this.WaitExternalAppIdling.Location = new System.Drawing.Point(6, 40);
            this.WaitExternalAppIdling.Name = "WaitExternalAppIdling";
            this.WaitExternalAppIdling.Size = new System.Drawing.Size(246, 16);
            this.WaitExternalAppIdling.TabIndex = 1;
            this.WaitExternalAppIdling.Text = "アプリケーションがアイドル状態になるまで待機(&I)";
            this.WaitExternalAppIdling.UseVisualStyleBackColor = true;
            this.WaitExternalAppIdling.CheckedChanged += new System.EventHandler(this.WaitExternalAppIdling_CheckedChanged);
            // 
            // MultiCopyTreatsReference
            // 
            this.MultiCopyTreatsReference.AutoSize = true;
            this.MultiCopyTreatsReference.Location = new System.Drawing.Point(3, 83);
            this.MultiCopyTreatsReference.Name = "MultiCopyTreatsReference";
            this.MultiCopyTreatsReference.Size = new System.Drawing.Size(386, 16);
            this.MultiCopyTreatsReference.TabIndex = 1;
            this.MultiCopyTreatsReference.Text = "マルチコピー時、二番目以降のコピー先へは最初のコピー先へのリンクを置く(&L)";
            this.MultiCopyTreatsReference.UseVisualStyleBackColor = true;
            // 
            // WaitExternalApp
            // 
            this.WaitExternalApp.AutoSize = true;
            this.WaitExternalApp.Location = new System.Drawing.Point(6, 18);
            this.WaitExternalApp.Name = "WaitExternalApp";
            this.WaitExternalApp.Size = new System.Drawing.Size(206, 16);
            this.WaitExternalApp.TabIndex = 0;
            this.WaitExternalApp.Text = "アプリケーションが終了するまで待機(&W)";
            this.WaitExternalApp.UseVisualStyleBackColor = true;
            this.WaitExternalApp.CheckedChanged += new System.EventHandler(this.WaitExternalApp_CheckedChanged);
            // 
            // externalAppBox
            // 
            this.externalAppBox.AutoSize = true;
            this.externalAppBox.Controls.Add(this.WaitExternalApp);
            this.externalAppBox.Controls.Add(this.WaitExternalAppIdling);
            this.externalAppBox.Location = new System.Drawing.Point(3, 3);
            this.externalAppBox.Name = "externalAppBox";
            this.externalAppBox.Size = new System.Drawing.Size(444, 74);
            this.externalAppBox.TabIndex = 0;
            this.externalAppBox.TabStop = false;
            this.externalAppBox.Text = "外部アプリケーションの呼び出し";
            // 
            // DistributionBehavior
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Controls.Add(this.externalAppBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MultiCopyTreatsReference);
            this.Name = "DistributionBehavior";
            this.Load += new System.EventHandler(this.DistributionBehavior_Load);
            this.externalAppBox.ResumeLayout(false);
            this.externalAppBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox WaitExternalAppIdling;
        private System.Windows.Forms.CheckBox MultiCopyTreatsReference;
        private System.Windows.Forms.CheckBox WaitExternalApp;
        private System.Windows.Forms.GroupBox externalAppBox;
    }
}
