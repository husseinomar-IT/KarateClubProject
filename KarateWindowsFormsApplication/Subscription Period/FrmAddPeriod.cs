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
    public partial class FrmAddPeriod : FrmSubPeriod
    {
        public FrmAddPeriod()
        {
            InitializeComponent();
            _FillListboxWithFullMembersName(lstboxMembers);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PeriodInfo.MemberID = _GetMemberID(lstboxMembers.SelectedItem.ToString());
        }

        private void FrmAddPeriod_Load(object sender, EventArgs e)
        {
            btnFrmAddPeriod.Enabled = false;
          
        }

        private void StartDatePicker_onValueChanged(object sender, EventArgs e)
        {
            PeriodInfo.PeriodStartDate = StartDatePicker.Value;
        }

        private void EndDatePicker_onValueChanged(object sender, EventArgs e)
        {
            PeriodInfo.PeriodEndDate = EndDatePicker.Value;
        }

        private void rdbIsPaid_CheckedChanged(object sender, EventArgs e)
        {
            PeriodInfo.IsPeid = (rdbIsPaid.Checked == true) ? true : false;
        }

        private void rdbNoPaid_CheckedChanged(object sender, EventArgs e)
        {
            PeriodInfo.IsPeid = (rdbNoPaid .Checked ==true) ? false  :true  ;
        }




        private bool _AddNewPeriod()
        {
            clsPayment Payment = new clsPayment(PeriodInfo .PeriodAmount,PeriodInfo .MemberID );
         if(Payment.AddNewPayment())
         {
             clsSubscriptionPeriod Period = new clsSubscriptionPeriod(PeriodInfo.PeriodStartDate  ,PeriodInfo .PeriodEndDate ,PeriodInfo .PeriodAmount ,PeriodInfo .IsPeid ,PeriodInfo .MemberID,Payment.PaymentID );
             return (Period.Save ());
         }
         return false;
            
        }


        protected  void _RefreshScreen()
        {
            _FillListboxWithFullMembersName(lstboxMembers);
            StartDatePicker.Value = DateTime.Now;
            EndDatePicker.Value = DateTime.Now;
            numericFeesPeriod.Value = numericFeesPeriod.Minimum;
            rdbIsPaid.Checked = false;
            rdbNoPaid.Checked = false;
           
        }

        private void btnAddPeriod_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Add this Period", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (_AddNewPeriod())
                {
                    if (MessageBox.Show("Subscription Period Added Successfuly", "Add Period", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
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

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            PeriodInfo.PeriodAmount =(float) numericFeesPeriod.Value;
        }

        private void btnFrmEditPeriod_Click(object sender, EventArgs e)
        {

        }

       
    }
}
