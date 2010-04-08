using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Bright.Forms.Config
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();

            //tree node registation
            configPageTree.Nodes.Add(new TreeNodeEx(new Pages.Behavior(), new[] { new TreeNodeEx(new Pages.DistributionBehavior()), new TreeNodeEx(new Pages.Prefetch()) }));
            configPageTree.Nodes.Add(new TreeNodeEx(new Pages.Display(), new[] { new TreeNodeEx(new Pages.OverlapText()), new TreeNodeEx(new Pages.OverlapThumbnail()) }));
        }

        class TreeNodeEx : TreeNode
        {
            private ConfigPage _linkedPage;
            public ConfigPage LinkedPage { get { return _linkedPage; } }
            public TreeNodeEx(ConfigPage linked)
                : base()
            {
                _linkedPage = linked;
                this.Text = linked.Description;
            }

            public TreeNodeEx(ConfigPage linked, TreeNodeEx[] children)
                : this(linked)
            {
                this.Nodes.AddRange(children);
            }
        }

        private void titlePanelBack_Paint(object sender, PaintEventArgs e)
        {
            using (var b = new LinearGradientBrush(titlePanelBack.ClientRectangle, Color.RoyalBlue, Color.CornflowerBlue, 0.0f))
            {
                b.GammaCorrection = true;
                e.Graphics.FillRectangle(b, titlePanelBack.ClientRectangle);
            }
        }

        ConfigPage prevPage = null;
        private void configPageTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var node = e.Node as TreeNodeEx;
            if (node != null)
            {
                if (prevPage != null)
                    prevPage.Visible = false;
                prevPage = node.LinkedPage;
                prevPage.Parent = configPageOwner;
                prevPage.Dock = DockStyle.Fill;
                prevPage.Visible = true;
                StringBuilder sb = new StringBuilder();
                sb.Append(node.LinkedPage.Description);
                TreeNodeEx cn = node.Parent as TreeNodeEx;
                while (cn != null)
                {
                    sb.Insert(0, cn.LinkedPage.Description + " - ");
                    cn = cn.Parent as TreeNodeEx;
                }
                titleLabel.Text = sb.ToString();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            foreach (var n in configPageTree.Nodes)
            {
                InfoAcceptToNode(n as TreeNode);
            }
        }

        private void InfoAcceptToNode(TreeNode node)
        {
            if (node == null)
                return;
            var ex = node as TreeNodeEx;
            if (ex != null)
                ex.LinkedPage.CallAccept();
            foreach (var n in node.Nodes)
            {
                InfoAcceptToNode(n as TreeNode);
            }
        }

        private void Config_Load(object sender, EventArgs e)
        {
            this.Text = Define.AppName + "の設定";
            configPageTree.SelectedNode = configPageTree.Nodes[0];
        }
    }
}
