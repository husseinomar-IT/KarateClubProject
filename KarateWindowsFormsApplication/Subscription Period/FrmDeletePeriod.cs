using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KarateBusinisLayer;

namespace KarateWindowsFormsApplication
{
    public partial class FrmDeletePeriod : KarateWindowsFormsApplication.FrmSubPeriodList
    {
        public FrmDeletePeriod()
        {
            InitializeComponent();
        }



        private bool _FilterDataView()
        {
            _dataview1  = _dataTable.DefaultView;
            _dataview1.RowFilter = "PeriodID=" + txtPeriodID .text  + "";
            return (_dataview1.Count > 0);
        }
        private void txtPeriodID_OnTextChange(object sender, EventArgs e)
        {
           
        }

        private void FrmDeletePeriod_Load(object sender, EventArgs e)
        {
            btnFrmPeriodList.Enabled = true ;
            btnFrmDelPeriod.Enabled = false;
            btnDelete.Enabled = false ;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int Result;
            if (!int.TryParse(txtPeriodID.text, out Result))
            {
                _RefreshPeriodList();
                return;

            }


            if (txtPeriodID.text == string.Empty)
            {
                return;
            }
            //_dataTable = clsBeltTest.GetAllBeltTests();
            if (_FilterDataView())
            {
                dgvSubPeriodList.DataSource = _dataview1;
                btnDelete.Enabled = true;
            }
            else
            {
                MessageBox.Show("Period   with ID [" + txtPeriodID.text + "] is not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _RefreshPeriodList();
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure You Want To Delete This Period?", "Confirmation Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsSubscriptionPeriod.IsPeriodExsits(Convert.ToInt16(txtPeriodID.text)))
                {
                    if (clsSubscriptionPeriod.Delete(Convert.ToInt16(txtPeriodID.text)))
                    {
                        if (MessageBox.Show("Period Delete Successfuly", "Period Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            txtPeriodID.text = string.Empty;
                            _RefreshPeriodList();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Period is not Deleted", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Period is not Exsits", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }
    }
}
