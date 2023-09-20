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
    public partial class FrmBeltTestList : KarateWindowsFormsApplication.FrmBeltTest
    {
        public FrmBeltTestList()
        {
            InitializeComponent();
            _RefrishTestsList();
        }




        protected  void _RefrishTestsList()
        {
            _dataTable = clsBeltTest.GetAllBeltTests();
            dgvBeltTestsList.DataSource = _dataTable;
        }
        private void FrmBeltTestList_Load(object sender, EventArgs e)
        {
            btnFrmTestsList.Enabled = false;
        }
    }
}
