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
    public partial class FrmDeleteBeltTest : KarateWindowsFormsApplication.FrmBeltTestList
    {
        public FrmDeleteBeltTest()
        {
            InitializeComponent();

        }


        private bool _FilterDataView()
        {
            _dataView1 = _dataTable.DefaultView;
            _dataView1.RowFilter = "TestID=" + txtTestID.text + "";
            return (_dataView1.Count > 0);
        }
        private void txtPeriodID_OnTextChange(object sender, EventArgs e)
        {

           

          
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure You Want To Delete This Belt Test?", "Confirmation Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsBeltTest .IsBeltTestExsits(Convert.ToInt16(txtTestID .text )))
                {
                    if ((clsBeltTest .Delete(Convert.ToInt16(txtTestID .text ))))
                    {
                        if (MessageBox.Show("Belt Test Deleted Successfuly", "Record Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            txtTestID.text  = string.Empty;
                            _RefrishTestsList();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Belt Test is not Deleted", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Belt Test is not Exsits", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmDeleteBeltTest_Load(object sender, EventArgs e)
        {
            btnFrmTestsList.Enabled = true;
            btnDelete.Enabled = false ;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int Result;
            if (!int.TryParse(txtTestID.text, out Result))
            {
                _RefrishTestsList();
                return;
            }


            if (txtTestID.text == string.Empty)
            {
                return;
            }
            //_dataTable = clsBeltTest.GetAllBeltTests();
            if (_FilterDataView())
            {
                dgvBeltTestsList.DataSource = _dataView1;
                btnDelete.Enabled = true;
            }
            else
            {
                MessageBox.Show("Belt Test with ID [" + txtTestID.text + "] is not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _RefrishTestsList();
                return;
            }
        }
    }
}
