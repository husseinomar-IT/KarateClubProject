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
    public partial class FrmAddUsercs :FrmUser   
    {
        public FrmAddUsercs()
        {
            InitializeComponent();
            btnFrmAddUser.Enabled = false;
        }
        public clsPerson Person = new clsPerson();

        private void FrmAddUsercs_Load(object sender, EventArgs e)
        {
            btnFrmAddUser.Enabled = false;
          //  CheckTextBoxIsEmpty()
        
        }




     




     







        private void _ReadUserInfo(ref clsUser user)
        {
            user.FirstName = txtFirstName.Text;
            user.LastName = txtLastName.Text;
            user.Email = txtEmail.Text;
            user.Phone = txtPhone.Text;
            user.UserName = txtUserName.Text;
            user.Password = txtPassword.Text;
            user.Permission = _UserPermission;

            if(txtAddress .Text!=string .Empty )
            {
                user.Address = txtAddress.Text;
            }
            else
            {
                user.Address = "";
            }
            //user.Permission = _UserPermission;
        }







        private void _RefreshchkAllPermission()
        {
            chkAllPermission.Checked = false;
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
      


        

        private bool _AddnewUser()
        {
           
            _ReadUserInfo(ref User);
            Person = new clsPerson(User.FirstName, User.LastName, User.Address, User.Email, User.Phone);
            if (Person.Save())
            {
                User.PersonID = Person.PersonID;
              
                return (User.Save());


            }
            return false;

        }
      


        private void checkboxPermission_CheckedChanged(object sender, EventArgs e)
        {
            _SetPermission((BunifuCheckbox)sender);
        }

        private void _SetPermission(BunifuCheckbox chk)
        {
            if (chk.Checked == true)
            {
                _UserPermission += Convert.ToInt16(chk.Tag);
            }
        }



       

    

      

     
     

    

      

        protected void chkAllPermission_OnChange(object sender, EventArgs e)
        {
            pnlSelectdPermission.Enabled = (chkAllPermission.Checked == false) ? true : false;
            _UserPermission = Convert.ToInt16((chkAllPermission.Checked == true) ? -1 : User.Permission);
            _RefreshCheckboxPermission();
        }

     

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Add this User", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (_AddnewUser())
                {
                    if (MessageBox.Show("User Added Successfuly", "Add Member", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        _RefreshScreen();
                        pnlSelectdPermission.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Useer  is not Added ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void txtboxsUser_Validating(object sender, CancelEventArgs e)
        {
            _RequiredField((BunifuMaterialTextbox)sender, e);
        }

   

 

   
    }
}
