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
    public partial class FrmMemberList : KarateWindowsFormsApplication.FrmMembers
    {
        public FrmMemberList()
        {
            InitializeComponent();
            _RefreshMembersList();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        protected  void _RefreshMembersList()
        {
            _dataTable = clsMember.GetAllMembers();

            dgvMembersList.DataSource = _dataTable;
            
            
        }
        private void FrmMemberList_Load(object sender, EventArgs e)
        {
            btnFrmMemberList.Enabled = false;
          
        }
    }
}
