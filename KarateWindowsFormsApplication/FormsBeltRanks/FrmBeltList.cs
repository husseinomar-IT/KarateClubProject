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
    public partial class FrmBeltList : KarateWindowsFormsApplication.FrmBeltRanks
    {
        public FrmBeltList()
        {
            InitializeComponent();
            _RefrishList();
        }

        private void FrmBeltList_Load(object sender, EventArgs e)
        {
            btnFrmBeltList.Enabled = false;
        }



        private void _RefrishList()
        {
            datatable = clsBeltRankcs.GetAllBeltRanks();
            dgvBeltTist.DataSource = datatable;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchByID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
