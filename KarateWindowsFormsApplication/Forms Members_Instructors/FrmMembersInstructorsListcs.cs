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
    public partial class FrmMembersInstructorsListcs : KarateWindowsFormsApplication.FrmMembers_Instructors
    {
        public FrmMembersInstructorsListcs()
        {
            InitializeComponent();
            _RefreshList();
        }



        private void _RefreshList()
        {
            dataTable1 = clsMembers_Instructors.GetAllAssign();
            dgvAssignList.DataSource = dataTable1;
        }

        private void FrmMembersInstructorsListcs_Load(object sender, EventArgs e)
        {
            btnFrmMembersInstructorsList.Enabled = false;
        }
    }
}
