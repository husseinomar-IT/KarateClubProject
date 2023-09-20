using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace KarateDataAccessLayer
{
   public  class clsPaymentDataAccess
    {


       public static int AddNewPayment(float Amount,DateTime Date,int MemberID)
       {
           int PaymentID = -1;
           int IndexID = -1;
           SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

           string Query = @"Insert INTO Payments (Amount,Date,MemberID)
                         Values(@Amount,@Date,@MemberID)
                            Select SCOPE_Identity(); ";
           SqlCommand Command = new SqlCommand(Query, Connection);
           Command.Parameters.AddWithValue("@Amount", Amount );
           Command.Parameters.AddWithValue("@Date", Date);
           Command.Parameters.AddWithValue("@MemberID", MemberID);
         


           try
           {
               Connection.Open();
               object Result = Command.ExecuteScalar();
               if (Result != null && int.TryParse(Result.ToString(), out IndexID))
               {
                   PaymentID  = IndexID;
               }
           }
           catch (Exception ex)
           {

           }
           finally
           {
               Connection.Close();
           }
           return PaymentID;

       }



       public static bool UpdatePayment(int PaymentID,float Amount,DateTime Date,int MemberID)
       {
           int RowsAffected = 0;
           SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

           string Query = @"UPDATE Payments set Amount=@Amount,
                              Date=@Date,
                            MemberID=@MemberID
                             where PaymentID=@PaymentID";

           SqlCommand Command = new SqlCommand(Query, Connection);
           Command.Parameters.AddWithValue("@Amount", Amount );
           Command.Parameters.AddWithValue("@Date", Date);
           Command.Parameters.AddWithValue("@MemberID", MemberID );
           Command.Parameters.AddWithValue("@PaymentID", PaymentID );
          

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




       public static DataTable GetAllPayment()
       {
           DataTable datatable = new DataTable();

           SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

           string Query = @"  select Payments.PaymentID,FullName=Persons.FirstName+Persons.LastName,
Payments.Amount,Payments.Date From Payments inner join Members
on Payments.MemberID=Members.MemberID
join Persons  on Members.PersonID=Persons.PersonID";

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





       public static bool Delete(int PaymentID)
       {
           int Rowsaffected = 0;
           SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

           string Query = @"Delete from Payments where PaymentID=@PaymentID";

           SqlCommand Command = new SqlCommand(Query, Connection);
           Command.Parameters.AddWithValue("@PaymentID", PaymentID );

           try
           {
               Connection.Open();
               Rowsaffected = Command.ExecuteNonQuery();

           }
           catch (Exception ex)
           {

           }
           finally
           {
               Connection.Close();
           }
           return (Rowsaffected > 0);

       }
    }
}
