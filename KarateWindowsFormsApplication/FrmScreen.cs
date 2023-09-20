using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KarateBusinisLayer;
using Bunifu.Framework.UI;

namespace KarateWindowsFormsApplication
{
    public partial class FrmScreen : Form
    {
        public FrmScreen()
        {
            InitializeComponent();
        }

        private FrmDashboardcs _FrmDashboard;

        private FrmAddUsercs _FrmAddUsers;
        private FrmAddMembers _FrmAddMembers;
        private FrmAddInstructor _FrmAddInstructor;
        private FrmAddME_IN _FrmAddMembersInstructor;
        private FrmAddPeriod _FrmAddSubscriptionPeriod;
        private FrmBeltList _FrmBeltRanks;
        private FrmBeltTest _FrmAddBeltTest;
        private FrmPaymentList _FrmPayment;
        private FrmLogin _FrmLogin;


        public static bool CheckAccessRight(Button btn)
        {
            
            if (!FrmLogin.CurrentUser.CheckAccessPerimission(Convert.ToInt16(btn.Tag)))
            {

                MessageBox.Show("Access Denied Contact your Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {


                return true;
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FrmMainMenue_Load(object sender, EventArgs e)
        {
        
        }

        private   void btnFrmDashboard_Click(object sender, EventArgs e)
        {
            if(!CheckAccessRight((Button )sender ))
            {
                return;
            }


            if (_FrmDashboard == null)
            {
                _FrmDashboard = new FrmDashboardcs();
                _FrmDashboard.FormClosed += Form1_FormClosing;
                _FrmDashboard.MdiParent = this;
                _FrmDashboard.Dock = DockStyle.Fill;
                _FrmDashboard.Show();
            }


            else
            {
                _FrmDashboard.Activate();
            }
        }

        private void Form1_FormClosing(object sender, FormClosedEventArgs e)
        {
            _FrmDashboard = null;
        }

        protected virtual void btnCloseFrm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFrmMembers_Click(object sender, EventArgs e)
        {
            if (!CheckAccessRight((Button)sender))
            {
                return;
            }
            
            if (_FrmAddMembers == null)
            {
                _FrmAddMembers = new FrmAddMembers();
                _FrmAddMembers.FormClosed += FrmAddMembers_Closing;
                _FrmAddMembers.MdiParent = this;
                _FrmAddMembers.Dock = DockStyle.Fill;
                _FrmAddMembers.Show();
            }


            else
            {
                _FrmAddMembers.Activate();
            }

        }

        private void FrmAddMembers_Closing(object sender, FormClosedEventArgs e)
        {
            _FrmAddMembers = null;
        }

        private void btnFrmInstructor_Click(object sender, EventArgs e)
        {
            if (!CheckAccessRight((Button)sender))
            {
                return;
            }
            
            if (_FrmAddInstructor == null)
            {
                _FrmAddInstructor = new FrmAddInstructor();
                _FrmAddInstructor.FormClosed += FrmAddMembers_Closing;
                _FrmAddInstructor.MdiParent = this;
                _FrmAddInstructor.Dock = DockStyle.Fill;
                _FrmAddInstructor.Show();
            }


            else
            {
                _FrmAddInstructor.Activate();
            }
        }




     
        private void btnFrmUsers_Click(object sender, EventArgs e)
        {
            if (!CheckAccessRight((Button)sender))
            {
                return;
            }

            if (_FrmAddUsers == null)
            {
                _FrmAddUsers = new FrmAddUsercs();
                _FrmAddUsers.FormClosed += FrmUsers_closing;
                _FrmAddUsers.MdiParent = this;
                _FrmAddUsers.Dock = DockStyle.Fill;
                _FrmAddUsers.Show();
            }


            else
            {
                _FrmAddUsers.Activate();
            }



          


           

        }



    


        private void FrmUsers_closing(object sender, FormClosedEventArgs e)
        {
            _FrmAddInstructor = null;
        }

        private void btnFrmMembersInstructor_Click(object sender, EventArgs e)
        {
            if (!CheckAccessRight((Button)sender))
            {
                return;
            }
            if (_FrmAddMembersInstructor == null)
            {
                _FrmAddMembersInstructor = new FrmAddME_IN();
                _FrmAddMembersInstructor.FormClosed += FrmMembersInstructors_Closing;
                _FrmAddMembersInstructor.MdiParent = this;
                _FrmAddMembersInstructor.Dock = DockStyle.Fill;
                _FrmAddMembersInstructor.Show();
            }


            else
            {
                _FrmAddMembersInstructor.Activate();
            }
            
        }

        private void FrmMembersInstructors_Closing(object sender, FormClosedEventArgs e)
        {
            _FrmAddMembersInstructor = null;
        }

        private void btnFrmBeltRanks_Click(object sender, EventArgs e)
        {
            if (!CheckAccessRight((Button)sender))
            {
                return;
            }


            if (_FrmBeltRanks == null)
            {
                _FrmBeltRanks = new FrmBeltList();
                _FrmBeltRanks.FormClosed += FrmAddMembers_Closing;
                _FrmBeltRanks.MdiParent = this;
                _FrmBeltRanks.Dock = DockStyle.Fill;
                _FrmBeltRanks.Show();
            }


            else
            {
                _FrmBeltRanks.Activate();
            }
        }

        private void btnFrmSubscription_Click(object sender, EventArgs e)
        {
            if (!CheckAccessRight((Button)sender))
            {
                return;
            }
            if (_FrmAddSubscriptionPeriod == null)
            {
                _FrmAddSubscriptionPeriod = new FrmAddPeriod();
                _FrmAddSubscriptionPeriod.FormClosed += Frm_Period_Closing;
                _FrmAddSubscriptionPeriod.MdiParent = this;
                _FrmAddSubscriptionPeriod.Dock = DockStyle.Fill;
                _FrmAddSubscriptionPeriod.Show();
            }


            else
            {
                _FrmAddSubscriptionPeriod.Activate();
            }
        }

        private void Frm_Period_Closing(object sender, FormClosedEventArgs e)
        {
            _FrmAddSubscriptionPeriod = null;
        }

   

      

    

        private void btnFrmPayment_Click(object sender, EventArgs e)
        {
            if (!CheckAccessRight((Button)sender))
            {
                return;
            }


            if (_FrmPayment == null)
            {
                _FrmPayment = new FrmPaymentList();
                _FrmPayment.FormClosed += FrmPaymentList_Closing;
                _FrmPayment.MdiParent = this;
                _FrmPayment.Dock = DockStyle.Fill;
                _FrmPayment.Show();
            }


            else
            {
                _FrmPayment.Activate();
            }
        }

        private void FrmPaymentList_Closing(object sender, FormClosedEventArgs e)
        {
            _FrmPayment = null;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmLogin.CurrentUser = clsUser.Find("", "");
            
            if (_FrmLogin == null)
            {
                _FrmLogin = new FrmLogin ();
                _FrmLogin.FormClosed += FrmLogin_Closing;
                _FrmLogin.MdiParent = this;
                _FrmLogin.Dock = DockStyle.Fill;
                _FrmLogin.Show();
            }


            else
            {
                _FrmLogin.Activate();
            }
          
        }

        private void FrmLogin_Closing(object sender, FormClosedEventArgs e)
        {
            _FrmLogin = null;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuiOSSwitch1_OnValueChange(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
        }

        private void btnFrmBeltTest_Click(object sender, EventArgs e)
        {
            if (!CheckAccessRight((Button)sender))
            {
                return;
            }
            if (_FrmAddBeltTest == null)
            {
                _FrmAddBeltTest = new FrmAddBeltTest();
                _FrmAddBeltTest.FormClosed += Frm_BeltTest_Closing;
                _FrmAddBeltTest.MdiParent = this;
                _FrmAddBeltTest.Dock = DockStyle.Fill;
                _FrmAddBeltTest.Show();
            }


            else
            {
                _FrmAddBeltTest.Activate();
            }
        }

        private void Frm_BeltTest_Closing(object sender, FormClosedEventArgs e)
        {
            _FrmAddBeltTest = null;
        }











        protected void _RequiredField(BunifuMaterialTextbox  txt, CancelEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                e.Cancel = true;
                txt.Focus();
                errorProvider1.SetError(txt, "Required Field");
            }


            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txt, "");
            }

        }



    





    




      
     
    }
}
