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
    public partial class FrmDelInstructor : KarateWindowsFormsApplication.FrmInstructorList 
    {
        public FrmDelInstructor()
        {
            InitializeComponent();
        }

        private void btnFrmInstructorList_Click(object sender, EventArgs e)
        {

        }

        private void FrmDelInstructor_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnFrmInstructorList.Enabled = true;
            btnFrmDelInstructor.Enabled = false;
        }

   


        private bool _FilterDataView()
        {
            _dataView1 = _datatable.DefaultView;
            _dataView1.RowFilter = "InstructorID=" + txtInstructorID.text + "";
            return (_dataView1 .Count >0);
        }
        private void txtMemberID_OnTextChange(object sender, EventArgs e)
        {
            
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure You Want To Delete This Instructor?", "Confirmation Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsInstructors.IsInstructorExsits(Convert.ToInt16(txtInstructorID.text)))
                {
                    if (clsInstructors.DeleteInstructor(Convert.ToInt16(txtInstructorID.text)))
                    {
                        if (MessageBox.Show("Instructor Delete Successfuly", "Instructor Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            txtInstructorID.text = string.Empty;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Instructor is not Deleted", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Instructor is not Exsits", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int Result;
            if (!int.TryParse(txtInstructorID.text, out Result))
            {

                _RefreshInstructorsList();
                return;
            }


            if (txtInstructorID.text == string.Empty)
            {
                _RefreshInstructorsList();
                return;
            }


            if (_FilterDataView())
            {

                dgvInstructorList.DataSource = _dataView1;

                btnDelete.Enabled = true;
            }
            else
            {
                if (MessageBox.Show("Member with ID [" + txtInstructorID.text + "] is not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    _RefreshInstructorsList();
                    txtInstructorID.text = string.Empty;
                    return;
                }

            }
        }
    }
}
