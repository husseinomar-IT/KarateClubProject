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
    public partial class FrmInstructor :FrmScreen
    {
        public FrmInstructor()
        {
            InitializeComponent();
        }


        protected  DataTable _datatable = new DataTable();
        protected DataView _dataView1 = new DataView();



        private FrmInstructorList _FrmList;
        private FrmAddInstructor _FrmAdd;
        private FrmEditInstructor _FrmEdit;
        private FrmDelInstructor _FrmDelete;
        private void btnFrmInstructorList_Click(object sender, EventArgs e)
        {
            FrmInstructorList FrmList = new FrmInstructorList();
            FrmList.ShowDialog();
        }

        private void btnFrmAddInstructor_Click(object sender, EventArgs e)
        {
            FrmAddInstructor FrmAdd = new FrmAddInstructor();
            FrmAdd.ShowDialog();
        }

        private void btnFrmEditInstructor_Click(object sender, EventArgs e)
        {
            FrmEditInstructor FrmEdit = new FrmEditInstructor();
            FrmEdit.ShowDialog();
        }

        private void btnFrmDelInstructor_Click(object sender, EventArgs e)
        {
            FrmDelInstructor FrmDelete = new FrmDelInstructor();
            FrmDelete.ShowDialog();
        }

      

        private void FrmInstructor_Load(object sender, EventArgs e)
        {
           
        }

        private void btnFrmMemberList_Click(object sender, EventArgs e)
        {
            if (_FrmList == null)
            {
                _FrmList = new FrmInstructorList ();
                _FrmList.FormClosed += FrmInstructorList_Closing;
                _FrmList.MdiParent = FrmScreen.ActiveForm;
                _FrmList.Dock = DockStyle.Fill;
                _FrmList.Show();
            }


            else
            {
                _FrmList.Activate();
            }
        }

        private void FrmInstructorList_Closing(object sender, FormClosedEventArgs e)
        {
            _FrmList = null;
        }

        private void btnFrmAddMember_Click(object sender, EventArgs e)
        {
            if (_FrmAdd  == null)
            {
                _FrmAdd = new FrmAddInstructor();
                _FrmAdd.FormClosed += FrmAddInstructor_Closing;
                _FrmAdd.MdiParent = FrmScreen.ActiveForm;
                _FrmAdd.Dock = DockStyle.Fill;
                _FrmAdd.Show();
            }


            else
            {
                _FrmAdd.Activate();
            }
        }

        private void FrmAddInstructor_Closing(object sender, FormClosedEventArgs e)
        {
            _FrmAdd = null;
        }

        private void btnFrmUPDMember_Click(object sender, EventArgs e)
        {
            if (_FrmEdit == null)
            {
                _FrmEdit = new FrmEditInstructor();
                _FrmEdit.FormClosed += FrmEditInstructor_Closing;
                _FrmEdit.MdiParent = FrmScreen.ActiveForm;
                _FrmEdit.Dock = DockStyle.Fill;
                _FrmEdit.Show();
            }


            else
            {
                _FrmEdit.Activate();
            }
        }

        private void FrmEditInstructor_Closing(object sender, FormClosedEventArgs e)
        {
            _FrmEdit = null;
        }

        private void btnFrmDelMember_Click(object sender, EventArgs e)
        {
            if (_FrmDelete == null)
            {
                _FrmDelete = new FrmDelInstructor();
                _FrmDelete.FormClosed += FrmDeleteInstructor_Closing;
                _FrmDelete.MdiParent = FrmScreen.ActiveForm;
                _FrmDelete.Dock = DockStyle.Fill;
                _FrmDelete.Show();
            }


            else
            {
                _FrmDelete.Activate();
            }
        }

        private void FrmDeleteInstructor_Closing(object sender, FormClosedEventArgs e)
        {
            _FrmDelete = null;
        }

        private void btnFrmFindMember_Click(object sender, EventArgs e)
        {
          
        }
        protected void _CheckTextBoxs(object sender, CancelEventArgs e)
        {
           
        }
    }
}
