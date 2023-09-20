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
    public partial class FrmInstructorList : KarateWindowsFormsApplication.FrmInstructor
    {
        public FrmInstructorList()
        {
            InitializeComponent();
            _RefreshInstructorsList();
        }



        protected  void _RefreshInstructorsList()
        {
            _datatable = clsInstructors.GetAllInstructors();
            dgvInstructorList.DataSource = _datatable;
        }

        private void FrmInstructorList_Load(object sender, EventArgs e)
        {
            btnFrmInstructorList.Enabled = false;
        }
    }
}
