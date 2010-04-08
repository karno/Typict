using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Bright.Forms.Dialogs
{
    public partial class AddKey : Form
    {
        Keys[] candidates;

        public AddKey(Keys[] availableCandidates)
        {
            this.candidates = availableCandidates;
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        public Keys Selected { get; private set; }

        bool candidated = false;
        private void AddKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (candidates.Contains<Keys>(e.KeyData))
            {
                inputBox.Text = new KeysConverter().ConvertToString(e.KeyData);
                Selected = e.KeyData;
                candidated = true;
                SetMessage("Enterを押すと確定します", false);
            }
            else
            {
                if (e.KeyData == Keys.Escape)
                    this.Close();
                else if (e.KeyData == Keys.Enter)
                {
                    if (candidated)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        SetMessage("そのキーはすでに存在しているか、利用できません", true);
                    }
                }
                else
                {
                    SetMessage("そのキーは利用できません", true);
                    candidated = false;
                }
            }
        }

        private void SetMessage(string msg, bool warning)
        {
            if (String.IsNullOrEmpty(msg))
            {
                msgLabel.Visible = false;
                return;
            }
            msgLabel.Visible = true;
            msgLabel.Text = msg;
            if (warning)
                msgLabel.ForeColor = Color.Red;
            else
                msgLabel.ForeColor = Color.Black;
        }
    }
}
