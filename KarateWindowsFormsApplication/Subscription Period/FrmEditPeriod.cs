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
    public partial class FrmEditPeriod : KarateWindowsFormsApplication.FrmAddPeriod
    {
        public FrmEditPeriod()
        {
            InitializeComponent();
            
        }



       


        private bool _checkPeriodState()
        {
            return (PeriodInfo.PeriodState == "Yes") ? true : false;
        }


        private void _GetPeriodInfo()
        {
            lstboxMembers.SelectedItem = PeriodInfo.MemberName;
            StartDatePicker.Value = PeriodInfo.PeriodStartDate;
            EndDatePicker.Value = PeriodInfo.PeriodEndDate;
            numericFeesPeriod.Value = (decimal)PeriodInfo.PeriodAmount;
            rdbIsPaid.Checked  = (_checkPeriodState()) ? true : false;
            rdbNoPaid.Checked = (!_checkPeriodState()) ? true : false;
            

        }
        private bool _Find()
        {




            return clsSubscriptionPeriod.GetPeriodInfoByID(Convert.ToInt16(txtPeriodID.text), ref PeriodInfo.MemberName, ref PeriodInfo.PeriodStartDate, ref PeriodInfo.PeriodEndDate, ref PeriodInfo.PeriodAmount, ref PeriodInfo.PeriodState,ref PeriodInfo .PaymentID );
           


        }

        private void FrmEditPeriod_Load(object sender, EventArgs e)
        {
            btnAddPeriod.Visible = false;
            btnFrmAddPeriod.Enabled = true;
            btnFrmEditPeriod.Enabled = false;
        }

        private void btnFrmEditPeriod_Click(object sender, EventArgs e)
        {

        }

        private void txtPeriodID_DoubleClick(object sender, EventArgs e)
        {
          
        }

        private void txtPeriodID_OnTextChange(object sender, EventArgs e)
        {
            
        }



        private bool _UpdatePeriod()
        {
        clsSubscriptionPeriod  Period=  new clsSubscriptionPeriod (Convert.ToInt16 (txtPeriodID.text),PeriodInfo.PeriodStartDate,PeriodInfo.PeriodEndDate,PeriodInfo .PeriodAmount ,PeriodInfo.IsPeid ,PeriodInfo .MemberID ,PeriodInfo.PaymentID );
        return (Period.Save ());
        }
        private void btnEditPeriod_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Edit this Period", "Confirm Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (_UpdatePeriod())
                {
                    if (MessageBox.Show("Subscription Period Updated Successfuly", "Add Period", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        _RefreshScreen();
                    }
                    else
                    {
                        MessageBox.Show("Period  is not Added ", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtPeriodID.text == string.Empty)
            {
                _RefreshScreen();
                return;
            }
            if (_Find())
            {
                _GetPeriodInfo();
            }

            else
            {
                MessageBox.Show("PeriodID Is not Found", "Error");
            }
        }

    
    }
}
