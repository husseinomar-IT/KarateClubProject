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
    public partial class FrmDelME_IN : KarateWindowsFormsApplication.FrmMembers_Instructors
    {
        public FrmDelME_IN()
        {
            InitializeComponent();
          //  dataTable1 = clsMembers_Instructors.GetAllAssign();
            _FillList();
        }


        private void _FillList()
        {
            dataTable1 = clsMembers_Instructors.GetAllAssign();
            dataGridView1.DataSource = dataTable1;
        }

     

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure You Want To Delete This Record?", "Confirmation Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsMembers_Instructors.IsAssignExsits(Convert.ToInt16 (txtME_IN_ID .text )))
                {
                    if (clsMembers_Instructors.Delete(Convert.ToInt16(txtME_IN_ID.Text)))
                    {
                        if (MessageBox.Show("Record Delete Successfuly", "Record Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            txtME_IN_ID.Text = string.Empty;
                             _FillList();
                            
                        }
                    }
                    else
                    {
                        MessageBox.Show("Reocord is not Deleted", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Record is not Exsits", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }

    

        private void btnCanacel_Click(object sender, EventArgs e)
        {

        }


        private bool _FilterDataView()
        {
            dataview = dataTable1.DefaultView;
            dataview.RowFilter = "Member_Instructor_ID=" + txtME_IN_ID.text  + "";
            return (dataview.Count > 0);
          
        }

        private void txtME_IN_ID_OnTextChange(object sender, EventArgs e)
        {
            
        }

        private void FrmDelME_IN_Load(object sender, EventArgs e)
        {
            btnFrmDelMemberInstructor.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int Result;
            if (!int.TryParse(txtME_IN_ID.text, out Result))
            {
                _FillList();

                return;
            }


            if (txtME_IN_ID.text == string.Empty)
            {
                return;
            }


            if (_FilterDataView())
            {

                dataGridView1.DataSource = dataview;

                btnDelete.Enabled = true;
            }
            else
            {
                MessageBox.Show("Members Instructors  with ID [" + txtME_IN_ID.text + "] is not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _FillList();
                return;
            }
        }
    }
}
