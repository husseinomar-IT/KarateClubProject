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
    public partial class FrmEditME_IN : KarateWindowsFormsApplication.FrmAddME_IN
    {
        public FrmEditME_IN()
        {
            InitializeComponent();
            
        }


         struct StAssginInfo {
            public string MemberName;
            public string InstructorName;
            public DateTime  datetime;
        };


         private StAssginInfo _Info = new StAssginInfo();

        private void FrmEditME_IN_Load(object sender, EventArgs e)
        {
            btnAdd.Visible = false;
            //grbAssignInfo.Enabled = false;
            btnFrmAddMemberInstructor.Enabled = true;
            btnFrmEditMemberInstructor.Enabled = false;

            
        }



        protected override void _RefreshScreen()
        {
            listboxInstructor.Items.Clear();
            _FillListWithInstructor();
           listboxMembers.Items.Clear();
            _FillListWithMembers();
            txtME_IN_ID.Text = string.Empty;
        //   grbAssignInfo.Enabled = false;
        }
   

   

     
      

    

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchByID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }



        private void _SetAssignInfo()
        {
            listboxMembers.SelectedItem = _Info.MemberName;
            listboxInstructor.SelectedItem = _Info.InstructorName;
            dateTimePicker1.Value = _Info.datetime;

        }
       

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Instructor with InstructorID [" + _InstructorID + "] is assigned to Member with MemberID:[" + _MemberID + "] At : [" + _datetime + "]", "Information ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                Member_Instructor = new clsMembers_Instructors(Convert.ToInt16(txtME_IN_ID.Text), _MemberID, _InstructorID, _datetime);
                if (Member_Instructor.Save())
                {
                    MessageBox.Show("Assign Updated Successfuly", "Success Updated");
                    _RefreshScreen();

                }
            }
            else
            {
                return;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_onValueChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int Result;
            if (!int.TryParse(txtME_IN_ID.Text, out Result))
            {

                return;

            }


            if (txtME_IN_ID.Text == string.Empty)
            {
                return;
            }

            if (clsMembers_Instructors.FindByID(Convert.ToInt16(txtME_IN_ID.Text), ref _Info.MemberName, ref _Info.InstructorName, ref _Info.datetime))
            {
                _SetAssignInfo();

            }
            else
            {
                if (MessageBox.Show("Assign ID [" + txtME_IN_ID.Text + "] is not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    txtME_IN_ID.Text = string.Empty;
                    return;
                }
            }
        }
    }
}
