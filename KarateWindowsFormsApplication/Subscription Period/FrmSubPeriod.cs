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
    public partial class FrmSubPeriod : FrmScreen 
    {
        public FrmSubPeriod()
        {
            InitializeComponent();
          
        }


        protected DataTable _dataTable = new DataTable();
     
        protected DataView _dataview1 = new DataView();



        private FrmSubPeriodList _FrmList;
        private FrmAddPeriod _FrmAdd;
        private FrmEditPeriod _FrmEdit;
        private FrmDeletePeriod _FrmDelete;


     

    public  struct stPeriodInfo
        {
          
           public  int MemberID ;
           public   DateTime PeriodStartDate;
           public  DateTime PeriodEndDate;
           public  float PeriodAmount;
           public  bool IsPeid;
           public string MemberName;
           public string PeriodState;
           public int PaymentID;
        
        

        }

        protected stPeriodInfo PeriodInfo = new stPeriodInfo();
     



        protected void _FillListboxWithFullMembersName(ListBox list)
        {
            list.Items.Clear();
            _dataTable = clsMember.GetAllMembers();
            foreach (DataRow  Row in _dataTable.Rows  )
            {
                list.Items.Add(Row["FullName"]);
            }
        }

        protected int _GetMemberID(string FullName)
        {
            return clsMember.GetMemberIDByFullName(FullName);
        }


   

        private void FrmSubPeriod_Load(object sender, EventArgs e)
        {
           
        }

  

        private void FrmPeriodList_Closing(object sender, FormClosedEventArgs e)
        {
            _FrmList = null;
        }

        private void btnFrmEditPeriod_Click(object sender, EventArgs e)
        {
            if (_FrmEdit  == null)
            {
                _FrmEdit = new FrmEditPeriod ();
                _FrmEdit.FormClosed += FrmEditPeriodt_Closing;
                _FrmEdit.MdiParent = FrmScreen.ActiveForm;
                _FrmEdit.Dock = DockStyle.Fill;
                _FrmEdit.Show();
            }


            else
            {
                _FrmEdit.Activate();
            }
        }

        private void FrmEditPeriodt_Closing(object sender, FormClosedEventArgs e)
        {
            _FrmEdit = null;
        }

     

        private void btnFrmPeriodList_Click(object sender, EventArgs e)
        {
            if (_FrmList == null)
            {
                _FrmList = new FrmSubPeriodList();
                _FrmList.FormClosed += FrmPeriodList_Closing;
                _FrmList.MdiParent = FrmScreen.ActiveForm;
                _FrmList.Dock = DockStyle.Fill;
                _FrmList.Show();
            }


            else
            {
                _FrmList.Activate();
            }
        }

        private void btnFrmAddPeriod_Click(object sender, EventArgs e)
        {
            if (_FrmAdd == null)
            {
                _FrmAdd = new FrmAddPeriod ();
                _FrmAdd.FormClosed += FrmAddPeriodt_Closing;
                _FrmAdd.MdiParent = FrmScreen.ActiveForm;
                _FrmAdd.Dock = DockStyle.Fill;
                _FrmAdd.Show();
            }


            else
            {
                _FrmAdd.Activate();
            }
        }

        private void FrmAddPeriodt_Closing(object sender, FormClosedEventArgs e)
        {
            _FrmAdd = null;
        }

        private void btnFrmDelPeriod_Click(object sender, EventArgs e)
        {
            if (_FrmDelete == null)
            {
                _FrmDelete = new FrmDeletePeriod();
                _FrmDelete.FormClosed += FrmDeletePeriodt_Closing;
                _FrmDelete.MdiParent = FrmScreen.ActiveForm;
                _FrmDelete.Dock = DockStyle.Fill;
                _FrmDelete.Show();
            }


            else
            {
                _FrmDelete.Activate();
            }
        }

        private void FrmDeletePeriodt_Closing(object sender, FormClosedEventArgs e)
        {
            _FrmDelete = null;
        }
    }
}
