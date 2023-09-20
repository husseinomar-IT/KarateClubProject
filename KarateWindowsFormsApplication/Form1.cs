using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarateWindowsFormsApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboGender.SelectedIndex = 0;
        }

        private void btnModeSwitch_OnValueChange(object sender, EventArgs e)
        {
            this.BackColor = (btnModeSwitch.Value == true) ? Color.FromArgb(64, 64, 64) : Color.White;
            CardInfo.BackColor = (btnModeSwitch.Value == true) ? Color.FromArgb(64, 64, 64) : Color.White;
            CardInfo.ForeColor = (btnModeSwitch.Value == true) ? Color.White : Color.Black;
        }

        private void chkAllPermission_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
         
        }

        private void bunifuCards2_Paint(object sender, PaintEventArgs e)
        {

        }


       public  bool sidebarExpand=true  ;
       public bool buttonslide = true;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(sidebarExpand)
            {
                ss.Width -= 10;
                if (ss.Width == ss.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    timer1.Stop();
                }
            }
                else
                {
                    ss.Width += 10;
                    if (ss.Width == ss.MaximumSize.Width)
                    {
                        sidebarExpand = true;
                        timer1.Stop();
                    }
                }
            
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (buttonslide)
            {
               
                panel1.Height -= 10;
                if (panel1.Height == panel1.MinimumSize.Height)
                {
                    buttonslide = false;
                    timer2.Stop();
                }
            }
            else
            {
                panel1.Height += 10;
                if (panel1.Height == panel1.MaximumSize.Height)
                {
                    buttonslide = true;
                    timer2.Stop();
                }
            }
            

        }

      

       
    }
}
