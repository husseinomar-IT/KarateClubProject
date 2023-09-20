using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace KarateDataAccessLayer
{
    public class clsPeriodDataAccess
    {
        public static int AddNewPeriod(DateTime StartDate, DateTime EndDate, float Fees, bool IsPaid, int MemberID, int PaymentID)
        {
            int PeriodID = -1;
            int IndexID = -1;
            SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

            string Query = @"Insert INTO SubscriptionPeriods (StartDate,EndDate,Fees,Paid,MemberID,PaymentID)
                         Values(@StartDate,@EndDate,@Fees,@Paid,@MemberID,@PaymentID);
                            Select SCOPE_Identity(); ";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@StartDate", StartDate);
            Command.Parameters.AddWithValue("@EndDate", EndDate);
            Command.Parameters.AddWithValue("@Fees", Fees);
            Command.Parameters.AddWithValue("@Paid", IsPaid);
            Command.Parameters.AddWithValue("@MemberID", MemberID);
            Command.Parameters.AddWithValue("@PaymentID", PaymentID);



            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out IndexID))
                {
                    PeriodID = IndexID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }
            return PeriodID;

        }

        public static bool UpdatePeriod(int PeriodID, DateTime PeriodStart, DateTime PeriodEnd, float Fees, bool IsPaid, int MemberID, int PaymentID)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

            string Query = @"UPDATE [SubscriptionPeriods] set StartDate=@StartDate,
                              EndDate=@EndDate,
                            Fees=@Fees,
                            Paid=@Paid,
                            MemberID=@MemberID,
                             PaymentID=@PaymentID 
                             where PeriodID=@PeriodID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@StartDate", PeriodStart );
            Command.Parameters.AddWithValue("@EndDate", PeriodEnd);
            Command.Parameters.AddWithValue("@Fees", Fees );
            Command.Parameters.AddWithValue("@Paid", IsPaid );
            Command.Parameters.AddWithValue("@MemberID", MemberID);
            Command.Parameters.AddWithValue("@PaymentID", PaymentID );
            Command.Parameters.AddWithValue("@PeriodID", PeriodID );

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



        public static DataTable GetAllSubScription()
        {
            DataTable datatable = new DataTable();

            SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

            string Query = @"  select SubscriptionPeriods.PeriodID,
                            Persons.FirstName+' '+Persons.LastName as MemberName,
                           SubscriptionPeriods.StartDate as StartPeriodDate ,
                           EndDate as EndPeriodDate,Fees,IsPaid=
                           case
                           when Paid=1 then 'Yes'
                           else 'No'
                           end
                           from Members inner join Persons on Members.PersonID=Persons.PersonID
                           inner join SubscriptionPeriods on SubscriptionPeriods.MemberID=Members.MemberID 
                           where Members.MemberID=SubscriptionPeriods.MemberID";

            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    datatable.Load(Reader);
                }
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




        public static bool GetPeriodInfoByID(int PeriodID, ref string MemberName, ref DateTime PeriodStart, ref DateTime PeriodEnd, ref float PeriodAmount, ref string PeriodState,ref int PaymentID)
        {
            bool IsFound = false;
            SqlConnection Conncetion = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);
            string Query = @"     select * from(

						  select SubscriptionPeriods.PeriodID,
						  SubscriptionPeriods.PaymentID,
                            Persons.FirstName+' '+Persons.LastName as MemberName,
                           SubscriptionPeriods.StartDate as StartPeriodDate ,
                           EndDate as EndPeriodDate,Fees,IsPaid=
                           case
                           when Paid=1 then 'Yes'
                           else 'No'
                           end
                           from Members inner join Persons on Members.PersonID=Persons.PersonID
                           inner join SubscriptionPeriods on SubscriptionPeriods.MemberID=Members.MemberID 
						   )R1
						   where PeriodID=@PeriodID";
            SqlCommand Command = new SqlCommand(Query, Conncetion);
            Command.Parameters.AddWithValue("@PeriodID", PeriodID);
            try
            {
                Conncetion.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    MemberName = (string)Reader["MemberName"];
                    PeriodStart = (DateTime)Reader["StartPeriodDate"];
                    PaymentID = (int)Reader["PaymentID"];
                    PeriodEnd = (DateTime)Reader["EndPeriodDate"];
                    PeriodAmount = Convert.ToSingle(Reader["Fees"]);
                    PeriodState = (string)Reader["IsPaid"];
                }
                Reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Conncetion.Close();
            }
            return IsFound;



        }


        public static bool GetPeriodInfoByMemberID( ref int  PeriodID,int MemberID,ref int PaymentID)
        {
            bool IsFound = false;
            SqlConnection Conncetion = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);
            string Query = @"select PeriodID,PaymentID  from SubscriptionPeriods Where MemberID=@MemberID";
            SqlCommand Command = new SqlCommand(Query, Conncetion);
            Command.Parameters.AddWithValue("@MemberID", MemberID);
            try
            {
                Conncetion.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;

                    PeriodID = (int)Reader["PeriodID"];
                    PaymentID = (int)Reader["PaymentID"];
                 
                }
                Reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Conncetion.Close();
            }
            return IsFound;



        }


        public static bool IsPeriodExsits(int PeriodID)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

            string Query = @"select Found=1 from SubscriptionPeriods where  PeriodID=@PeriodID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PeriodID", PeriodID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result!=null)
                {
                    IsFound = true;
                }
             

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




        public static bool IsPeriodExsitsByMemberID(int MemberID)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

            string Query = @"select Found=1 from SubscriptionPeriods Where MemberID=@MemberID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@MemberID", MemberID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                {
                    IsFound = true;
                }


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




            public static bool Delete(int PeriodID)
        {
            short RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

            string Query = @"delete SubscriptionPeriods where PeriodID=@PeriodID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PeriodID", PeriodID);

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
            return (RowsAffected>0);
        }





    }





    
}
