using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KarateBusinisLayer;
using Bunifu.Framework.UI;

namespace KarateWindowsFormsApplication
{
    public partial class FrmEditInstructor : KarateWindowsFormsApplication.FrmInstructor
    {
        public FrmEditInstructor()
        {
            InitializeComponent();
        }


        public clsInstructors Instructor = new clsInstructors();

        private void FrmEditInstructor_Load(object sender, EventArgs e)
        {
            btnFrmEditInstructor.Enabled = false;
        }




        private void _GetInstructorInfo()
        {

            txtFirstName.Text = Instructor.FirstName;
            txtLastName.Text = Instructor.LastName;
            txtPhone.Text = Instructor.Phone;
            txtEmail.Text = Instructor.Email;
            txtAddress.Text = Instructor.Address;
          txtQuelification.Text  = Instructor.Quelification ;
        }
   



        private void _ReadInstructorInfo(ref clsInstructors Instructor)
        {
            Instructor.FirstName = txtFirstName.Text;
            Instructor.LastName = txtLastName.Text;
            Instructor.Address = txtAddress.Text;
            Instructor.Email = txtEmail.Text;
            Instructor.Phone = txtPhone.Text;
            if (txtQuelification.Text != string.Empty)
            {
                Instructor.Quelification = txtQuelification.Text;
            }
            else
            {
                Instructor.Quelification = "";
            }
           


         
          
        }
        private bool _UpdateInstructor()
        {
            _ReadInstructorInfo(ref Instructor);
            return (Instructor.Save());

        }



       

      

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Update this Instructor", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (_UpdateInstructor())
                {
                    if (MessageBox.Show("Instructor Update succsuufuly", " Update Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        _RefreishCardInfo();
                     
                    }
                    else
                    {
                        MessageBox.Show("Member not  Updated ", " Error Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
            }
        }



        private void _RefreishCardInfo()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtQuelification.Text = string.Empty;
        }
   
       

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int Result;

            if (!int.TryParse(txtInstructorID.Text, out Result))
            {
                _RefreishCardInfo();
                return;
            }
            if (txtInstructorID.Text == string.Empty)
            {
                _RefreishCardInfo();
                return;
            }
            Instructor = clsInstructors.Find(Convert.ToInt16(txtInstructorID.Text));
            if (Instructor != null)
            {
                _GetInstructorInfo();


            }
            else
            {
                if (MessageBox.Show("This Instructor is not Found", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    txtInstructorID.Text = string.Empty;
                }
            }
        }

        private void txtboxsInstructors_Validating(object sender, CancelEventArgs e)
        {
            _RequiredField((BunifuMaterialTextbox)sender, e);
        }

   

    

     

       
    }
}
