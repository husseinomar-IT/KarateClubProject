using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KarateWindowsFormsApplication
{
    public partial class FrmBeltTest : FrmScreen 
    {
        public FrmBeltTest()
        {
            InitializeComponent();
        }
        protected  DataTable _dataTable = new DataTable();
        protected DataView _dataView1 = new DataView();



        private FrmBeltTestList _FrmList;
        private FrmAddBeltTest _FrmAdd;
        private FrmEditBeltTest _FrmEdit;
        private FrmDeleteBeltTest _FrmDelete;
      
        private void FrmBeltTest_Load(object sender, EventArgs e)
        {
          
        }

        private void btnFrmTestsList_Click(object sender, EventArgs e)
        {
            if (_FrmList == null)
            {
                _FrmList = new FrmBeltTestList();
                _FrmList.FormClosed += Frm_BeltTestkList_closing;
                _FrmList.MdiParent = FrmScreen.ActiveForm;
                _FrmList.Dock = DockStyle.Fill;
                _FrmList.Show();
            }


            else
            {
                _FrmList.Activate();
            }
        }

        private void Frm_BeltTestkList_closing(object sender, FormClosedEventArgs e)
        {
            _FrmList = null;
        }

        private void btnFrmUPDMember_Click(object sender, EventArgs e)
        {
            if (_FrmEdit == null)
            {
                _FrmEdit = new FrmEditBeltTest();
                _FrmEdit.FormClosed += Frm_EditBeltTestk_closing;
                _FrmEdit.MdiParent = FrmScreen.ActiveForm;
                _FrmEdit.Dock = DockStyle.Fill;
                _FrmEdit.Show();
            }


            else
            {
                _FrmEdit.Activate();
            }
        }

        private void Frm_EditBeltTestk_closing(object sender, FormClosedEventArgs e)
        {
            _FrmEdit = null;
        }

        private void btnFrmAddBeltTest_Click(object sender, EventArgs e)
        {
            if (_FrmAdd  == null)
            {
                _FrmAdd = new FrmAddBeltTest();
                _FrmAdd.FormClosed += Frm_AddBeltTestk_closing;
                _FrmAdd.MdiParent = FrmScreen.ActiveForm;
                _FrmAdd.Dock = DockStyle.Fill;
                _FrmAdd.Show();
            }


            else
            {
                _FrmAdd.Activate();
            }
        }

        private void Frm_AddBeltTestk_closing(object sender, FormClosedEventArgs e)
        {
            _FrmAdd = null;
        }

        private void btnFrmDelMember_Click(object sender, EventArgs e)
        {
            if (_FrmDelete == null)
            {
                _FrmDelete = new FrmDeleteBeltTest();
                _FrmDelete.FormClosed += Frm_DeleteBeltTestk_closing;
                _FrmDelete.MdiParent = FrmScreen.ActiveForm;
                _FrmDelete.Dock = DockStyle.Fill;
                _FrmDelete.Show();
            }


            else
            {
                _FrmDelete.Activate();
            }
        }

        private void Frm_DeleteBeltTestk_closing(object sender, FormClosedEventArgs e)
        {
            _FrmDelete = null;
        }
    }
}
