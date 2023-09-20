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
    public partial class FrmEditUser : KarateWindowsFormsApplication.FrmUser
    {
        public FrmEditUser()
        {
            InitializeComponent();
         
        }

       
        private void _GetUserInfo()
        {
            txtFirstName.Text = User.FirstName;
            txtLastName.Text = User.LastName;
            txtEmail.Text = User.Email;
            txtAddress.Text = User.Address;
            txtUserName.Text = User.UserName;
            txtPassword.Text = User.Password;
            txtPhone.Text = User.Phone;
            _UserPermission = (short )User.Permission;
            _GetUserPermission();
        }




        private void _UncheckedPermission()
        {
            chkDashboard.Checked = false;
            chkInstructor.Checked = false;
            chkMember.Checked = false;
            chkUser.Checked = false;
            chkPayments.Checked = false;
            chkSubscription.Checked = false;
            chkBeltRanks.Checked = false;
            chkBeltTest.Checked = false;
            chkMember_Instructor.Checked = false;
            pnlSelectdPermission.Enabled = false;
        }
        private void _GetUserPermission()
        {
            if (User.Permission == -1)
            {
                chkAllPermission.Checked = true;
                _UncheckedPermission();
                return;
            }


            chkAllPermission.Checked = false;



            if ((User.Permission & Convert.ToInt16(chkDashboard.Tag)) == 1)
            {
                chkDashboard.Checked = true;
            }


            if ((User.Permission & Convert.ToInt16(chkMember.Tag)) == 2)
              {
                  chkMember.Checked = true;
              }




              if ((User.Permission & Convert.ToInt16(chkInstructor.Tag)) == 4)
              {
                  chkInstructor.Checked = true;
              }





              if ((User.Permission & Convert.ToInt16(chkUser.Tag )) == 8)
              {
                  chkUser.Checked = true;
              }

              if ((User.Permission & Convert.ToInt16(chkMember_Instructor.Tag )) == 16)
              {
                  chkMember_Instructor.Checked = true;
              }




              if ((User.Permission & Convert.ToInt16(chkBeltRanks.Tag)) == 32)
              {
                  chkBeltRanks.Checked = true;
              }









              if ((User.Permission & Convert.ToInt16(chkSubscription.Tag)) == 64)
              {
                  chkSubscription.Checked = true;
              }


              if ((User.Permission & Convert.ToInt16(chkBeltTest.Tag)) == 128)
              {
                  chkBeltTest.Checked = true;
              }




              if ((User.Permission & Convert.ToInt16(chkPayments.Tag)) == 256)
              {
                  chkPayments.Checked = true;
              }





        }


        private void FrmEditUser_Load(object sender, EventArgs e)
        {
            btnFrmUPDUser.Enabled = false;
            _GetUserInfo();
            //pnlSelectdPermission.Visible = true ;
            //groupBox2.Visible  = false;
         //   groupBox3.Visible = false;
        }


        private void checkboxPermission_CheckedChanged(object sender, EventArgs e)
        {
            _SetPermission((BunifuCheckbox )sender);
        }

        private void _SetPermission(BunifuCheckbox chk)
        {
            if (chk.Checked == true)
            {
                _UserPermission += Convert.ToInt16(chk.Tag);
            }
            else
            {
                _UserPermission -= Convert.ToInt16(chk.Tag);
            }
        }



   

       

        private void chkAllPermission_CheckedChanged(object sender, EventArgs e)
        {
            pnlSelectdPermission.Enabled = (chkAllPermission.Checked == false) ? true : false;
            _UserPermission = Convert.ToInt16 ((chkAllPermission.Checked == true) ? -1 : 0);
            _RefreshCheckboxPermission();
        }





        private void _ReadUserInfo(ref clsUser user)
        {
            user.FirstName = txtFirstName.Text;
            user.LastName = txtLastName.Text;
            user.Email = txtEmail.Text;
            user.Phone = txtPhone.Text;
            user.Address = txtAddress.Text;
            user.UserName = txtUserName.Text;
            user.Password = txtPassword.Text;
            user.Permission = _UserPermission;
        }



        private void _RefreshchkAllPermission()

        {
            chkAllPermission.Checked = true;
          
        }
        private void _RefreshCheckboxPermission()
        {
            //chkAllPermission.Checked = false;
            chkMember.Checked = false;
            chkInstructor.Checked = false;
            chkMember_Instructor.Checked = false;
            chkBeltTest.Checked = false;
            chkBeltRanks.Checked = false;
            chkDashboard.Checked = false;
            chkPayments.Checked = false;
            chkSubscription.Checked = false;
            chkUser.Checked = false;
        }
        private void _RefreshScreen()
        {
            txtSearchByID.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            _RefreshchkAllPermission();
            _RefreshCheckboxPermission();
        }
        private bool _UpdateUser()
        {

            _ReadUserInfo(ref User);
            return (User.Save());
        }

     

      

   

        private void btnFrmDelUser_Click(object sender, EventArgs e)
        {

        }

    




        

        

        private void chkAllPermission_OnChange(object sender, EventArgs e)
        {

        }

    

        private void txtSearchByID_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void btnFrmUPDUser_Click(object sender, EventArgs e)
        {

        }

        private void btnFrmAddUser_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Update this User", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (_UpdateUser())
                {
                    if (MessageBox.Show("User Update succsuufuly", " Update Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        _RefreshScreen();

                    }
                    else
                    {
                        MessageBox.Show("User not  Updated ", " Error Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int Result;

            if (!int.TryParse(txtSearchByID.Text, out Result))
            {
                _RefreshScreen();
                return;
            }
            if (txtSearchByID.Text == string.Empty)
            {
                _RefreshScreen();
                return;
            }

            User = clsUser.Find(Convert.ToInt16(txtSearchByID.Text));
            if (User != null)
            {
                _GetUserInfo();
                CardInfo.Enabled = true;

            }
            else
            {
                if (MessageBox.Show("The Member with ID[" + txtSearchByID.Text + "] is not Found", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    txtSearchByID.Text = string.Empty;
                    txtSearchByID.Focus();
                }
            }
        }

        private void txtboxsUser_Validating(object sender, CancelEventArgs e)
        {
            _RequiredField((BunifuMaterialTextbox)sender, e);
        }

       
    }
}
