using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace KarateDataAccessLayer
{
    public class clsPersonDataAccess
    {
        public static bool Find(int PersonID, ref string FirstName,ref string LastName, ref string Address, ref string Email, ref string Phone)
        {
            bool IsFound = false;
            SqlConnection Conncetion = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);
            string Query = "Select * from Persons where PersonID=@PersonID";
            SqlCommand Command = new SqlCommand(Query, Conncetion);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                Conncetion.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    FirstName = (string)Reader["FirstName"];
                    LastName = (string)Reader["LastName"];
                  
                    Phone = (string)Reader["Phone"];
                    Email = (string)Reader["Email"];
                    if( Reader["Address"]!=DBNull.Value)
                    {
                        Address = (string)Reader["Address"];
                    }
                    else
                    {
                        Address = "";
                    }
                 

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

//        public static bool UpdatePerson(int PersonID, string FirstName, string LastName, string Email, string Phone)
//        {
//            int RowsAffected = 0;
//            SqlConnection Connection = new SqlConnection(clsBankDataAccsessSettings.ConnectionString);
//            string Query = @"Update [Persons] set 
//                         [FirstName]=@FirstName,
//                         [LastName]=@LastName,
//                         [Email]=@Email,
//                        [Phone]=@Phone
//                      where PersonID=@PersonID";
//            SqlCommand Command = new SqlCommand(Query, Connection);
//            Command.Parameters.AddWithValue("@FirstName", FirstName);
//            Command.Parameters.AddWithValue("@LastName", LastName);
//            Command.Parameters.AddWithValue("@Email", Email);
//            Command.Parameters.AddWithValue("@Phone", Phone);
//            Command.Parameters.AddWithValue("@PersonID", PersonID);
//            try
//            {
//                Connection.Open();
//                RowsAffected = Command.ExecuteNonQuery();


//            }
//            catch (Exception ex)
//            {

//            }

//            finally
//            {
//                Connection.Close();
//            }

//            return (RowsAffected > 0);
//        }



        public static int AddNewPerson(string FirstName,string LastName, string Address, string Email, string Phone)
        {
            int PersonID = -1;
            int IndexID = -1;
            SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

            string Query = @"Insert INTO Persons(FirstName,LastName,Address,Email,Phone)
                         Values(@FirstName,@LastName,@Address,@Email,@Phone);
                            Select SCOPE_Identity(); ";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@Email", Email);
            Command.Parameters.AddWithValue("@Phone", Phone);
            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out IndexID))
                {
                    PersonID = IndexID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }
            return PersonID;


        }

        public static bool UpdatePerson(int PersonID,string FirstName, string LastName, string Address, string Email, string Phone)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

            string Query = @"UPDATE Persons SET
                          FirstName=@FirstName,
                          LastName=@LastName,
                          Address=@Address,
                          Phone=@Phone,
                          Email=@Email 
                          where PersonID=@PersonID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@Email", Email);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
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


    }
}
