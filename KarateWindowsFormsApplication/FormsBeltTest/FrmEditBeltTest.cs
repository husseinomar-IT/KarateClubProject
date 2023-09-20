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
    public partial class FrmEditBeltTest : KarateWindowsFormsApplication.FrmAddBeltTest
    {
        public FrmEditBeltTest()
        {
            InitializeComponent();
        }

        private void _SetTestInfo()
        {
            lstboxMembers.SelectedItem = _TestInfo.MemberName;
            lstboxInstructor.SelectedItem = _TestInfo.InstructorName;
            lstboxBelts.SelectedItem = _TestInfo.BeltName;
            BeltTestDate.Value = _TestInfo.Date;
            rdbIsSuccessResult.Checked = (_TestInfo.Result == true) ? true : false;
            rdbIsFaliedResult.Checked = (_TestInfo.Result == false) ? true : false;
        }
    

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmEditBeltTest_Load(object sender, EventArgs e)
        {
            btnAddBeltTest.Enabled = true;
            btnFrmEditBeltTest.Enabled = false;
        }

        private void btnAddBeltTest_Click(object sender, EventArgs e)
        {

        }

        private bool _UpdateBeltTest()
        {
            _TestInfo.TestFees = clsBeltRankcs.GetTestFeesByID(_TestInfo.RankID);
            clsPayment Payment = new clsPayment(_TestInfo.PaymentID, _TestInfo.TestFees, _TestInfo.Date, _TestInfo.MemberID);
            if(Payment.Save () )
            {
                clsBeltTest Test = new clsBeltTest(Convert.ToInt16(txtTestID.Text), _TestInfo.MemberID, _TestInfo.RankID, _TestInfo.Result, _TestInfo.Date, _TestInfo.InstructorID, _TestInfo.PaymentID);
                if (Test.Save())
                {
                    _UpdateMemberBeltRank();
                    return true;
                }
                else
                {
                    return false;
                }
            
            }
            return false;
      
        }

        private void btnEditTestInfo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure You Want to Edit This Belt Test", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (_UpdateBeltTest())
                {
                    
                    if (MessageBox.Show("Belt Test Updated Successfuly", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        _RefrishScreen();
                    }
                    else
                    {
                        MessageBox.Show("Belt Test  is not Updated ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void btnFrmUPDMember_Click(object sender, EventArgs e)
        {
            btnFrmEditBeltTest.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int result = 0;
            if (!int.TryParse(txtTestID.Text, out result))
            {
                _RefrishScreen();
                return;
            }

            if (txtTestID.Text == string.Empty)
            {
                _RefrishScreen();
                return;
            }

            if (clsBeltTest.GetTestInfoByID(Convert.ToInt16(txtTestID.Text), ref _TestInfo.MemberName, ref _TestInfo.BeltName, ref _TestInfo.InstructorName, ref _TestInfo.Result, ref _TestInfo.Date, ref _TestInfo.PaymentID))
            {
                _SetTestInfo();
            }
        }

    
    }
}
