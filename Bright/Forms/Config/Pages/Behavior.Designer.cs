namespace Bright.Forms.Config.Pages
{
    partial class Behavior
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
            this.UseHandMoveOnNotZooming = new System.Windows.Forms.CheckBox();
            this.RememberPreviousOperationConfig = new System.Windows.Forms.CheckBox();
            this.KeyDoubleTypeToRegistNew = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.KeyListEvent = new System.Windows.Forms.ComboBox();
            this.detail = new System.Windows.Forms.GroupBox();
            this.ClearDestOnBack = new System.Windows.Forms.CheckBox();
            this.BackupInterval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.detail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackupInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // UseHandMoveOnNotZooming
            // 
            this.UseHandMoveOnNotZooming.AutoSize = true;
            this.UseHandMoveOnNotZooming.Location = new System.Drawing.Point(3, 3);
            this.UseHandMoveOnNotZooming.Name = "UseHandMoveOnNotZooming";
            this.UseHandMoveOnNotZooming.Size = new System.Drawing.Size(310, 16);
            this.UseHandMoveOnNotZooming.TabIndex = 0;
            this.UseHandMoveOnNotZooming.Text = "ズームされていない時にハンドカーソルで動かせるようにする(&H)";
            this.UseHandMoveOnNotZooming.UseVisualStyleBackColor = true;
            // 
            // RememberPreviousOperationConfig
            // 
            this.RememberPreviousOperationConfig.AutoSize = true;
            this.RememberPreviousOperationConfig.Location = new System.Drawing.Point(3, 47);
            this.RememberPreviousOperationConfig.Name = "RememberPreviousOperationConfig";
            this.RememberPreviousOperationConfig.Size = new System.Drawing.Size(192, 16);
            this.RememberPreviousOperationConfig.TabIndex = 2;
            this.RememberPreviousOperationConfig.Text = "直前の振り分け設定を記憶する(&R)";
            this.RememberPreviousOperationConfig.UseVisualStyleBackColor = true;
            // 
            // KeyDoubleTypeToRegistNew
            // 
            this.KeyDoubleTypeToRegistNew.AutoSize = true;
            this.KeyDoubleTypeToRegistNew.Location = new System.Drawing.Point(3, 25);
            this.KeyDoubleTypeToRegistNew.Name = "KeyDoubleTypeToRegistNew";
            this.KeyDoubleTypeToRegistNew.Size = new System.Drawing.Size(386, 16);
            this.KeyDoubleTypeToRegistNew.TabIndex = 1;
            this.KeyDoubleTypeToRegistNew.Text = "登録されていないキーを二度押しした時、そのキーへの割り当て設定をする(&D)";
            this.KeyDoubleTypeToRegistNew.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "キー/フォルダー ビューをダブルクリックした時の挙動:";
            // 
            // KeyListEvent
            // 
            this.KeyListEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KeyListEvent.FormattingEnabled = true;
            this.KeyListEvent.Items.AddRange(new object[] {
            "何もしない",
            "そのキーへ振り分ける",
            "そのキーを編集する"});
            this.KeyListEvent.Location = new System.Drawing.Point(248, 73);
            this.KeyListEvent.Name = "KeyListEvent";
            this.KeyListEvent.Size = new System.Drawing.Size(199, 20);
            this.KeyListEvent.TabIndex = 8;
            // 
            // detail
            // 
            this.detail.Controls.Add(this.ClearDestOnBack);
            this.detail.Controls.Add(this.BackupInterval);
            this.detail.Controls.Add(this.label2);
            this.detail.Location = new System.Drawing.Point(5, 226);
            this.detail.Name = "detail";
            this.detail.Size = new System.Drawing.Size(442, 71);
            this.detail.TabIndex = 9;
            this.detail.TabStop = false;
            this.detail.Text = "詳細";
            // 
            // ClearDestOnBack
            // 
            this.ClearDestOnBack.AutoSize = true;
            this.ClearDestOnBack.Location = new System.Drawing.Point(6, 43);
            this.ClearDestOnBack.Name = "ClearDestOnBack";
            this.ClearDestOnBack.Size = new System.Drawing.Size(293, 16);
            this.ClearDestOnBack.TabIndex = 2;
            this.ClearDestOnBack.Text = "前のファイルに戻った時に振り分け先を破棄する(&D)[推奨]";
            this.ClearDestOnBack.UseVisualStyleBackColor = true;
            // 
            // BackupInterval
            // 
            this.BackupInterval.Location = new System.Drawing.Point(173, 18);
            this.BackupInterval.Name = "BackupInterval";
            this.BackupInterval.Size = new System.Drawing.Size(73, 19);
            this.BackupInterval.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "自動バックアップの間隔(0で無効)";
            // 
            // Behavior
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.Controls.Add(this.detail);
            this.Controls.Add(this.KeyListEvent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KeyDoubleTypeToRegistNew);
            this.Controls.Add(this.RememberPreviousOperationConfig);
            this.Controls.Add(this.UseHandMoveOnNotZooming);
            this.Name = "Behavior";
            this.Load += new System.EventHandler(this.Behavior_Load);
            this.detail.ResumeLayout(false);
            this.detail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackupInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox UseHandMoveOnNotZooming;
        private System.Windows.Forms.CheckBox RememberPreviousOperationConfig;
        private System.Windows.Forms.CheckBox KeyDoubleTypeToRegistNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox KeyListEvent;
        private System.Windows.Forms.GroupBox detail;
        private System.Windows.Forms.NumericUpDown BackupInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ClearDestOnBack;
    }
}
