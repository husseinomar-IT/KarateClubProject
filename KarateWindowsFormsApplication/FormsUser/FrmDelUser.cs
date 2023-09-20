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
    public partial class FrmDelUser : KarateWindowsFormsApplication.FrmUser
    {
        public FrmDelUser()
        {
            InitializeComponent();
            _RefreishUsersList();
        }




        
        private void FrmDelUser_Load(object sender, EventArgs e)
        {
            btnFrmDelUser.Enabled = false;
            btnDelete.Enabled = false;
        }

   




        private void _RefreishUsersList()
        {
            _datatable = clsUser.GetAllUsers();
            dgvUserList.DataSource = _datatable;
        }
        private void btnFrmDelUser_Click(object sender, EventArgs e)
        {

        }

   

        private void btnCanacel_Click(object sender, EventArgs e)
        {

        }


        private bool _FilterDataView()
        {
            _dataview  = _datatable.DefaultView;
            _dataview.RowFilter = "UserID=" + txtUserID .text  + "";
            return (_dataview.Count > 0);

        }

     
     

        private void btnFrmUPDUser_Click(object sender, EventArgs e)
        {

        }

        private void btnFrmAddUser_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure You Want To Delete This User?", "Confirmation Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsUser.IsUserExsist(txtUserID.text))
                {
                    if (User.Delet())
                    {
                        if (MessageBox.Show("User Delete Successfuly", "User Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            txtUserID.text = string.Empty;
                            _RefreishUsersList();
                        }
                    }
                    else
                    {
                        MessageBox.Show("User is not Deleted", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("User is not Exsits", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }
        }

        private void txtUserID_OnTextChange(object sender, EventArgs e)
        {
           

            }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int Result;
            if (!int.TryParse(txtUserID.text, out Result))
            {

                _RefreishUsersList();
                return;
            }


            if (txtUserID.text == string.Empty)
            {
                _RefreishUsersList();
                return;
            }


            if (_FilterDataView())
            {

                dgvUserList.DataSource = _dataview;
                btnDelete.Enabled = true;
            }
            else
            {
                if (MessageBox.Show("User with ID [" + txtUserID.text + "] is not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    //_RefreshMembersList();
                    txtUserID.text = string.Empty;
                    return;
                }
        }
        }
    }
}
