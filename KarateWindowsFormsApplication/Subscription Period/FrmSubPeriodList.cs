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
    public partial class FrmSubPeriodList : KarateWindowsFormsApplication.FrmSubPeriod
    {
        public FrmSubPeriodList()
        {
            InitializeComponent();
            _RefreshPeriodList();
        }




        protected void _RefreshPeriodList()
        {
            _dataTable = clsSubscriptionPeriod.GetAllSubscriptionPeriod();
            dgvSubPeriodList.DataSource = _dataTable;
        }

        private void btnFrmMemberList_Click(object sender, EventArgs e)
        {
            
        }

        private void FrmSubPeriodList_Load(object sender, EventArgs e)
        {
            btnFrmPeriodList.Enabled = false;
        }

        private void btnFrmEditPeriod_Click(object sender, EventArgs e)
        {
           
        }
    }
}
