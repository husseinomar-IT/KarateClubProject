using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarateDataAccessLayer;
using System.Data;

namespace KarateBusinisLayer
{
  public   class clsBeltRankcs
    {


      public int RankID { get; set; }
      public string RankName { get;set ;}
      public float TestFees { get; set; }
      public enum enMode { Update = 0, AddNew = 1 };
      public enMode Mode = enMode.Update;





      public  clsBeltRankcs ()
      {

      }
      public clsBeltRankcs (short RankID,string RankName,float TestFees)
      {
          this.RankID = RankID;
          this.RankName = RankName;
          this.TestFees = TestFees;
          Mode = enMode.Update;
      }



      public  static DataTable GetAllBeltRanks()
      {
          return clsBeltRanksDataAccess.GetAllBeltRanks();
      }


      public static short GetBeltRankIDByBeltName(string BeltName)
      {
          return clsBeltRanksDataAccess.GetBeltID(BeltName);
      }






      public   bool Update()
      {
          return clsBeltRanksDataAccess.UpdateBelt(RankID, RankName, TestFees);
      }
      public static clsBeltRankcs Find(short RankID)
      {
          string RankName = "";
          float fees = default(float);
          if (clsBeltRanksDataAccess.Find(RankID, ref RankName, ref fees))
          {
              return new clsBeltRankcs(RankID, RankName, fees);
          }
          else
          {
              return null;
          }
          

      }




      public static bool IsBeltExsits(int BeltID)
      {
          return clsBeltRanksDataAccess.IsBeltExsits(BeltID);
      }


      public static bool Delete(int BeltID)
      {
          return clsBeltRanksDataAccess.Delete(BeltID);
      }

      
      public static float GetTestFeesByID(int RankID)
      {
          return clsBeltRanksDataAccess.GetTestFeesByID(RankID);
      }


     



    }
}
