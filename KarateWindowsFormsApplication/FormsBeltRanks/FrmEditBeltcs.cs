using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KarateBusinisLayer;
using Bunifu.Framework.UI;

namespace KarateWindowsFormsApplication
{
    public partial class FrmEditBeltcs : KarateWindowsFormsApplication.FrmBeltRanks
    {
        public FrmEditBeltcs()
        {
            InitializeComponent();
        }

        private clsBeltRankcs _BeltRank = new clsBeltRankcs();

        private void FrmEditBeltcs_Load(object sender, EventArgs e)
        {
            btnFrmEditBelt.Enabled = false;
            btnSave.Enabled = false;
        }

     

        private void _ReadBeltInfo(ref clsBeltRankcs Belt)
        {
            Belt.RankName = txtBeltName.Text;
            Belt.TestFees = Convert.ToSingle(txtTestFees.Text);
        }



        private void _RefreshScreen()
        {
            txtRankID.Text = string.Empty;
            txtRankID.Focus();
            txtBeltName.Text = string.Empty;
            txtTestFees.Text = string.Empty;
            btnSave.Enabled = false;
        }
        private bool _UpdateBelt()
        {
            _ReadBeltInfo(ref _BeltRank);
            return (_BeltRank.Update());

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int Result;

            if (!int.TryParse(txtRankID.Text, out Result))
            {
                _RefreshScreen();
                return;
            }
            if (txtRankID.Text == string.Empty)
            {
                _RefreshScreen();
                return;
            }
            _BeltRank = clsBeltRankcs.Find(Convert.ToInt16(txtRankID.Text));
            if (_BeltRank != null)
            {
                btnSave.Enabled = true;
                txtBeltName.Text = _BeltRank.RankName;
                txtTestFees.Text = _BeltRank.TestFees.ToString();
            }
            else
            {
                if (MessageBox.Show("BeltRank with ID[" + txtRankID.Text + "] is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    txtRankID.Text = string.Empty;
                    txtRankID.Focus();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_UpdateBelt())
            {
                if (MessageBox.Show("Belt Rank Update succsuufuly", " Update Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    _RefreshScreen();
                    return;
                }
                else
                {
                    MessageBox.Show("Belt Rank not  Updated ", " Error Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void txtboxsBeltRanks_Validating(object sender, CancelEventArgs e)
        {
            _RequiredField((BunifuMaterialTextbox)sender, e);
        }

     
    }
}