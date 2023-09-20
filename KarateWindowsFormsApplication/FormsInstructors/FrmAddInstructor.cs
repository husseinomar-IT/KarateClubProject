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
    public partial class FrmAddInstructor : KarateWindowsFormsApplication.FrmInstructor
    {
        public FrmAddInstructor()
        {
            InitializeComponent();
        }



        public clsInstructors Instructor = new clsInstructors();
        private void FrmAddInstructor_Load(object sender, EventArgs e)
        {
            btnFrmAddInstructor.Enabled = false;
        }

        private void btnFrmInstructorList_Click(object sender, EventArgs e)
        {

        }

        private void btnFrmEditInstructor_Click(object sender, EventArgs e)
        {

        }


        private void _ReadPersonInfo(ref clsPerson Person)
        {
            Person.FirstName = txtFirstName.Text;
            Person.Address = txtAddress.Text;
            Person.Email = txtEmail.Text;
            Person.Phone = txtPhone.Text;
            if(txtAddress .Text!=null )
            {
                Person.Address = txtAddress.Text;
            }
            else
            {
                Person.Address = "";
            }
          
        }





        private void _ReadInstructorInfo(ref clsInstructors Instructor)
        {
            if (txtQuelification.Text!=string .Empty )
            {
                Instructor.Quelification = txtQuelification.Text;
            }
            else
            {
                Instructor.Quelification = "";
            }
           

        }

        private bool _AddNewInstructor()
        {
            clsPerson Person = new clsPerson();
            _ReadPersonInfo(ref Person);
            if (Person.Save())
            {
                Instructor = new clsInstructors(Person.PersonID);
                _ReadInstructorInfo(ref Instructor);
                return (Instructor.Save());


            }
            return false;

        }


        private void _RefreshScreen()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtQuelification.Text = string.Empty;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Add this Instructor", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (_AddNewInstructor())
                {
                    if (MessageBox.Show("Instructor Added Successfuly", "Add Instructor", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        _RefreshScreen();
                    }
                    else
                    {
                        MessageBox.Show("Instructor  is not Added ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void txtboxsInstructors_Validating(object sender, CancelEventArgs e)
        {
            _RequiredField((BunifuMaterialTextbox)sender, e);
        }

    

    

      
    }
}
