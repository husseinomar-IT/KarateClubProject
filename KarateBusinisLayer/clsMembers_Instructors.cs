using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarateDataAccessLayer;
using System.Data;
namespace KarateBusinisLayer
{
    public class clsMembers_Instructors 
    {
        public enum enMode { Update = 0, AddNew = 1 };
        public int AssignID { get; set; }
        public int MemberID { get; set; }
        public int InstructorID { get; set; }
        public DateTime dateTime { get; set; }
        public enMode Mode = enMode.Update;



       

        public clsMembers_Instructors()
        {

        }
        public clsMembers_Instructors(int MemberID, int InstructorID, DateTime DateTime)
        {
            this.AssignID = -1;
            this.MemberID = MemberID;
            this.InstructorID = InstructorID;
            this.dateTime = DateTime;
            Mode = enMode.AddNew;
        }




        public clsMembers_Instructors(int AssignID,int MemberID, int InstructorID, DateTime DateTime)
        {
            this.AssignID = AssignID;
            this.MemberID = MemberID;
            this.InstructorID = InstructorID;
            this.dateTime = DateTime;
            Mode = enMode.Update;
        }


     
        public static  bool FindByID(int AssignID,ref string MemberName,ref string InstructorName,ref DateTime datetime)
        {
            return clsMembers_InstructorsDataAccess.FindByID(AssignID, ref MemberName, ref InstructorName, ref datetime);
           
        
        }



        private bool _AddNewAssign()
        {
            AssignID = clsMembers_InstructorsDataAccess.AddNewAssign(MemberID, InstructorID, dateTime);
            return (AssignID > -1);
        }





        public static DataTable GetAllAssign()
        {
            return clsMembers_InstructorsDataAccess.GetAllAssign();
        }



        private bool _UpdateAssign()
        {
            return clsMembers_InstructorsDataAccess.UpdateAssign(AssignID, MemberID, InstructorID, dateTime);
        }
        public  bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewAssign())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {

                        return false;
                    }

                case enMode.Update :
                    return (_UpdateAssign());



            }
            return false;

           

        }

        public static bool IsAssignExsits(int AssginID)
        {
            return clsMembers_InstructorsDataAccess.IsAssignExsits(AssginID);
        }




        public static bool Delete(int AssingID)
        {
            return clsMembers_InstructorsDataAccess.Delete(AssingID);
        }




        public static bool GetAssignInfoByMemberID(ref int Member_Instructor_ID, int MemberID)
        {

            return clsMembers_InstructorsDataAccess.GetAssignInfoByMemberID(ref Member_Instructor_ID, MemberID);


        }
    }
}