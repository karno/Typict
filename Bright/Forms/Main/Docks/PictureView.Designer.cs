namespace Bright.Forms.Main.Docks
{
    partial class PictureView
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
            this.vscPanel = new System.Windows.Forms.Panel();
            this.vertScroll = new K.Controls.VScrollBarPlus();
            this.renderer = new Bright.Forms.Main.Docks.Picture.Renderer();
            this.horzScroll = new K.Controls.HScrollBarPlus();
            this.vscPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // vscPanel
            // 
            this.vscPanel.Controls.Add(this.vertScroll);
            this.vscPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.vscPanel.Location = new System.Drawing.Point(610, 0);
            this.vscPanel.Name = "vscPanel";
            this.vscPanel.Padding = new System.Windows.Forms.Padding(0, 0, 0, 17);
            this.vscPanel.Size = new System.Drawing.Size(17, 413);
            this.vscPanel.TabIndex = 2;
            // 
            // vertScroll
            // 
            this.vertScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vertScroll.AutoEnabledControl = true;
            this.vertScroll.Location = new System.Drawing.Point(0, 0);
            this.vertScroll.Maximum = 1000;
            this.vertScroll.Name = "vertScroll";
            this.vertScroll.Size = new System.Drawing.Size(17, 396);
            this.vertScroll.TabIndex = 0;
            this.vertScroll.ValueChanged += new System.EventHandler(this.vertScroll_ValueChanged);
            this.vertScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vertScroll_Scroll);
            // 
            // renderer
            // 
            this.renderer.AdditionalString = null;
            this.renderer.ClientAreaSize = new System.Drawing.Size(0, 0);
            this.renderer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.renderer.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.renderer.KeepProportion = false;
            this.renderer.Location = new System.Drawing.Point(0, 0);
            this.renderer.Name = "renderer";
            this.renderer.Size = new System.Drawing.Size(610, 396);
            this.renderer.TabIndex = 3;
            this.renderer.Text = "renderer1";
            this.renderer.XPosition = 0;
            this.renderer.YPosition = 0;
            this.renderer.ZoomPicture = false;
            this.renderer.ZoomSmallPicture = false;
            // 
            // horzScroll
            // 
            this.horzScroll.AutoEnabledControl = true;
            this.horzScroll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.horzScroll.Location = new System.Drawing.Point(0, 396);
            this.horzScroll.Maximum = 1000;
            this.horzScroll.Name = "horzScroll";
            this.horzScroll.Size = new System.Drawing.Size(610, 17);
            this.horzScroll.TabIndex = 1;
            this.horzScroll.ValueChanged += new System.EventHandler(this.horzScroll_ValueChanged);
            this.horzScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.horzScroll_Scroll);
            // 
            // PictureView
            // 
            this.ClientSize = new System.Drawing.Size(627, 413);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.renderer);
            this.Controls.Add(this.horzScroll);
            this.Controls.Add(this.vscPanel);
            this.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.HideOnClose = true;
            this.KeyPreview = true;
            this.Name = "PictureView";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.Document;
            this.vscPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private K.Controls.VScrollBarPlus vertScroll;
        private K.Controls.HScrollBarPlus horzScroll;
        private System.Windows.Forms.Panel vscPanel;
        private Bright.Forms.Main.Docks.Picture.Renderer renderer;
    }
}
