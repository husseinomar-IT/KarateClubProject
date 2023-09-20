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
    public partial class FrmDelMember : KarateWindowsFormsApplication.FrmMemberList
    {
        public FrmDelMember()
        {
            InitializeComponent();
        }

        private void FrmDelMember_Load(object sender, EventArgs e)
        {
            btnFrmDelMember.Enabled = false;
            btnFrmMemberList.Enabled = true;
            btnDelete.Enabled = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFrmMembersInstructor_Click(object sender, EventArgs e)
        {

        }



        private bool _FilterDataView()
        {
            _dataView = _dataTable.DefaultView;
            _dataView .RowFilter ="MemberID="+txtMemberID .text +"";
            return (_dataView.Count > 0);
        
        }
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void txtMemberID_OnTextChange(object sender, EventArgs e)
        {
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure You Want To Delete This Member?", "Confirmation Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsMember.IsMemberExsits(Convert.ToInt16(txtMemberID.text)))
                {
                    if (clsMember.DeleteMember(Convert.ToInt16(txtMemberID.text)))
                    {
                        if (MessageBox.Show("Member Delete Successfuly", "Member Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            txtMemberID.text = string.Empty;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Member is not Deleted", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Member is not Exsits", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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
            if (!int.TryParse(txtMemberID.text, out Result))
            {

                _RefreshMembersList();
                btnDelete.Enabled = false;
                return;
            }


            if (txtMemberID.text == string.Empty)
            {
                _RefreshMembersList();
                btnDelete.Enabled = false;
                return;
            }


            if (_FilterDataView())
            {

                dgvMembersList.DataSource = _dataView;

                btnDelete.Enabled = true;
            }
            else
            {
                if (MessageBox.Show("Member with ID [" + txtMemberID.text + "] is not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    //_RefreshMembersList();
                    txtMemberID.text = string.Empty;
                    return;
                }

            }
        }

        //private void txtME_IN_ID_OnTextChange(object sender, EventArgs e)
        //{
        //    int Result;
        //    if (!int.TryParse(txtME_IN_ID.text, out Result))
        //    {
        //       // _FillList();

        //        return;
        //    }


        //    if (txtME_IN_ID.text == string.Empty)
        //    {
        //        return;
        //    }


        //    if (_FilterDataView())
        //    {

        //        dataGridView1.DataSource = dataview;

        //        btnDelete.Enabled = true;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Member  with ID [" + txtME_IN_ID.text + "] is not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        _FillList();
        //        return;
        //    }
        //}
    }
}
