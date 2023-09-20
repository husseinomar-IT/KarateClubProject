using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace KarateDataAccessLayer
{
    public class clsUserDataAccess
    {

        public static bool FindByUsername(string Username, ref int UserID, ref string Password, ref int Permission, ref int FKPersonID)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);
            //          
            string Query = @"Select * from  Users where UserName=@UserName";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("UserName", Username);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    UserID = (int)Reader["UserID"];
                    Password = (string)Reader["Password"];
                    Permission = (int)Reader["Permission"];
                    FKPersonID = (int)Reader["PersonID"];

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

        public static bool FindByID( ref string Username,  int UserID, ref string Password, ref int Permission, ref int FKPersonID)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);
            //          
            string Query = @"Select * from  Users where UserID =@UserID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    Username = (string)Reader["UserName"];
                    Password = (string)Reader["Password"];
                    Permission = (int)Reader["Permission"];
                    FKPersonID = (int)Reader["PersonID"];

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

        public static bool FindByUsernameAndPassword(string Username, ref int UserID, string Password, ref int Permission, ref int FKPersonID)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);
            //          
            string Query = @"Select * from  Users where UserName=@UserName and Password=@Password";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserName", Username);
            Command.Parameters.AddWithValue("@Password", Password);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;
                    UserID = (int)Reader["UserID"];
                    Permission = (int)Reader["Permission"];
                    FKPersonID = (int)Reader["PersonID"];

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




        public static bool UpdateUser(int UserID,string Username,string Password,int Permission)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);
            //          
            string Query = @"Update Users set  UserName=@UserName,
                                Password=@Password,
                                 Permission=@Permission
                                 where UserID=@UserID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserName", Username);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@Permission", Permission);
            Command.Parameters.AddWithValue("UserID", UserID);
            try
            {
                Connection.Open();
               RowsAffected =Command.ExecuteNonQuery();
               

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
        public static bool IsUserExsist(string Username)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);
            //          
            string Query = @"Select Found=1 from  Users where UserName=@UserName";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("UserName", Username);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                IsFound = Reader.HasRows;
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


        public static int AddNewUser(int PersonID, string Username, string Password,int Permission)
        {
            int UserID = -1;
            int IndexID = -1;
            SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

            string Query = @"Insert INTO Users (PersonID,UserName,Password,Permission)
                         Values(@PersonID,@UserName,@Password,@Permission);
                            Select SCOPE_Identity(); ";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@UserName", Username);
            Command.Parameters.AddWithValue("@Password", Password );
            Command.Parameters.AddWithValue("@Permission", Permission);
        

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out IndexID))
                {
                    UserID  = IndexID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }
            return UserID;
        }


        public static bool IsUserExsist(string Username,string Password)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);
            //          
            string Query = @"Select Found=1 from  Users where UserName=@UserName and Password=@Password";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserName", Username);
            Command.Parameters.AddWithValue("@Password", Password);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                IsFound = Reader.HasRows;
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




        public static bool DeleteUser(string UserName)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);
            //          
            string Query = @"Delete from Users where UserName=@UserName";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserName", UserName);
         
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




        public static DataTable GetAllUsers()
        {
            DataTable datatable = new DataTable();

            SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

            string Query = @"select Users.UserID, FullName=Persons.FirstName+' '+Persons.LastName
                          ,
                         Users.UserName,
                         Users.Password,
						 Users.Permission,
						 Persons.Phone,
						 Persons.Email,
						 Persons.Address
                          from Users inner join Persons on 
                          Users.PersonID=Persons.PersonID
                      
                          ";
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


//        public static bool UpdateUser(string Username, string Password, int Permission)
//        {
//            int RowAffected = 0;
//            SqlConnection Connection = new SqlConnection(clsBankDataAccsessSettings.ConnectionString);


//            string Query = @"Update [Users] set 
//                       [Password]=@Password,
//                      [Permission]=@Permission
//                      
//
//                       where UserName=@UserName ";

//            SqlCommand Command = new SqlCommand(Query, Connection);
//            Command.Parameters.AddWithValue("@Password", Password);
//            Command.Parameters.AddWithValue("@Permission", Permission);
//            Command.Parameters.AddWithValue("@UserName", Username);
//            try
//            {
//                Connection.Open();
//                RowAffected = Command.ExecuteNonQuery();

//            }
//            catch (Exception ex)
//            {

//            }

//            finally
//            {
//                Connection.Close();
//            }
//            return (RowAffected > 0);

//        }



//        public static bool DeleteUser(string Username)
//        {
//            int RowAffected = 0;
//            SqlConnection Connection = new SqlConnection(clsBankDataAccsessSettings.ConnectionString);


//            string Query = @"Delete from [Users]  
//                               
//                       where UserName=@UserName ";

//            SqlCommand Command = new SqlCommand(Query, Connection);

//            Command.Parameters.AddWithValue("@UserName", Username);
//            try
//            {
//                Connection.Open();
//                RowAffected = Command.ExecuteNonQuery();

//            }
//            catch (Exception ex)
//            {

//            }

//            finally
//            {
//                Connection.Close();
//            }
//            return (RowAffected > 0);
//        }



//        public static bool DeleteUser(int userid)
//        {
//            int RowAffected = 0;
//            SqlConnection Connection = new SqlConnection(clsBankDataAccsessSettings.ConnectionString);


//            string Query = @"Delete from [Users]  
//                               
//                       where UserID=@UserID ";

//            SqlCommand Command = new SqlCommand(Query, Connection);

//            Command.Parameters.AddWithValue("@UserID", userid);
//            try
//            {
//                Connection.Open();
//                RowAffected = Command.ExecuteNonQuery();

//            }
//            catch (Exception ex)
//            {

//            }

//            finally
//            {
//                Connection.Close();
//            }
//            return (RowAffected > 0);
//        }



//        public static int AddNewUser(string Username, string Password, int Permission, int PKPersonID)
//        {
//            int UserID = -1;
//            int InsertedID = -1;
//            SqlConnection Connection = new SqlConnection(clsBankDataAccsessSettings.ConnectionString);
//            string Query = @"Insert Into Users(UserName,Password,Permission,PersonID)
//                         Values  (@username,@Password,@Permission,@PersonID);
//                            SELECT SCOPE_IDENTITY();";

//            SqlCommand Command = new SqlCommand(Query, Connection);
//            Command.Parameters.AddWithValue("@username", Username);
//            Command.Parameters.AddWithValue("@Password", Password);
//            Command.Parameters.AddWithValue("@Permission", Permission);
//            Command.Parameters.AddWithValue("@PersonID", PKPersonID);
//            try
//            {
//                Connection.Open();
//                object Result = Command.ExecuteScalar();
//                if (Result != null && int.TryParse(Result.ToString(), out InsertedID))
//                {
//                    UserID = InsertedID;
//                }
//            }
//            catch (Exception ex)
//            {

//            }

//            finally
//            {
//                Connection.Close();
//            }
//            return UserID;
//        }





//        public static DataTable GetAllUsers()
//        {
//            DataTable Dt = new DataTable();
//            SqlConnection Connection = new SqlConnection(clsBankDataAccsessSettings.ConnectionString);
//            string Query = @"Select UserID,FullName=FirstName+' '+LastName,Email,Phone,UserName,Password,Permission
//                           from Users inner join Persons on 
//                                Users.PersonID=Persons.PersonID";
//            SqlCommand Command = new SqlCommand(Query, Connection);
//            try
//            {
//                Connection.Open();
//                SqlDataReader Reader = Command.ExecuteReader();
//                if (Reader.HasRows)
//                {
//                    Dt.Load(Reader);
//                }
//                Reader.Close();

//            }
//            catch (Exception ex)
//            {

//            }

//            finally
//            {
//                Connection.Close();
//            }
//            return Dt;
//        }





//        public static bool RegisterLogin(int UserID, DateTime datetime)
//        {
//            int RowsAffected = 0;


//            SqlConnection Connection = new SqlConnection(clsBankDataAccsessSettings.ConnectionString);
//            string Query = @"Insert Into LoginRegisters(UserID,RegisterDateTime)
//                         Values  (@UserID,@RegisterDateTime)";


//            SqlCommand Command = new SqlCommand(Query, Connection);
//            Command.Parameters.AddWithValue("@UserID", UserID);
//            Command.Parameters.AddWithValue("@RegisterDateTime", datetime);

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




//        public static DataTable GetAllLoginRegister()
//        {
//            DataTable Dt = new DataTable();
//            SqlConnection Connection = new SqlConnection(clsBankDataAccsessSettings.ConnectionString);
//            string Query = @"select Username,Password,RegisterDateTime,Permission 
//                           from LoginRegisters  inner join Users on
//                           LoginRegisters.UserID=Users.UserID;";
//            SqlCommand Command = new SqlCommand(Query, Connection);
//            try
//            {
//                Connection.Open();
//                SqlDataReader Reader = Command.ExecuteReader();
//                if (Reader.HasRows)
//                {
//                    Dt.Load(Reader);
//                }
//                Reader.Close();

//            }
//            catch (Exception ex)
//            {

//            }

//            finally
//            {
//                Connection.Close();
//            }
//            return Dt;
//        }

    }
}
