using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarateDataAccessLayer;
using System.Data;

namespace KarateBusinisLayer
{
   public  class clsBeltTest
    {

        public enum enMode { Update = 0, AddNew = 1 };
        public enMode Mode = enMode.Update;
       public int TestID { set; get; }
       public int MemberID { set; get; }
       public int RankID { set; get; }
       public bool Result { set; get; }

       public DateTime Date { set; get; }

       public int InstructorID { set; get; }
       public int paymentID { set; get; }



       public clsBeltTest(int MemberID,int RankID,bool Result,DateTime  Date,int InstructorID,int PaymentID)
       {
           this.TestID = -1;
           this.MemberID = MemberID;
           this.RankID =RankID;
           this.Result = Result;
           this.Date = Date;
           this.InstructorID = InstructorID;
           this.paymentID = PaymentID;
           Mode = enMode.AddNew;

       }
       public clsBeltTest(int TestID,int MemberID, int RankID, bool Result, DateTime Date, int InstructorID, int PaymentID)
       {

           this.TestID = TestID;
           this.MemberID = MemberID;
           this.RankID = RankID;
           this.Result = Result;
           this.Date = Date;
           this.InstructorID = InstructorID;
           this.paymentID = PaymentID;
           Mode = enMode.Update;

       }

       private bool _UpdateBeltTest()
       {
           return clsBeltTestDataAccess.UpdateBeltTest(TestID, MemberID, RankID, InstructorID, Date, Result, paymentID);
       }

       public bool Save()
       {
           switch(Mode)
           {
               case enMode.AddNew:
                   if(_AddNewBeltTest())
                   {
                       Mode = enMode.Update;
                       return true;
                   }
                   else
                   {
                       return false;
                   }



               case enMode.Update:
                   return (_UpdateBeltTest());

           }
           return false;
       }
       private  bool  _AddNewBeltTest()
       {


           TestID = clsBeltTestDataAccess.AddNewBeltTest(MemberID, RankID, Result, Date, InstructorID, paymentID);
          return (TestID > -1);
       }



       public static DataTable GetAllBeltTests()
       {
           return clsBeltTestDataAccess.GetAllBeltTests();
       }


       public static bool GetTestInfoByID(int TestID,ref string MemberName,ref string BeltName,ref string InstructorName,ref bool Result,ref DateTime Date,ref int PaymentID)
       {
           return clsBeltTestDataAccess.GetTestInfoByID(TestID, ref MemberName, ref BeltName, ref InstructorName, ref Date, ref Result, ref PaymentID);
       }




       public static bool IsBeltTestExsits(int TestID)
       {
           return clsBeltTestDataAccess.IsBeltTestExsits(TestID);
       }


       public static bool Delete(int TestID)
       {
           return clsBeltTestDataAccess.Delete(TestID);
       }





       public static bool GetBeltTestInfoByMemberID(ref int TestID, int MemberID, ref int TestPayment)
       {

           return clsBeltTestDataAccess.GetTestInfoByMemberID(ref TestID, MemberID, ref TestPayment);


       }


    }
}
