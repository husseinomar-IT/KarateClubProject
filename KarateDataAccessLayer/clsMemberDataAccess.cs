using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace KarateDataAccessLayer
{
   public  class clsMemberDataAccess
    {
       public static bool  Find(int MemberID,ref int  FKPersonID,ref string EmergencyContactInfo, ref char  gender,ref short  LastBeltRanks,ref bool IsActive)
       {
           bool IsFound = false;
           SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);
           string Query = @"select * from Members where MemberID=@MemberID";
           SqlCommand command = new SqlCommand(Query, Connection);
           command.Parameters.AddWithValue("@MemberID", MemberID);
           try
           {
               Connection.Open();
               SqlDataReader Reader = command.ExecuteReader();
               if(Reader .Read ())
               {
                   IsFound = true;
                   FKPersonID = (int) Reader["PersonID"];
                   EmergencyContactInfo = (string)Reader["EmergencyContactInfo"];
                   gender = Convert.ToChar(Reader["Gender"]);
                   LastBeltRanks = (short)Reader["LastBeltRank"];
                   IsActive = (bool)Reader["ISActive"];
               }
               Reader.Close();
           }

           catch(Exception ex)
           {

           }

           finally
           {
               Connection.Close();
           }
           return IsFound;
       }

       public static bool GetMemberIDByFullName(string FullName,ref int MemberID)
       {
           bool IsFound = false;
         
           SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);
           string Query =@"select MemberID from(
                           select Members.MemberID, FullName=Persons.FirstName+' '+Persons.LastName
                         
                          from Members inner join Persons on 
                          Members.PersonID=Persons.PersonID
                        )R1
						  where FullName=@FullName";
           SqlCommand command = new SqlCommand(Query, Connection);
           command.Parameters.AddWithValue("@FullName", FullName);
           try
           {
               Connection.Open();
               SqlDataReader Reader = command.ExecuteReader();
               if (Reader.Read())
               {
                   IsFound = true;
                   MemberID = (int)Reader["MemberID"];

                 
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
           return IsFound  ;
       }

       public static int AddNewMember(int PersonID,string EmergencyContactInfo,char Gender,short LastBeltRanks,bool IsActive )
       {
           int MemberID = -1;
           int IndexID = -1;
           SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

           string Query = @"Insert INTO Members (PersonID,EmergencyContactInfo,Gender,LastBeltRank,IsActive)
                         Values(@PersonID,@EmergencyContactInfo,@Gender,@LastBeltRank,@IsActive);
                            Select SCOPE_Identity(); ";
           SqlCommand Command = new SqlCommand(Query, Connection);
           Command.Parameters.AddWithValue("@PersonID", PersonID);
           Command.Parameters.AddWithValue("@EmergencyContactInfo", EmergencyContactInfo);
           Command.Parameters.AddWithValue("@Gender", Gender);
           Command.Parameters.AddWithValue("@LastBeltRank", LastBeltRanks);
           Command.Parameters.AddWithValue("@IsActive", IsActive);

           try
           {
               Connection.Open();
               object Result = Command.ExecuteScalar();
               if (Result != null && int.TryParse(Result.ToString(), out IndexID))
               {
                   MemberID = IndexID;
               }
           }
           catch (Exception ex)
           {

           }
           finally
           {
               Connection.Close();
           }
           return MemberID;
       }


       public static DataTable GetAllMembers()
       {
           DataTable datatable = new DataTable();

           SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

           string Query = @"select Members.MemberID, FullName=Persons.FirstName+' '+Persons.LastName,Gender=
                           case 
                          when Members.Gender='M' then 'Male'
                          else 'Female'
                          end
                          ,
                          BeltName=BeltRanks.RankName,
                          Members.IsActive
                          from Members inner join Persons on 
                          Members.PersonID=Persons.PersonID
                          inner join BeltRanks on
                          Members.LastBeltRank=BeltRanks.RankID
                          ";
           SqlCommand Command = new SqlCommand(Query, Connection);
           

           try
           {
               Connection.Open();
               SqlDataReader Reader = Command.ExecuteReader();
               
               if (Reader .HasRows )
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
           return datatable ;
       }

       public static bool UpdateMember(int MemberID, string EmergencyContactInfo, char Gender, short LastBeltRanks, bool IsActive)
       {
           int RowsAffected = 0;
           SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

           string Query = @"UPDATE Members set EmergencyContactInfo=@EmergencyContactInfo,
                              Gender=@Gender,
                            LastBeltRank=@LastBeltRank,
                            IsActive=@IsActive 
                             where MemberID=@MemberID";
                            
           SqlCommand Command = new SqlCommand(Query, Connection);
           Command.Parameters.AddWithValue("@EmergencyContactInfo", EmergencyContactInfo);
           Command.Parameters.AddWithValue("@Gender", Gender);
           Command.Parameters.AddWithValue("@LastBeltRank", LastBeltRanks);
           Command.Parameters.AddWithValue("@IsActive", IsActive);
           Command.Parameters.AddWithValue("@MemberID", MemberID);

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
           return (RowsAffected>0);
       }



       public static bool IsMemberExsits(int MemberID)
       {
           bool IsFound = false;
           SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

           string Query = @"Select Found=1 from Members where MemberID=@MemberID";

           SqlCommand Command = new SqlCommand(Query, Connection);
           Command.Parameters.AddWithValue("@MemberID", MemberID);

           try
           {
               Connection.Open();
               SqlDataReader Reader = Command.ExecuteReader();
               if(Reader.Read())
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




       public static bool Delete(int MemberID)
       {
           int Rowsaffected = 0;
           SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

           string Query = @"Delete from Members where MemberID=@MemberID";

           SqlCommand Command = new SqlCommand(Query, Connection);
           Command.Parameters.AddWithValue("@MemberID", MemberID);

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
           return (Rowsaffected>0);

       }


    }
}
