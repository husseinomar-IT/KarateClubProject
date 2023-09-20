using Bunifu.Framework.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KarateWindowsFormsApplication
{
    public partial class FrmMembers : FrmScreen
    {
        public FrmMembers()
        {
            InitializeComponent();
        }


        protected DataTable _dataTable = new DataTable();
        protected DataView _dataView = new DataView();


        private FrmMemberList _FrmList;
        private FrmAddMembers _FrmAddMember;
        private FrmUPDMemebr _FrmEditMember;
        private FrmDelMember _FrmDeleteMember;



     
        private void btnFrmMemberList_Click(object sender, EventArgs e)
        {
           
        }

        private void btnFrmAddMember_Click(object sender, EventArgs e)
        {
           
        }

        private void btnFrmUPDMember_Click(object sender, EventArgs e)
        {
            if (_FrmEditMember == null)
            {
                _FrmEditMember = new FrmUPDMemebr();
                _FrmEditMember.FormClosed += FrmEditMember_Closing;
                _FrmEditMember.MdiParent = FrmScreen.ActiveForm;
                _FrmEditMember.Dock = DockStyle.Fill;
                _FrmEditMember.Show();
            }


            else
            {
                _FrmEditMember.Activate();
            }
        }

        private void btnFrmDelMember_Click(object sender, EventArgs e)
        {
            if (_FrmDeleteMember == null)
            {
                _FrmDeleteMember = new FrmDelMember();
                _FrmDeleteMember.FormClosed += FrmDeleteMember_Closing;
                _FrmDeleteMember.MdiParent = FrmScreen.ActiveForm;
                _FrmDeleteMember.Dock = DockStyle.Fill;
                _FrmDeleteMember.Show();
            }


            else
            {
                _FrmDeleteMember.Activate();
            }
        }

        private void btnFrmFindMember_Click(object sender, EventArgs e)
        {
          
        }

        private void FrmMembers_Load(object sender, EventArgs e)
        {
         
        }

        private void pictLogo_Click(object sender, EventArgs e)
        {

        }

      

        private void Frm_MembersList_closing(object sender, FormClosedEventArgs e)
        {
            _FrmList = null;
        }

    

        private void FrmAddMember_Closing(object sender, FormClosedEventArgs e)
        {
            _FrmAddMember = null;
        }

    

        private void FrmEditMember_Closing(object sender, FormClosedEventArgs e)
        {
            _FrmEditMember = null;
        }

       

        private void FrmDeleteMember_Closing(object sender, FormClosedEventArgs e)
        {
            _FrmDeleteMember = null;
        }



 




        private void btnFrmDashboard_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void btnFrmMemberList_Click_1(object sender, EventArgs e)
        {
            if (_FrmList == null)
            {
                _FrmList = new FrmMemberList();
                _FrmList.FormClosed += Frm_MembersList_closing;
                _FrmList.MdiParent = FrmScreen.ActiveForm;
                _FrmList.Dock = DockStyle.Fill;
                _FrmList.Show();
            }


            else
            {
                _FrmList.Activate();
            }
        }

        private void btnFrmAddMember_Click_1(object sender, EventArgs e)
        {

            if (_FrmAddMember == null)
            {
                _FrmAddMember = new FrmAddMembers();
                _FrmAddMember.FormClosed += FrmAddMember_Closing;
                _FrmAddMember.MdiParent = FrmScreen.ActiveForm;
                _FrmAddMember.Dock = DockStyle.Fill;
                _FrmAddMember.Show();
            }


            else
            {
                _FrmAddMember.Activate();
            }
        }



        protected void _CheckTextBoxs(object sender, CancelEventArgs e)
        {
           
        }

    }
}
