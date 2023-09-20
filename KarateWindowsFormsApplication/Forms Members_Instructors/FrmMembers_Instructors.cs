using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace KarateWindowsFormsApplication
{
    public partial class FrmMembers_Instructors :FrmScreen 
    {
        public FrmMembers_Instructors()
        {
            InitializeComponent();
        }


        public DataTable dataTable1 = new DataTable();
        public DataView dataview = new DataView();



        private FrmMembersInstructorsListcs _FrmList;
        private FrmAddME_IN _FrmAdd;
        private FrmDelME_IN _FrmDelete;
        private FrmEditME_IN _FrmEdit;

        private void btnFrmMemberList_Click(object sender, EventArgs e)
        {
            FrmMembersInstructorsListcs Frm = new FrmMembersInstructorsListcs();
            Frm.Show();
        }

        private void btnFrmUPDMember_Click(object sender, EventArgs e)
        {
            FrmEditME_IN FrmEdit = new FrmEditME_IN();
            FrmEdit.Show();
        }

        private void btnFrmAddMember_Click(object sender, EventArgs e)
        {

        
          
        }

        private void btnFrmDelMember_Click(object sender, EventArgs e)
        {
            FrmDelME_IN FrmDelete = new FrmDelME_IN();
            FrmDelete.Show();
        }

      

        private void FrmMembers_Instructors_Load(object sender, EventArgs e)
        {
          
        }

     

        private void Frm_Members_Instructors_List_closing(object sender, FormClosedEventArgs e)
        {
            _FrmList = null;
        }

   
        private void Frm_Members_Instructors_Add_closing(object sender, FormClosedEventArgs e)
        {
            _FrmAdd = null;
        }

  

        private void Frm_Members_Instructors_Edit_closing(object sender, FormClosedEventArgs e)
        {
            _FrmEdit = null;
        }

     

        private void Frm_Members_Instructors_Delete_closing(object sender, FormClosedEventArgs e)
        {
            _FrmDelete = null;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnFrmMembersInstructorsList_Click(object sender, EventArgs e)
        {
            if (_FrmList == null)
            {
                _FrmList = new FrmMembersInstructorsListcs();
                _FrmList.FormClosed += Frm_Members_Instructors_List_closing;
                _FrmList.MdiParent = FrmScreen.ActiveForm;
                _FrmList.Dock = DockStyle.Fill;
                _FrmList.Show();
            }


            else
            {
                _FrmList.Activate();
            }
        }

        private void btnFrmAddMemberInstructor_Click(object sender, EventArgs e)
        {
            if (_FrmAdd == null)
            {
                _FrmAdd = new FrmAddME_IN();
                _FrmAdd.FormClosed += Frm_Members_Instructors_Add_closing;
                _FrmAdd.MdiParent = FrmScreen.ActiveForm;
                _FrmAdd.Dock = DockStyle.Fill;
                _FrmAdd.Show();
            }


            else
            {
                _FrmAdd.Activate();
            }
        }

        private void btnFrmEditMemberInstructor_Click(object sender, EventArgs e)
        {
            if (_FrmEdit == null)
            {
                _FrmEdit = new FrmEditME_IN();
                _FrmEdit.FormClosed += Frm_Members_Instructors_Edit_closing;
                _FrmEdit.MdiParent = FrmScreen.ActiveForm;
                _FrmEdit.Dock = DockStyle.Fill;
                _FrmEdit.Show();
            }


            else
            {
                _FrmAdd.Activate();
            }
        }

        private void btnFrmDelMemberInstructor_Click(object sender, EventArgs e)
        {
            if (_FrmDelete == null)
            {
                _FrmDelete = new FrmDelME_IN();
                _FrmDelete.FormClosed += Frm_Members_Instructors_Delete_closing;
                _FrmDelete.MdiParent = FrmScreen.ActiveForm;
                _FrmDelete.Dock = DockStyle.Fill;
                _FrmDelete.Show();
            }


            else
            {
                _FrmDelete.Activate();
            }
        }

    }
}
