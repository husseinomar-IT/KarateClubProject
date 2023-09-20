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
    public  partial class FrmUser : FrmScreen    
        //KarateWindowsFormsApplication.FrmMainMenue
    {
        public FrmUser()
        {
            InitializeComponent();
        }
        protected clsUser User = new clsUser();
        protected Int16 _UserPermission;


        protected DataTable _datatable = new DataTable();
        protected DataView _dataview = new DataView();




        protected FrmAddUsercs _FrmAdd;
        protected FrmEditUser _FrmEdit;
        protected FrmDelUser _FrmDelete;







    
      

     
        private void FrmUser_Load(object sender, EventArgs e)
        {
           
          
            //btnFrmAddUser.Visible = false;
            //btnFrmDelUser.Visible = false;
            //btnFrmUPDUser.Visible = false;
            //picboxLogo.Visible = false;
            //lblTitle.Visible = false;
           
        }

    
        private void btnFrmAddMember_Click(object sender, EventArgs e)
        {


            if (_FrmAdd == null)
            {
                _FrmAdd = new FrmAddUsercs();
                _FrmAdd.FormClosed += FrmAddUser_Closing;
                _FrmAdd.MdiParent = FrmScreen.ActiveForm;
                _FrmAdd.Dock = DockStyle.Fill;
                _FrmAdd.Show();
            }


            else
            {
                _FrmAdd.Activate();
            }
         
            //FrmAddUsercs frmAdd = new FrmAddUsercs();
            //frmAdd.ShowDialog();
        }

        private void FrmAddUser_Closing(object sender, FormClosedEventArgs e)
        {
            _FrmAdd = null;
        }

      

        private void btnFrmDelMember_Click(object sender, EventArgs e)


        {



            if (_FrmDelete == null)
            {


                _FrmDelete = new FrmDelUser();
               _FrmDelete.FormClosed += FrmDeleteUser_Closing;
               _FrmDelete.MdiParent = FrmScreen.ActiveForm;
                _FrmDelete.Dock = DockStyle.Fill;
                _FrmDelete.Show();
            }


            else
            {
                _FrmDelete.Activate();
            }
            //FrmDelUser frmDelte = new FrmDelUser();
            //frmDelte.ShowDialog();
        }

        private void FrmDeleteUser_Closing(object sender, FormClosedEventArgs e)
        {
           _FrmDelete = null;
        }

        private void btnFrmUPDUser_Click_1(object sender, EventArgs e)
        {


            if (_FrmEdit == null)
            {
                _FrmEdit = new FrmEditUser ();
                _FrmEdit.FormClosed +=FrmEditUser_Closing;
                _FrmEdit.MdiParent = FrmScreen.ActiveForm;
                _FrmEdit.Dock = DockStyle.Fill;
                _FrmEdit.Show();
            }


            else
            {
                _FrmEdit.Activate();
            }
          
        }

        private void FrmEditUser_Closing(object sender, FormClosedEventArgs e)
        {
           _FrmEdit = null;
        }

        private void btnFrmUsers_Click(object sender, EventArgs e)
        {
            
        }


    
    

    }
}
