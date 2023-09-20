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

namespace KarateWindowsFormsApplication
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }



      public  static  FrmLogin frmlogin = new FrmLogin();




        public static clsUser CurrentUser = new clsUser();

        public short FalidLoginCounter = 0;
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
            picboxWarnning.Visible = false;

            lblFaildLogin1.Visible = false;
            _RefreshFromLogin();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void _RefreshFromLogin()
        {
            txtUserName.text = string.Empty;
            txtPassword.text = string.Empty;
        }



        private void _CheckLogin()
        {

            if (CurrentUser == null)
            {
                picboxWarnning.Visible = true;
                lblFaildLogin1.Visible = true;

                if (FalidLoginCounter == 3)
                {
                    btnLogin.Enabled = false;
                   lblFaildLogin1.Text= "       Your are Loked after 3 falid trails";

                }
                else
                {
                    lblFaildLogin1.Text = @"Invlaid Username/Password!You have" + (3 - FalidLoginCounter) + " Trial(s) to login";

                }






            }
            else
            {
                
                _RefreshFromLogin();
                FrmScreen Screen = new FrmScreen();
                Screen.ShowDialog();
                //this.Close();
                //Application.Exit();
              
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(FalidLoginCounter<3)
            {
                CurrentUser = clsUser.Find(txtUserName.Text, txtPassword.Text);
                FalidLoginCounter++;
                _CheckLogin();
            }
        }

        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCloseFrm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (FalidLoginCounter < 3)
            {
                CurrentUser = clsUser.Find(txtUserName.text , txtPassword.text );
                FalidLoginCounter++;
                _CheckLogin();
            }
        }
    }
}
