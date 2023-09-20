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
    public partial class FrmAddME_IN : KarateWindowsFormsApplication.FrmMembers_Instructors
    {
        public FrmAddME_IN()
        {
            InitializeComponent();

          

            _FillListWithMembers();
            _FillListWithInstructor();
          
        }
        protected int _MemberID = -1;
        protected int _InstructorID = -1;
        protected DateTime _datetime = new DateTime();
        protected clsMembers_Instructors Member_Instructor = new clsMembers_Instructors();

        protected void _FillListWithMembers()
        {
            dataTable1 = clsMember.GetAllMembers();
            foreach (DataRow Row in dataTable1.Rows )
            {
                listboxMembers.Items.Add(Row["FullName"]);
            }
        }


        protected  void _FillListWithInstructor()
        {
            dataTable1 = clsInstructors.GetAllInstructors();
            foreach (DataRow Row in dataTable1.Rows)
            {
                listboxInstructor.Items.Add(Row["FullName"]);
            }
        }

        private void FrmAddME_IN_Load(object sender, EventArgs e)
        {
            btnFrmAddMemberInstructor.Enabled = false;
        }



        protected virtual   void _RefreshScreen()
        {
            listboxInstructor.Items.Clear();
            _FillListWithInstructor();
            listboxMembers.Items.Clear();
            _FillListWithMembers();
        }
        
        private void listboxMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            _MemberID = clsMember.GetMemberIDByFullName(listboxMembers.SelectedItem.ToString());
        }

        private void listboxInstructor_SelectedIndexChanged(object sender, EventArgs e)
        {
            _InstructorID = clsInstructors.GetInstructorIDByFullName(listboxInstructor.SelectedItem.ToString());
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            _datetime = dateTimePicker1.Value;
        }

        protected virtual void button1_Click(object sender, EventArgs e)
        {
            
           if( MessageBox.Show("Instructor with InstructorID ["+_InstructorID +"] is assigned to Member with MemberID:["+_MemberID +"] At : ["+_datetime +"]", "Information ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)==DialogResult .OK )
           {
               Member_Instructor = new clsMembers_Instructors(_MemberID, _InstructorID, _datetime);
               if(Member_Instructor.Save ())
               {
                   MessageBox.Show("Assign Added Successfuly", "Success Add");
                   _RefreshScreen();
               }
           }
           else
           {
               return;
           }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void lstboxMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
           // _MemberID =clsMember.GetMemberIDByFullName()
        }

       

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _MemberID = clsMember.GetMemberIDByFullName(listboxMembers.SelectedItem.ToString());
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            _InstructorID = clsInstructors.GetInstructorIDByFullName(listboxInstructor.SelectedItem.ToString());
        }

        private void dateTimePicker1_onValueChanged(object sender, EventArgs e)
        {
            _datetime = dateTimePicker1.Value;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Instructor with InstructorID [" + _InstructorID + "] is assigned to Member with MemberID:[" + _MemberID + "] At : [" + _datetime + "]", "Information ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                Member_Instructor = new clsMembers_Instructors(_MemberID, _InstructorID, _datetime);
                if (Member_Instructor.Save())
                {
                    MessageBox.Show("Assign Added Successfuly", "Success Add");
                    _RefreshScreen();
                }
            }
            else
            {
                return;
            }
        }

      

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    if (MessageBox.Show("Instructor with InstructorID [" + _InstructorID + "] is assigned to Member with MemberID:[" + _MemberID + "] At : [" + _datetime + "]", "Information ", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
        //    {
        //        Member_Instructor = new clsMembers_Instructors(_MemberID, _InstructorID, _datetime);
        //        if (Member_Instructor.Save())
        //        {
        //            MessageBox.Show("Assign Added Successfuly", "Success Add");
        //            _RefreshScreen();
        //        }
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}

       



        


    }
}
