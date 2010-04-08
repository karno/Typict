namespace Bright.Forms.Config
{
    partial class Config
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
            this.configPageTree = new System.Windows.Forms.TreeView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.titlePanelBack = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.configPageOwner = new System.Windows.Forms.Panel();
            this.titlePanelBack.SuspendLayout();
            this.SuspendLayout();
            // 
            // configPageTree
            // 
            this.configPageTree.FullRowSelect = true;
            this.configPageTree.Location = new System.Drawing.Point(12, 12);
            this.configPageTree.Name = "configPageTree";
            this.configPageTree.Size = new System.Drawing.Size(154, 332);
            this.configPageTree.TabIndex = 0;
            this.configPageTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.configPageTree_AfterSelect);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(510, 350);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(392, 350);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(112, 30);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // titlePanelBack
            // 
            this.titlePanelBack.BackColor = System.Drawing.Color.RoyalBlue;
            this.titlePanelBack.Controls.Add(this.titleLabel);
            this.titlePanelBack.Location = new System.Drawing.Point(172, 12);
            this.titlePanelBack.Name = "titlePanelBack";
            this.titlePanelBack.Size = new System.Drawing.Size(450, 26);
            this.titlePanelBack.TabIndex = 3;
            this.titlePanelBack.Paint += new System.Windows.Forms.PaintEventHandler(this.titlePanelBack_Paint);
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleLabel.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(0, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(450, 26);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Configuration";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // configPageOwner
            // 
            this.configPageOwner.Location = new System.Drawing.Point(172, 44);
            this.configPageOwner.Name = "configPageOwner";
            this.configPageOwner.Size = new System.Drawing.Size(450, 300);
            this.configPageOwner.TabIndex = 1;
            // 
            // Config
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(634, 392);
            this.ControlBox = false;
            this.Controls.Add(this.configPageOwner);
            this.Controls.Add(this.titlePanelBack);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.configPageTree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Config";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "設定";
            this.Load += new System.EventHandler(this.Config_Load);
            this.titlePanelBack.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView configPageTree;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel titlePanelBack;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel configPageOwner;
    }
}