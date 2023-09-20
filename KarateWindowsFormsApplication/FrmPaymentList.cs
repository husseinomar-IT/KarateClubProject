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
    public partial class FrmPaymentList : KarateWindowsFormsApplication.FrmScreen
    {
        public FrmPaymentList()
        {
            InitializeComponent();
            _RefrishList();
        }



        private void _RefrishList()
        {
            DataTable _DataTable = clsPayment.GetAllPayments();
            dgvPaymentsList.DataSource = _DataTable;
        }

        protected  override void btnCloseFrm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmPaymentList_Load(object sender, EventArgs e)
        {
          
        }
    }
}
