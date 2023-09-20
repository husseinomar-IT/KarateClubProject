using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace KarateDataAccessLayer
{
   public class clsMembers_InstructorsDataAccess
    {
        public static  int AddNewAssign(int MemberID,int InstructorID,DateTime dateAssign)
       {
           int AssignID = -1;
           int IndexID = -1;
           SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

           string Query = @"Insert INTO MemberInstructor (MemberID,InstructorID,AssignDate)
                         Values(@MemberID,@InstructorID,@dateAssign);
                            Select SCOPE_Identity(); ";
           SqlCommand Command = new SqlCommand(Query, Connection);
           Command.Parameters.AddWithValue("@MemberID", MemberID);
           Command.Parameters.AddWithValue("@InstructorID", InstructorID);
           Command.Parameters.AddWithValue("@dateAssign", dateAssign );
           try
           {
               Connection.Open();
               object Result = Command.ExecuteScalar();
               if (Result != null && int.TryParse(Result.ToString(), out IndexID))
               {
                   AssignID = IndexID;
               }
           }
           catch (Exception ex)
           {

           }
           finally
           {
               Connection.Close();
           }
           return AssignID;
       }



        public static DataTable GetAllAssign()
        {
            DataTable datatable = new DataTable();

            SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

            string Query = @"select MemberInstructor.Member_Instructor_ID,
                           MemberName=(select Persons.FirstName+' '+Persons.LastName from Members inner join Persons on Members.PersonID=Persons.PersonID
                           where  MemberID=MemberInstructor.MemberID),
                           InstructoName=(select Persons.FirstName+' '+Persons.LastName from Instructors inner join Persons on Instructors.PersonID=Persons.PersonID 
                           where InstructorID=MemberInstructor.InstructorID),MemberInstructor.AssignDate 
                           from MemberInstructor inner join Members  on MemberInstructor.MemberID=Members.MemberID
                            inner join Instructors on MemberInstructor.InstructorID=Instructors.InstructorID";

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




        public static bool GetAssignInfoByMemberID(ref int Member_InstructorID, int MemberID)
        {
            bool IsFound = false;
            SqlConnection Conncetion = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);
            string Query = @"
                          select Member_Instructor_ID from MemberInstructor where MemberID=@MemberID";
            SqlCommand Command = new SqlCommand(Query, Conncetion);
            Command.Parameters.AddWithValue("@MemberID", MemberID);
            try
            {
                Conncetion.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    IsFound = true;

                    Member_InstructorID = (int)Reader["Member_Instructor_ID"];
                 

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

        public static bool UpdateAssign(int AssignID,int MemberID, int InstructorID, DateTime dateAssign)
        {
            short RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

            string Query = @"UPDATE  MemberInstructor set MemberID=@MemberID,
                             InstructorID=@InstructorID,
                              AssignDate=@AssignDate
                              where Member_Instructor_ID=@AssignID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@MemberID", MemberID);
            Command.Parameters.AddWithValue("@InstructorID", InstructorID);
            Command.Parameters.AddWithValue("@AssignDate", dateAssign);
            Command.Parameters.AddWithValue("@AssignID", AssignID );
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
            return (RowsAffected>0) ;
        }


        public static bool FindByID(int AssignID, ref string MemberName, ref string InstructorName,ref DateTime datetime)
        {

            bool IsFound = false;
            DataTable datatable = new DataTable();

            SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

            string Query = @"select MemberInstructor.Member_Instructor_ID,
                           MemberName=(select Persons.FirstName+' '+Persons.LastName from Members inner join Persons on Members.PersonID=Persons.PersonID
                           where  MemberID=MemberInstructor.MemberID),
                           InstructoName=(select Persons.FirstName+' '+Persons.LastName from Instructors inner join Persons on Instructors.PersonID=Persons.PersonID 
                           where InstructorID=MemberInstructor.InstructorID),MemberInstructor.AssignDate 
                           from MemberInstructor inner join Members  on MemberInstructor.MemberID=Members.MemberID
                            inner join Instructors on MemberInstructor.InstructorID=Instructors.InstructorID
							where MemberInstructor.Member_Instructor_ID=@AssignID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.Add("@AssignID", AssignID);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read ())
                {
                    IsFound = true;
                    MemberName = (string)Reader["MemberName"];
                    InstructorName = (string)Reader["InstructoName"];
                    datetime = (DateTime)Reader["AssignDate"];
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
            return IsFound ;
        }



        public static bool IsAssignExsits(int AssignID)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

            string Query = @"Select Found=1 from MemberInstructor where Member_Instructor_ID=@AssignID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AssignID", AssignID);

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




        public static bool Delete(int AssignID)
        {
            short RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

            string Query = @"delete MemberInstructor where Member_Instructor_ID=@AssignID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@AssignID", AssignID);

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
