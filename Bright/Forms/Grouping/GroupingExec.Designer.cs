namespace Bright.Forms.Grouping
{
    partial class GroupingExec
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
            this.stateLabel = new System.Windows.Forms.Label();
            this.mainProgressBar = new System.Windows.Forms.ProgressBar();
            this.movingTitleLabel = new System.Windows.Forms.Label();
            this.moveFileLabel = new System.Windows.Forms.Label();
            this.elementsList = new System.Windows.Forms.ListBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.finishOperationCandidates = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.remainTimeLabel = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.showErrorTrace = new System.Windows.Forms.CheckBox();
            this.errorTrace = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(12, 12);
            this.stateLabel.Margin = new System.Windows.Forms.Padding(3);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(154, 12);
            this.stateLabel.TabIndex = 0;
            this.stateLabel.Text = "オペレーションを実行しています...";
            // 
            // mainProgressBar
            // 
            this.mainProgressBar.Location = new System.Drawing.Point(12, 30);
            this.mainProgressBar.Name = "mainProgressBar";
            this.mainProgressBar.Size = new System.Drawing.Size(416, 23);
            this.mainProgressBar.TabIndex = 2;
            // 
            // movingTitleLabel
            // 
            this.movingTitleLabel.AutoSize = true;
            this.movingTitleLabel.Location = new System.Drawing.Point(12, 56);
            this.movingTitleLabel.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.movingTitleLabel.Name = "movingTitleLabel";
            this.movingTitleLabel.Size = new System.Drawing.Size(43, 12);
            this.movingTitleLabel.TabIndex = 3;
            this.movingTitleLabel.Text = "移動中:";
            // 
            // moveFileLabel
            // 
            this.moveFileLabel.AutoSize = true;
            this.moveFileLabel.Location = new System.Drawing.Point(55, 56);
            this.moveFileLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.moveFileLabel.Name = "moveFileLabel";
            this.moveFileLabel.Size = new System.Drawing.Size(50, 12);
            this.moveFileLabel.TabIndex = 4;
            this.moveFileLabel.Text = "Loading...";
            // 
            // elementsList
            // 
            this.elementsList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.elementsList.FormattingEnabled = true;
            this.elementsList.IntegralHeight = false;
            this.elementsList.ItemHeight = 16;
            this.elementsList.Location = new System.Drawing.Point(12, 74);
            this.elementsList.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.elementsList.Name = "elementsList";
            this.elementsList.Size = new System.Drawing.Size(416, 103);
            this.elementsList.TabIndex = 6;
            this.elementsList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.elementsList_DrawItem);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(339, 194);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(89, 27);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "キャンセル";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // finishOperationCandidates
            // 
            this.finishOperationCandidates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.finishOperationCandidates.FormattingEnabled = true;
            this.finishOperationCandidates.Items.AddRange(new object[] {
            "何もしない",
            "このウィンドウを閉じる",
            "Typictを終了する",
            "Windowsをシャットダウンする"});
            this.finishOperationCandidates.Location = new System.Drawing.Point(12, 198);
            this.finishOperationCandidates.Name = "finishOperationCandidates";
            this.finishOperationCandidates.Size = new System.Drawing.Size(321, 20);
            this.finishOperationCandidates.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "振り分け完了時の動作:";
            // 
            // remainTimeLabel
            // 
            this.remainTimeLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.remainTimeLabel.Location = new System.Drawing.Point(12, 12);
            this.remainTimeLabel.Name = "remainTimeLabel";
            this.remainTimeLabel.Size = new System.Drawing.Size(416, 12);
            this.remainTimeLabel.TabIndex = 1;
            this.remainTimeLabel.Text = "残り時間:計測中...";
            this.remainTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // showErrorTrace
            // 
            this.showErrorTrace.Appearance = System.Windows.Forms.Appearance.Button;
            this.showErrorTrace.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.showErrorTrace.Image = global::Bright.Properties.Resources.warning;
            this.showErrorTrace.Location = new System.Drawing.Point(402, 55);
            this.showErrorTrace.Margin = new System.Windows.Forms.Padding(0);
            this.showErrorTrace.Name = "showErrorTrace";
            this.showErrorTrace.Size = new System.Drawing.Size(26, 20);
            this.showErrorTrace.TabIndex = 5;
            this.toolTip.SetToolTip(this.showErrorTrace, "エラートレース画面へ切り替えます。");
            this.showErrorTrace.UseVisualStyleBackColor = true;
            this.showErrorTrace.CheckedChanged += new System.EventHandler(this.showErrorTrace_CheckedChanged);
            // 
            // errorTrace
            // 
            this.errorTrace.Location = new System.Drawing.Point(12, 74);
            this.errorTrace.Multiline = true;
            this.errorTrace.Name = "errorTrace";
            this.errorTrace.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.errorTrace.Size = new System.Drawing.Size(416, 103);
            this.errorTrace.TabIndex = 7;
            this.errorTrace.Text = "*error trace\r\n";
            this.errorTrace.Visible = false;
            this.errorTrace.WordWrap = false;
            // 
            // GroupingExec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(440, 230);
            this.ControlBox = false;
            this.Controls.Add(this.stateLabel);
            this.Controls.Add(this.showErrorTrace);
            this.Controls.Add(this.errorTrace);
            this.Controls.Add(this.remainTimeLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.finishOperationCandidates);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.elementsList);
            this.Controls.Add(this.moveFileLabel);
            this.Controls.Add(this.movingTitleLabel);
            this.Controls.Add(this.mainProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GroupingExec";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "オペレーションの実行";
            this.Load += new System.EventHandler(this.GroupingExec_Load);
            this.Shown += new System.EventHandler(this.GroupingExec_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GroupingExec_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.ProgressBar mainProgressBar;
        private System.Windows.Forms.Label movingTitleLabel;
        private System.Windows.Forms.Label moveFileLabel;
        private System.Windows.Forms.ListBox elementsList;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox finishOperationCandidates;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label remainTimeLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox showErrorTrace;
        private System.Windows.Forms.TextBox errorTrace;
    }
}