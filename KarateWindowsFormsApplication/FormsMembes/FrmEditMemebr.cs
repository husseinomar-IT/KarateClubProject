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
    public partial class FrmUPDMemebr : KarateWindowsFormsApplication.FrmMembers
    {
        public FrmUPDMemebr()
        {
            InitializeComponent();
            _FillComboBeltRanks(comboLastBelt);
        }


        public clsMember Member = new clsMember();
        public DataTable datatable = new DataTable();
        private short _LastBelt = 19;
        private char _Gender = 'M';
        private bool _Active = false;
        private void FrmUPDMemebr_Load(object sender, EventArgs e)
        {
            btnFrmUPDMember.Enabled = false;
            txtSearchByID.Focus();
         //   CardInfo.Enabled = false;
        }



        private void _RefreishCardInfo()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtEmContact.Text = string.Empty;
            comboGender.SelectedIndex = 0;
            comboLastBelt.SelectedIndex = 15;
            rdbNoActive.Checked = true;
        }



        private void _FillComboBeltRanks(ComboBox combo)
        {
            datatable = clsBeltRankcs.GetAllBeltRanks();
            foreach (DataRow Row in datatable.Rows)
            {
                combo.Items.Add(Row["RankName"]);
            }
        }



        private void _GetMemberInfo()
        {
            
              txtFirstName.Text=Member.FirstName;
              txtLastName.Text=Member.LastName;
              txtPhone.Text=Member.Phone;
              txtEmail.Text = Member.Email;
              txtAddress.Text = Member.Address;
              txtEmContact.Text = Member.EmergencyContactInfo;
              comboLastBelt.SelectedIndex = comboLastBelt.FindString(clsBeltRankcs.Find(Member.LastBeltRank).RankName);
             
              comboGender.SelectedIndex = (Member.Gender == 'M') ? 0 : 1;
              rdbActive.Checked = (Member.IsActive == true) ? true : false;
              rdbNoActive.Checked = (Member.IsActive == false) ? true : false;
        }

      





   


      

        private void _ReadMemberInfo(ref clsMember Member)
        {
            
            Member.FirstName = txtFirstName.Text;
            Member.EmergencyContactInfo = txtEmContact.Text;
            Member.LastName = txtLastName.Text;
            Member.Address = txtAddress.Text;
            Member.Email = txtEmail.Text;
            Member.Phone = txtPhone.Text;
            Member.Gender = _Gender;
            Member.LastBeltRank = _LastBelt;
            Member.IsActive = _Active;
        }
        private bool _UpdateMember()
        {
            _ReadMemberInfo(ref Member);
            return (Member.Save());

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




      
        private void comboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            _Gender = (comboGender.SelectedIndex == 0) ? 'M' : 'F';
        }

        private void comboLastBelt_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LastBelt = clsBeltRankcs.GetBeltRankIDByBeltName(comboLastBelt.SelectedItem.ToString());
        }

        private void rdbActive_CheckedChanged(object sender, EventArgs e)
        {
            _Active = (rdbActive.Checked) ? true : false;
        }

     
    

     

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            _RefreshScreen();
            CardInfo.Enabled = false;
        }

    

        private void label6_Click(object sender, EventArgs e)
        {

        }

       


     

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            int Result;

            if (!int.TryParse(txtSearchByID.Text, out Result))
            {
                _RefreishCardInfo();
                return;
            }
            if (txtSearchByID.Text == string.Empty)
            {
                _RefreishCardInfo();
                return;
            }
            Member = clsMember.Find(Convert.ToInt16(txtSearchByID.Text));
            if (Member != null)
            {
                _GetMemberInfo();
                CardInfo.Enabled = true;

            }
            else
            {
                if (MessageBox.Show("The Member with ID[" + txtSearchByID.Text + "] is not Found", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    txtSearchByID.Text = string.Empty;
                    txtSearchByID.Focus();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Update this Member", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (_UpdateMember())
                {
                    if (MessageBox.Show("Member Update succsuufuly", " Update Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        _RefreshScreen();
                        CardInfo.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Member not  Updated ", " Error Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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
