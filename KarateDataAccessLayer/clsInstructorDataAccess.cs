using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace KarateDataAccessLayer
{
  public   class clsInstructorDataAccess
    {


      public static bool Find(int InstructorID, ref int FKPersonID, ref string Quelification)
      {
          bool IsFound = false;
          SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);
          string Query = @"select * from Instructors where InstructorID=@InstructorID";
          SqlCommand command = new SqlCommand(Query, Connection);
          command.Parameters.AddWithValue("@InstructorID", InstructorID);
          try
          {
              Connection.Open();
              SqlDataReader Reader = command.ExecuteReader();
              if (Reader.Read())
              {
                  IsFound = true;
                  FKPersonID = (int)Reader["PersonID"];
                  if(Reader["Qualification"]!=DBNull.Value)
                  {
                      Quelification = (string)Reader["Qualification"];
                  }
                  else
                  {
                      Quelification = "";
                  }
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







      public static bool GetInstuctorIDByFullName(string FullName,ref int InstructorID)
      {
          bool IsFound = false;
          SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);
          string Query = @"  select InstructorID from(

						  select Instructors.InstructorID,FullName=Persons.FirstName+' '+Persons.LastName,
                          Persons.Address,Persons.Email,Persons.Phone,Instructors.Qualification 
                         from Instructors inner join Persons
                            on Instructors.PersonID=Persons.PersonID)R1
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
                  InstructorID = (int)Reader["InstructorID"];
                
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

      public static DataTable GetAllInstructors()
      {
          DataTable datatable = new DataTable();

          SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

          string Query = @"select Instructors.InstructorID,FullName=Persons.FirstName+' '+Persons.LastName,
                          Persons.Address,Persons.Email,Persons.Phone,Instructors.Qualification 
                         from Instructors inner join Persons
                            on Instructors.PersonID=Persons.PersonID";
                        
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






      public static bool IsInstructorExsits(int InstructorID)
      {
          bool IsFound = false;
          SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

          string Query = @"Select Found=1 from Instructors where InstructorID=@InstructorID";

          SqlCommand Command = new SqlCommand(Query, Connection);
          Command.Parameters.AddWithValue("@InstructorID", InstructorID);

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





      public static bool Delete(int InstructorID)
      {
          int Rowsaffected = 0;
          SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

          string Query = @"Delete from [Instructors] where InstructorID=@InstructorID";

          SqlCommand Command = new SqlCommand(Query, Connection);
          Command.Parameters.AddWithValue("@InstructorID", InstructorID);

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









      public static int AddNewInstructor(int PersonID, string Qualification)
      {
          int InstructorID = -1;
          int IndexID = -1;
          SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

          string Query = @"Insert INTO Instructors (PersonID,Qualification)
                         Values(@PersonID,@Qualification);
                            Select SCOPE_Identity(); ";
          SqlCommand Command = new SqlCommand(Query, Connection);
          Command.Parameters.AddWithValue("@PersonID", PersonID);
          Command.Parameters.AddWithValue("@Qualification", Qualification);

          try
          {
              Connection.Open();
              object Result = Command.ExecuteScalar();
              if (Result != null && int.TryParse(Result.ToString(), out IndexID))
              {
                  InstructorID = IndexID;
              }
          }
          catch (Exception ex)
          {

          }
          finally
          {
              Connection.Close();
          }
          return InstructorID;
      }















      public static bool UpdateInstructor(int InstructorID, string Qualification)
      {
          int RowsAffected = 0;
          SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

          string Query = @"UPDATE [Instructors] set [Qualification]=@Qualification
                             
                             where InstructorID=@InstructorID";

          SqlCommand Command = new SqlCommand(Query, Connection);
          Command.Parameters.AddWithValue("@Qualification", Qualification);
          Command.Parameters.AddWithValue("@InstructorID", InstructorID);
       

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
