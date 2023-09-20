using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace KarateDataAccessLayer
{
 public    class clsBeltRanksDataAccess
    {


     public static DataTable GetAllBeltRanks()
     {
         DataTable datatable = new DataTable();
        
         SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

         string Query = @"Select * from BeltRanks";
         SqlCommand Command = new SqlCommand(Query, Connection);
       
         try
         {
             Connection.Open();
             SqlDataReader Reader = Command.ExecuteReader();
             if (Reader.HasRows)
             {
                 datatable.Load(Reader);
             }
             Reader.Close();
         }
         catch (Exception ex)
         {

         }
         finally
         {
             Connection.Close();
         }
         return datatable;
     }





     public static short GetBeltID(string RankName)
     {

         short RankID=-1;
         short Index=-1;
         SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

         string Query = @"Select RankID from BeltRanks where RankName=@RankName";
         SqlCommand Command = new SqlCommand(Query, Connection);
         Command.Parameters.AddWithValue("@RankName", RankName);

         try
         {
             Connection.Open();
             Object Result = Command.ExecuteScalar();
             if(Result !=null&& short.TryParse (Result.ToString(),out Index))
             {
                 RankID = Index;
             }
         }
         catch (Exception ex)
         {

         }
         finally
         {
             Connection.Close();
         }
         return RankID;

     }



     public static bool Find(short RankID,ref string BeltName,ref float Fees)
     {

         bool IsFound = false;
         SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

         string Query = @"Select *  from BeltRanks where RankID=@RankID";
         SqlCommand Command = new SqlCommand(Query, Connection);
         Command.Parameters.AddWithValue("@RankID", RankID);

         try
         {
             Connection.Open();
             SqlDataReader Reader = Command.ExecuteReader();
             if (Reader.Read ())
             {
                 IsFound = true;
                 BeltName = (string)Reader["RankName"];
                 Fees = Convert.ToSingle(Reader  ["TestFees"]);
             }
             Reader.Close();
             
         }
         catch (Exception ex)
         {

         }
         finally
         {
             Connection.Close();
         }
         return (IsFound);

     }



     public static bool UpdateBelt(int BeltID, string BeltName, float TestFees)
     {
         int RowsAffected = 0;
         SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

         string Query = @"UPDATE [BeltRanks] set RankName=@RankName,
                              TestFees=@TestFees
                             where RankID=@RankID";

         SqlCommand Command = new SqlCommand(Query, Connection);
         Command.Parameters.AddWithValue("@RankName", BeltName  );
         Command.Parameters.AddWithValue("@TestFees", TestFees);
         Command.Parameters.AddWithValue("@RankID", BeltID );
        

         try
         {
             Connection.Open();
             RowsAffected = Command.ExecuteNonQuery();

         }
         catch (Exception ex)
         {

         }
         finally
         {
             Connection.Close();
         }
         return (RowsAffected > 0);
     }



     public static bool IsBeltExsits(int BeltID)
     {
         bool IsFound = false;
         SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

         string Query = @"Select Found=1 from [BeltRanks] where RankID=@RankID";

         SqlCommand Command = new SqlCommand(Query, Connection);
         Command.Parameters.AddWithValue("@RankID", BeltID );

         try
         {
             Connection.Open();
             SqlDataReader Reader = Command.ExecuteReader();
             if (Reader.Read())
             {
                 IsFound = true;
             }
             Reader.Close();

         }
         catch (Exception ex)
         {

         }
         finally
         {
             Connection.Close();
         }
         return IsFound;
     }




     public static bool Delete(int BeltID)
     {
         short RowsAffected = 0;
         SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

         string Query = @"delete from  [BeltRanks] where RankID=@RankID";

         SqlCommand Command = new SqlCommand(Query, Connection);
         Command.Parameters.AddWithValue("@RankID", BeltID );

         try
         {
             Connection.Open();
             RowsAffected = (short)Command.ExecuteNonQuery();



         }
         catch (Exception ex)
         {

         }
         finally
         {
             Connection.Close();
         }
         return (RowsAffected > 0);
     }





     public static float GetTestFeesByID(int RankID)
     {
         float TestFees = -1;
       
         SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

         string Query = @"select TestFees from BeltRanks where RankID=@RankID";
         SqlCommand Command = new SqlCommand(Query, Connection);
         Command.Parameters.AddWithValue("@RankID", RankID);
        

         try
         {
             Connection.Open();
             object Result = Command.ExecuteScalar();
             if (Result != null)
             {
                 TestFees = Convert.ToSingle(Result.ToString());
             }
         }
         catch (Exception ex)
         {

         }
         finally
         {
             Connection.Close();
         }
         return TestFees;
     }

    }
}
