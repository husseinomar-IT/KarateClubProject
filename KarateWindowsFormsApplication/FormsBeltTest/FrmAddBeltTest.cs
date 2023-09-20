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
    public partial class FrmAddBeltTest : KarateWindowsFormsApplication.FrmBeltTest
    {
        public FrmAddBeltTest()
        {
            InitializeComponent();
            _SetlstboxesInfo();
        }



        protected clsMember _Member = new clsMember();


        public   struct _stBeltTestInfo
        {
            public int MemberID;
            public int RankID;
            public int InstructorID;
            public DateTime Date;
            public bool Result;
            public int PaymentID;



            public string MemberName;
            public string InstructorName;
            public string BeltName;

            public float TestFees;

        };


       protected _stBeltTestInfo _TestInfo = new _stBeltTestInfo();



        protected  void  _SetlstboxesInfo()
        {
            _FillListWithMembers();
            _FillListWithBeltRanks();
            _FillListWithInstructor();
        }

        private   void _FillListWithMembers()
        {
            _dataTable  = clsMember.GetAllMembers();
            foreach (DataRow Row in _dataTable.Rows)
            {
                lstboxMembers.Items.Add(Row["FullName"]);
                  
            }
        }


        private  void _FillListWithBeltRanks()
        {
            _dataTable = clsBeltRankcs.GetAllBeltRanks();
            foreach (DataRow Row in _dataTable.Rows)
            {
               
                lstboxBelts.Items.Add(Row["RankName"]);

            }
        }


        private  void _FillListWithInstructor()
        {
            _dataTable = clsInstructors.GetAllInstructors();
            foreach (DataRow Row in _dataTable.Rows)
            {

                lstboxInstructor.Items.Add(Row["FullName"]);
              
            }
        }


        private void FrmAddBeltTest_Load(object sender, EventArgs e)
        {
            btnFrmAddBeltTest.Enabled = false;
        }

      

        private void lstboxMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            _TestInfo.MemberID = clsMember.GetMemberIDByFullName(lstboxMembers.SelectedItem.ToString());
        }

        private void lstboxInstructor_SelectedIndexChanged(object sender, EventArgs e)
        {
            _TestInfo.InstructorID = clsInstructors.GetInstructorIDByFullName(lstboxInstructor.SelectedItem.ToString());
        }

        private void lstboxBelts_SelectedIndexChanged(object sender, EventArgs e)
        {
            _TestInfo.RankID = clsBeltRankcs.GetBeltRankIDByBeltName(lstboxBelts.SelectedItem.ToString());
        }

        private void rdbIsSuccessResult_CheckedChanged(object sender, EventArgs e)
        {
            _TestInfo.Result = (rdbIsSuccessResult.Checked == true) ? true : false;
        }

        private void rdbIsFaliedResult_CheckedChanged(object sender, EventArgs e)
        {
            _TestInfo.Result = (rdbIsFaliedResult.Checked  == true) ? false  : true;
        }

        private void BeltTestDate_onValueChanged(object sender, EventArgs e)
        {
            _TestInfo.Date = BeltTestDate.Value;
        }


        protected bool _UpdateMemberBeltRank()
        {
            _Member = clsMember.Find(_TestInfo.MemberID);
            _Member.LastBeltRank = (short)_TestInfo.RankID;
            return (_Member.Save());
        }
        private  bool _AddNewBeltTest()
        {
           
            _TestInfo.TestFees = clsBeltRankcs.GetTestFeesByID(_TestInfo.RankID);
            clsPayment Payment = new clsPayment(_TestInfo.TestFees, _TestInfo.MemberID);
            if (Payment.AddNewPayment())
            {
                clsBeltTest BeltTest = new clsBeltTest(_TestInfo.MemberID, _TestInfo.RankID, _TestInfo.Result, _TestInfo.Date, _TestInfo.InstructorID, Payment.PaymentID);
              if( BeltTest.Save())
              {
                  return (_UpdateMemberBeltRank());
              }
              else
              {
                  return false;
              }
            }
                   else 
                {
                  return false;
                }
         

            
        }


        private void _ClearSelectedItemFromLstboxs()
        {
            lstboxBelts.Items.Clear();
            lstboxInstructor.Items.Clear();
            lstboxMembers.Items.Clear();
        }
        protected  void _RefrishScreen()
        {
            _ClearSelectedItemFromLstboxs();
            _SetlstboxesInfo();
            BeltTestDate.Value = DateTime.Now;
            rdbIsFaliedResult.Checked = true;
        }

        private void btnAddBeltTest_Click(object sender, EventArgs e)
        {
          if(MessageBox.Show("Are You sure you want to Add This Test","Confirm Massage",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
          {
              if(_AddNewBeltTest())
              {
                 if( MessageBox.Show("Test Info Added Successfuly","Message",  MessageBoxButtons.OK,MessageBoxIcon.Information)==DialogResult.OK)
                 {
                     _RefrishScreen();
                 }
              }
          }
        }

        private void btnCanacel_Click(object sender, EventArgs e)
        {
        }
    }
}
