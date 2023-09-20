using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace KarateDataAccessLayer
    
{
  public   class clsBeltTestDataAccess

    {
      public static int AddNewBeltTest( int MemberID, int RankID, bool Result, DateTime Date, int InstructorID, int PaymentID)
      {
          int TestID = -1;
          int IndexID = -1;
          SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

          string Query = @"Insert INTO BeltTests (MemberID,RankID,Result,Date,TestedByInstructorID,PaymentID)
                         Values(@MemberID,@RankID,@Result,@Date,@TestedByInstructorID,@PaymentID);
                            Select SCOPE_Identity(); ";
          SqlCommand Command = new SqlCommand(Query, Connection);
          Command.Parameters.AddWithValue("@MemberID", MemberID);
          Command.Parameters.AddWithValue("@RankID", RankID);
          Command.Parameters.AddWithValue("@Result", Result);
          Command.Parameters.AddWithValue("@Date", Date);
          Command.Parameters.AddWithValue("@TestedByInstructorID", InstructorID);
          Command.Parameters.AddWithValue("@PaymentID", PaymentID);

          try
          {
              Connection.Open();
              object ResultOfInsert = Command.ExecuteScalar();
              if (ResultOfInsert != null && int.TryParse(ResultOfInsert.ToString(), out IndexID))
              {
                  TestID = IndexID;
              }
          }
          catch (Exception ex)
          {

          }
          finally
          {
              Connection.Close();
          }
          return TestID;
      }



      public static  DataTable GetAllBeltTests()
      {
          DataTable datatable = new DataTable();

          SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

          string Query = @"  select BeltTests.TestID, MemeberName=Persons.FirstName+' '+Persons.LastName,	BeltRanks.RankName,  
			                 TestedBy=(select Persons.FirstName+' '+Persons.LastName from Instructors inner join Persons on
                             Instructors.PersonID=Persons.PersonID  where InstructorID=BeltTests.TestedByInstructorID),
	                    	Date,Result=
                         	case
                         	when Result=1 then 'Successfuly'
                         	else 'Failed'
                         	end

	                		from BeltTests
	                		inner join Members on BeltTests.MemberID=Members.MemberID
	                		join Persons on Members.PersonID=Persons.PersonID
	                		join BeltRanks on BeltTests.RankID=BeltRanks.RankID";

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


      public static bool GetTestInfoByID(int TestID, ref string MemberName,ref string BeltName,ref string InstructorName,ref DateTime Date,ref bool Result,ref  int PaymentID)
      {
          bool IsFound=false;
          DataTable datatable = new DataTable();

          SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

          string Query = @"  select * from(
			select BeltTests.TestID,MemeberName=Persons.FirstName+' '+Persons.LastName,	BeltRanks.RankName,  
			TestedBy=(select Persons.FirstName+' '+Persons.LastName from Instructors inner join Persons on Instructors.PersonID=Persons.PersonID  where InstructorID=BeltTests.TestedByInstructorID)
		,Date,Result,PaymentID

			from BeltTests
			inner join Members on BeltTests.MemberID=Members.MemberID
			join Persons on Members.PersonID=Persons.PersonID
			join BeltRanks on BeltTests.RankID=BeltRanks.RankID)R1
			where TestID=@TestID";

          SqlCommand Command = new SqlCommand(Query, Connection);
          Command.Parameters.AddWithValue("@TestID", TestID);


          try
          {
              Connection.Open();
              SqlDataReader Reader = Command.ExecuteReader();

              if (Reader.Read ())
              {
                  IsFound = true;
                  MemberName = (string)Reader["MemeberName"];
                  BeltName = (string)Reader["RankName"];
                  InstructorName = (string)Reader["TestedBy"];
                  Date = (DateTime)Reader["Date"];
                  Result = (bool)Reader["Result"];
                  PaymentID = (int)Reader["PaymentID"];
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


      public static bool UpdateBeltTest(int TestID, int MemberID, int RankID, int TestedByInstructorID, DateTime Date, bool Result, int PaymentID)
      {
          int RowsAffected = 0;
          SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

          string Query = @"UPDATE BeltTests set MemberID=@MemberID,
                              RankID=@RankID,
                              Result=@Result,
                              Date=@Date,
                             TestedByInstructorID=@TestedByInstructorID,
                             PaymentID=@PaymentID
                             where TestID=@TestID";

          SqlCommand Command = new SqlCommand(Query, Connection);
          Command.Parameters.AddWithValue("@MemberID", MemberID );
          Command.Parameters.AddWithValue("@RankID", RankID);
        
          Command.Parameters.AddWithValue("@Result", Result );
          Command.Parameters.AddWithValue("@Date", Date);
          Command.Parameters.AddWithValue("@TestedByInstructorID", TestedByInstructorID);
          Command.Parameters.AddWithValue("@PaymentID", PaymentID);
          Command.Parameters.AddWithValue("@TestID", TestID);


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




      public static bool IsBeltTestExsits(int TestID)
      {
          bool IsFound = false;
          SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

          string Query = @"Select Found=1 from BeltTests where TestID=@TestID";

          SqlCommand Command = new SqlCommand(Query, Connection);
          Command.Parameters.AddWithValue("@TestID", TestID);

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



      public static bool Delete(int TestID)
      {
          short RowsAffected = 0;
          SqlConnection Connection = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);

          string Query = @"delete from  [BeltTests] where TestID=@TestID";

          SqlCommand Command = new SqlCommand(Query, Connection);
          Command.Parameters.AddWithValue("@TestID", TestID);

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


      public static bool GetTestInfoByMemberID(ref int TestID, int MemberID, ref int PaymentID)
      {
          bool IsFound = false;
          SqlConnection Conncetion = new SqlConnection(clsKarateDataAccessSettings.ConnectionString);
          string Query = @"select TestID,PaymentID  from BeltTests where MemberID=@MemberID";
          SqlCommand Command = new SqlCommand(Query, Conncetion);
          Command.Parameters.AddWithValue("@MemberID", MemberID);
          try
          {
              Conncetion.Open();
              SqlDataReader Reader = Command.ExecuteReader();
              if (Reader.Read())
              {
                  IsFound = true;

                  TestID = (int)Reader["TestID"];
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
    }
}
