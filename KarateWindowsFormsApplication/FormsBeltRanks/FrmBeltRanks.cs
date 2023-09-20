using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Bunifu.Framework.UI;


namespace KarateWindowsFormsApplication
{
    public partial class FrmBeltRanks : FrmScreen 
    {
        public FrmBeltRanks()
        {
            InitializeComponent();
          
        }


        public DataTable datatable = new DataTable();
        public DataView dataview1 = new DataView();


        private FrmBeltList _FrmList;
        private FrmEditBeltcs _FrmEdit;

        private void btnFrmDelMember_Click(object sender, EventArgs e)
        {
            //FrmDeleteBelt FrmDelete = new FrmDeleteBelt();
            //FrmDelete.ShowDialog();
        }

        private void btnFrmUPDMember_Click(object sender, EventArgs e)
        {
            FrmEditBeltcs FrmEdit = new FrmEditBeltcs();
            FrmEdit.ShowDialog();
        }

        private void btnFrmMemberList_Click(object sender, EventArgs e)
        {
            FrmBeltList FrmList = new FrmBeltList();
            FrmList.ShowDialog();
        }

        private void FrmBeltRanks_Load(object sender, EventArgs e)
        {
          
          
        }

      

  

        private void btnFrmDelUser_Click(object sender, EventArgs e)
        {
            //FrmDeleteBelt FrmDelete = new FrmDeleteBelt();
            //FrmDelete.ShowDialog();
        }

        private void btnFrmDashboard_Click(object sender, EventArgs e)
        {

        }

        private void btnFrmMembers_Click(object sender, EventArgs e)
        {

        }

        private void btnFrmInstructor_Click(object sender, EventArgs e)
        {

        }

        private void btnFrmUsers_Click(object sender, EventArgs e)
        {

        }

        private void btnFrmMembersInstructor_Click(object sender, EventArgs e)
        {

        }

        private void btnFrmSubscription_Click(object sender, EventArgs e)
        {

        }

        private void btnFrmBeltRanks_Click(object sender, EventArgs e)
        {

        }

        private void btnFrmBeltList_Click(object sender, EventArgs e)
        {
            if (_FrmList == null)
            {
                _FrmList = new FrmBeltList();
                _FrmList.FormClosed += Frm_BeltRankList_closing;
                _FrmList.MdiParent = FrmScreen.ActiveForm;
                _FrmList.Dock = DockStyle.Fill;
                _FrmList.Show();
            }


            else
            {
                _FrmList.Activate();
            }
        }

        private void Frm_BeltRankList_closing(object sender, FormClosedEventArgs e)
        {
            _FrmList = null;
        }

        private void btnFrmEditBelt_Click(object sender, EventArgs e)
        {
            if (_FrmEdit == null)
            {
                _FrmEdit = new FrmEditBeltcs();
                _FrmEdit.FormClosed += Frm_EditBeltRank_closing;
                _FrmEdit.MdiParent = FrmScreen.ActiveForm;
                _FrmEdit.Dock = DockStyle.Fill;
                _FrmEdit.Show();
            }


            else
            {
                _FrmEdit.Activate();
            }
        }

        private void Frm_EditBeltRank_closing(object sender, FormClosedEventArgs e)
        {
            _FrmEdit = null;
        }



        protected void _CheckTextBoxs(object sender, CancelEventArgs e)
        {
          
        }
    }
}
