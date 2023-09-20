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
    public partial class FrmAddMembers : KarateWindowsFormsApplication.FrmMembers
    {
        public FrmAddMembers()
        {
            InitializeComponent();
            _FillComboBeltRanks(comboLastBelt);
        }


        public DataTable dataTable = new DataTable();
        public clsMember Member = new clsMember();
        private short _LastBelt=19;
        private char _Gender='M';
        private bool _Active = false;



       
        private void FrmAddMembers_Load(object sender, EventArgs e)
        {
            btnFrmAddMember.Enabled = false;
         comboLastBelt.SelectedIndex = 15;
            comboGender.SelectedIndex = 0;
           
        }


      
       

        private  void _FillComboBeltRanks(ComboBox combo)
        {
            dataTable = clsBeltRankcs.GetAllBeltRanks();
            foreach(DataRow Row in dataTable.Rows)
            {
                combo.Items.Add(Row["RankName"]);
            }
        }


     

   






        private void _ReadPersonInfo( ref clsPerson Person)
        {
            Person.FirstName = txtFirstName.Text;
            Person.LastName = txtLastName.Text;
            Person.Email = txtEmail.Text;
            Person.Phone = txtPhone.Text;
            if (txtAddress.Text != string.Empty)
            {
                Person.Address = txtAddress.Text;
            }
            else
            {
                Person.Address ="";
            }
        }

         

    

        private void _ReadMemberInfo(ref clsMember Member)
        {
            Member.EmergencyContactInfo = txtEmContact.Text ;
            Member.LastBeltRank = _LastBelt;
            Member.Gender = _Gender;
            Member.IsActive = _Active;
          
           
        }

        private bool _AddNewMember()
        {
            clsPerson Person = new clsPerson();
            _ReadPersonInfo(ref Person);
            if(Person.Save())
            {
                 Member = new clsMember(Person.PersonID);
                 _ReadMemberInfo(ref Member);
                 return (Member.Save());
                
                
            }
            return false;

        }

        private void _RefreshScreen()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            comboGender.SelectedIndex = 0;
            comboLastBelt.SelectedIndex = 15;
            txtPhone.Text = string.Empty;
            txtEmContact.Text = string.Empty;
            rdbNoActive.Checked = true;
        }
     

        private void comboLastBelt_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LastBelt = clsBeltRankcs.GetBeltRankIDByBeltName(comboLastBelt.SelectedItem.ToString());
        }

        private void comboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboGender.SelectedIndex)
            {
                case 0:
                  _Gender = 'M';
                    break;
                case 1:
                 _Gender= 'F';
                    break;

            }
        }

        private void rdbActive_CheckedChanged(object sender, EventArgs e)
        {

          _Active= (rdbActive.Checked) ? true : false;
          
        }

        private void btnCanacel_Click(object sender, EventArgs e)
        {
            _RefreshScreen();

        }

    

        private void bunifuCards1_Paint_1(object sender, PaintEventArgs e)
        {

        }

   

    



     

      

     

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Add this Member", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (_AddNewMember())
                {
                    if (MessageBox.Show("Member Added Successfuly", "Add Member", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        _RefreshScreen();
                    }
                    else
                    {
                        MessageBox.Show("Member  is not Added ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void txtboxsMembers_Validating(object sender, CancelEventArgs e)
        {
            _RequiredField((BunifuMaterialTextbox)sender, e);
        }

     

       


    }
}
