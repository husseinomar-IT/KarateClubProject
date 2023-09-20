using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using KarateDataAccessLayer;

namespace KarateBusinisLayer
{
   public  class clsPayment
    {


        public enum enMode { Update = 0, AddNew = 1 };

        public enMode Mode = enMode.Update;
       public int PaymentID { get; set; }
       public float Amount { get; set; }
       public DateTime Date { get; set; }
       public int MemberID { get; set; }




       public clsPayment (int PaymentID,float Amount,DateTime Date,int MemberID)
       {
           this.PaymentID=PaymentID ;
           this.Amount = Amount;
           this.Date = Date;
           this.MemberID = MemberID;
           Mode = enMode.Update;
       }





       public clsPayment ()
       {
           this.PaymentID = -1;
           this.Amount = 0;
           this.Date = DateTime.Now;
           this.MemberID = -1;
           Mode = enMode.AddNew;
       }



       public clsPayment(float Amount,int MemberID)
       {
           this.PaymentID = -1;
           this.Amount = Amount;
           this.Date = DateTime.Now;
           this.MemberID = MemberID;
           Mode = enMode.AddNew;
       }



       private bool _UpdatePayment()
       {
           return clsPaymentDataAccess.UpdatePayment(PaymentID, Amount, Date, MemberID);
       }

       public bool Save()
       {
           switch (Mode)
           {
               case enMode.Update :
                   return (_UpdatePayment());
           }
           return false;
       }


       public  bool AddNewPayment()
       {
           this.PaymentID = clsPaymentDataAccess.AddNewPayment(Amount, Date, MemberID);
           return (this.PaymentID  != -1);
       }


       public static  DataTable GetAllPayments()
       {
           return clsPaymentDataAccess.GetAllPayment();
       }




       public static bool Delete(int PaymentID)
       {
           return clsPaymentDataAccess.Delete(PaymentID);
       }



      
    }
}
