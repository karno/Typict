namespace Bright.Forms.Grouping
{
    partial class Duplication
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelThis = new System.Windows.Forms.Button();
            this.destPicture = new System.Windows.Forms.PictureBox();
            this.srcPicture = new System.Windows.Forms.PictureBox();
            this.btnOverwrite = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.acceptAll = new System.Windows.Forms.CheckBox();
            this.btnCancelAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.destPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.srcPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "画像の移動先に、同名のファイルが存在します。処理を選択してください。";
            // 
            // btnCancelThis
            // 
            this.btnCancelThis.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelThis.Location = new System.Drawing.Point(12, 27);
            this.btnCancelThis.Name = "btnCancelThis";
            this.btnCancelThis.Padding = new System.Windows.Forms.Padding(3);
            this.btnCancelThis.Size = new System.Drawing.Size(470, 80);
            this.btnCancelThis.TabIndex = 1;
            this.btnCancelThis.Text = "このファイルの移動をキャンセルする\r\n(すでに存在するファイルを優先します→)";
            this.btnCancelThis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelThis.UseVisualStyleBackColor = true;
            // 
            // destPicture
            // 
            this.destPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.destPicture.Location = new System.Drawing.Point(380, 37);
            this.destPicture.Name = "destPicture";
            this.destPicture.Size = new System.Drawing.Size(90, 60);
            this.destPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.destPicture.TabIndex = 2;
            this.destPicture.TabStop = false;
            // 
            // srcPicture
            // 
            this.srcPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.srcPicture.Location = new System.Drawing.Point(380, 123);
            this.srcPicture.Name = "srcPicture";
            this.srcPicture.Size = new System.Drawing.Size(90, 60);
            this.srcPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.srcPicture.TabIndex = 4;
            this.srcPicture.TabStop = false;
            // 
            // btnOverwrite
            // 
            this.btnOverwrite.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOverwrite.Location = new System.Drawing.Point(12, 113);
            this.btnOverwrite.Name = "btnOverwrite";
            this.btnOverwrite.Padding = new System.Windows.Forms.Padding(3);
            this.btnOverwrite.Size = new System.Drawing.Size(470, 80);
            this.btnOverwrite.TabIndex = 2;
            this.btnOverwrite.Text = "上書きする\r\n(新しく移動するファイルを優先します→)";
            this.btnOverwrite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOverwrite.UseVisualStyleBackColor = true;
            // 
            // btnRename
            // 
            this.btnRename.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.btnRename.Location = new System.Drawing.Point(12, 199);
            this.btnRename.Name = "btnRename";
            this.btnRename.Padding = new System.Windows.Forms.Padding(3);
            this.btnRename.Size = new System.Drawing.Size(470, 40);
            this.btnRename.TabIndex = 3;
            this.btnRename.Text = "名前を変更して移動する\r\n(名前の末尾に括弧付き数字が付加されます)";
            this.btnRename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRename.UseVisualStyleBackColor = true;
            // 
            // acceptAll
            // 
            this.acceptAll.AutoSize = true;
            this.acceptAll.Location = new System.Drawing.Point(14, 291);
            this.acceptAll.Name = "acceptAll";
            this.acceptAll.Size = new System.Drawing.Size(171, 16);
            this.acceptAll.TabIndex = 5;
            this.acceptAll.Text = "以降の重複に全て適用する(&A)";
            this.acceptAll.UseVisualStyleBackColor = true;
            // 
            // btnCancelAll
            // 
            this.btnCancelAll.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnCancelAll.Location = new System.Drawing.Point(12, 245);
            this.btnCancelAll.Name = "btnCancelAll";
            this.btnCancelAll.Padding = new System.Windows.Forms.Padding(3);
            this.btnCancelAll.Size = new System.Drawing.Size(470, 40);
            this.btnCancelAll.TabIndex = 4;
            this.btnCancelAll.Text = "すべての移動をキャンセルする";
            this.btnCancelAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelAll.UseVisualStyleBackColor = true;
            // 
            // Duplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 317);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelAll);
            this.Controls.Add(this.acceptAll);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.srcPicture);
            this.Controls.Add(this.btnOverwrite);
            this.Controls.Add(this.destPicture);
            this.Controls.Add(this.btnCancelThis);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Duplication";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "画像の重複";
            this.Load += new System.EventHandler(this.Duplication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.destPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.srcPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelThis;
        private System.Windows.Forms.PictureBox destPicture;
        private System.Windows.Forms.PictureBox srcPicture;
        private System.Windows.Forms.Button btnOverwrite;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.CheckBox acceptAll;
        private System.Windows.Forms.Button btnCancelAll;
    }
}