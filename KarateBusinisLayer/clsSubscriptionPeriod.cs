using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarateDataAccessLayer;
using System.Data ;
namespace KarateBusinisLayer
{
  public  class clsSubscriptionPeriod

    {



        public enum enMode { Update = 0, AddNew = 1 };

        public enMode Mode = enMode.Update;
      public int PeriodID { get; set; }


      public DateTime StartDate { get; set; }
      public DateTime EndDate { get; set; }


      public float Fees { get; set; }
      public bool IsPaid { get; set; }
      public int MemberID { get; set; }
      public int PaymentID { get; set; }





      public clsSubscriptionPeriod (int PeriodID,DateTime StartDate,DateTime EndDate,float Fees,bool IsPaid,int MemberID,int PaymentID)
      {
          this.PeriodID = PeriodID;
          this.StartDate = StartDate;
          this.EndDate = EndDate;
          this.Fees = Fees;
          this.IsPaid = IsPaid;
          this.MemberID = MemberID;
          this.PaymentID = PaymentID;
          Mode  = enMode.Update ;

      }




      public clsSubscriptionPeriod(DateTime StartDate, DateTime EndDate, float Fees, bool IsPaid, int MemberID, int PaymentID)
      {
          this.PeriodID = -1;
          this.StartDate = StartDate ;
          this.EndDate = EndDate;
          this.Fees = Fees;
          this.IsPaid = IsPaid;
          this.MemberID =MemberID;
          this.PaymentID = PaymentID;
          Mode = enMode.AddNew;

      }
      public clsSubscriptionPeriod ()
      {

      }




      public bool Save()
      {
          switch (Mode )
          {
              case enMode.AddNew:
                  if(_AddNewSubscriptionPeriod())
                  {
                      Mode = enMode.Update;
                      return true;
                  }
                  else
                  {
                      return false;
                  }

              case enMode.Update:
                  return (_Update());
          }
          return false;
      }
      private  bool _AddNewSubscriptionPeriod()
      {
          PeriodID = clsPeriodDataAccess.AddNewPeriod(StartDate, EndDate, Fees, IsPaid, MemberID, PaymentID);
          return (PeriodID > -1);
      }


      public static  DataTable GetAllSubscriptionPeriod()
      {
          return clsPeriodDataAccess.GetAllSubScription();
      }





 

      private  bool _Update()
      {
          return clsPeriodDataAccess.UpdatePeriod(PeriodID, StartDate, EndDate, Fees, IsPaid, MemberID, PaymentID);
      }



      public static bool GetPeriodInfoByID(int PeriodID,ref string MemberName,ref DateTime PeriodStart ,ref DateTime PeriodEnd ,ref float PeriodAmount ,ref string PeriodState,ref int PaymentID )
      {
          
         return clsPeriodDataAccess.GetPeriodInfoByID(PeriodID, ref  MemberName, ref PeriodStart, ref  PeriodEnd, ref  PeriodAmount, ref  PeriodState,ref PaymentID );
       

      }



      public static bool IsPeriodExsits(int PeriodID)
      {
          return clsPeriodDataAccess.IsPeriodExsits(PeriodID);
      }



      public static bool IsPeriodExsitsByMemberID(int MemberID)
      {
          return clsPeriodDataAccess.IsPeriodExsitsByMemberID(MemberID);
      }




      public static bool GetPeriodInfoByMemberID( ref int PeriodID, int MemberID,ref int PeriodPayment)
      {

          return clsPeriodDataAccess.GetPeriodInfoByMemberID(ref PeriodID, MemberID,ref  PeriodPayment);


      }


      public static bool Delete(int PeriodID)
      {
          return clsPeriodDataAccess.Delete(PeriodID);
      }
    }
}
