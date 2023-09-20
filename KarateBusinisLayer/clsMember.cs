using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarateDataAccessLayer;
using System.Data;
namespace KarateBusinisLayer
{
    public class clsMember:clsPerson
    {




        public enum enMode { Update = 0, AddNew = 1 };
        public int MemberID { get; set; }
        public string EmergencyContactInfo { get; set; }
        public char Gender { get; set; }
        public short LastBeltRank { get; set; }
        public bool IsActive { get; set; }
        public enMode Mode = enMode.Update;

        




        public  clsMember ()
        {

        }
        public clsMember(int PersonID)
        {
            this.MemberID = -1;
            this.EmergencyContactInfo = string.Empty;
            this.Gender = default(char);
            this.LastBeltRank=-1;
            this.IsActive = false;
            this.PersonID = PersonID;
            Mode = enMode.AddNew;
            
        }






        public clsMember(int MemberID, int PersonID, string EmergencyContactInfo, char gender, short lastBelt, bool IsActive, string FirstName, string LastName, string Phone, string Email, string Address)
            :base(PersonID,FirstName,LastName,Address,Email,Phone)
        {
            this.MemberID = MemberID;
            this.EmergencyContactInfo = EmergencyContactInfo;
            this.Gender = gender;
            this.LastBeltRank = lastBelt;
            this.IsActive = IsActive;
            Mode = enMode.Update;
        }



        public static clsMember Find(int MemberID)
        {
            
            int PersonID = -1;
            string EmergencyContactInfo = "";
            char gender=default(char);
            short lastBelt=-1;
            bool IsActive=false;

            string FirstName = "",LastName="", Address = "", Email = "", Phone = "";



            if (clsMemberDataAccess.Find(MemberID, ref PersonID, ref EmergencyContactInfo, ref gender,ref lastBelt, ref IsActive))
            {



                clsPerson Person = clsPerson.Find(PersonID, ref FirstName, ref LastName, ref Address, ref Email, ref Phone);
                if (Person != null)
                {
                    return new clsMember(MemberID, PersonID, EmergencyContactInfo, gender, lastBelt, IsActive, FirstName, LastName, Phone, Email, Address);
                }

                else
                {
                    return null;
                }
            }

            else
                return null;
        }



        //public static clsMember Find(string MemberID)
        //{

        //    int PersonID = -1;
        //    string EmergencyContactInfo = "";
        //    char gender = default(char);
        //    short lastBelt = -1;
        //    bool IsActive = false;

        //    string FirstName = "", LastName = "", Address = "", Email = "", Phone = "";



        //    if (clsMemberDataAccess.Find(MemberID, ref PersonID, ref EmergencyContactInfo, ref gender, ref lastBelt, ref IsActive))
        //    {



        //        clsPerson Person = clsPerson.Find(PersonID, ref FirstName, ref LastName, ref Address, ref Email, ref Phone);
        //        if (Person != null)
        //        {
        //            return new clsMember(MemberID, PersonID, EmergencyContactInfo, gender, lastBelt, IsActive, FirstName, LastName, Phone, Email, Address);
        //        }

        //        else
        //        {
        //            return null;
        //        }
        //    }

        //    else
        //        return null;
        //}

        //private bool _AddNewMember()
        //{
        //    this.MemberID = clsMemberDataAccess.AddNewMember(this.PersonID, this.EmergencyContactInfo, this.Gender, this.LastBeltRank, this.IsActive);
        //    return (this.MemberID > -1);
        //}

        private  bool _AddNewMember()
        {
            this.MemberID = clsMemberDataAccess.AddNewMember(this.PersonID, this.EmergencyContactInfo, this.Gender, this.LastBeltRank, this.IsActive);
            return (this.MemberID > -1);
        }





        private bool _UpdateMember()
        {
            if(clsPersonDataAccess.UpdatePerson(this.PersonID ,this.FirstName ,this.LastName ,this.Address ,this.Email ,this.Phone))
            {
             return clsMemberDataAccess.UpdateMember(this.MemberID, this.EmergencyContactInfo, this.Gender, this.LastBeltRank, this.IsActive);
            }
            else
            {
                return false;
            }
                
         
        }
        public bool Save()
        {
            switch(Mode)
            {


                case enMode.Update:
                    return (_UpdateMember());
                case enMode .AddNew:
                    if (_AddNewMember())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
            }
            return false;
        }




        public static DataTable GetAllMembers()
        {
            return clsMemberDataAccess.GetAllMembers();
        }



        public static bool IsMemberExsits(int MemberID)
        {
            return clsMemberDataAccess.IsMemberExsits(MemberID);
        }





        public static int  GetMemberIDByFullName(string FullName)

        {
           int MemberID =-1;

           if (clsMemberDataAccess.GetMemberIDByFullName(FullName, ref MemberID))
               return MemberID;
           else
               return -1;
          
        }
    





        private static  void _DeleteMemberActivites(int MemberID)
        {
            bool SubscriptionPeriodDeleted=false ;
            bool BeltTestDeleted=false ;
            bool Membetrs_Instructors_AssignID=false ;
            int PeriodID=-1,PeriodPaymentID=-1;
            int TestID=-1,TestPaymentID=-1;
            int Member_instructor_ID=-1;
           if(clsSubscriptionPeriod .GetPeriodInfoByMemberID(ref PeriodID,MemberID,ref PeriodPaymentID))
           {
             if(clsSubscriptionPeriod.Delete(PeriodID))
             {
                if(clsPayment.Delete(PeriodPaymentID))
                {
                    SubscriptionPeriodDeleted=true ;
                }
             }
           }



            if(clsMembers_Instructors.GetAssignInfoByMemberID (ref Member_instructor_ID,MemberID ))
            {
                if(clsMembers_Instructors .Delete (Member_instructor_ID))
                {
                    Membetrs_Instructors_AssignID=true ;
                }
            }

            if(clsBeltTest .GetBeltTestInfoByMemberID (ref TestID ,MemberID ,ref TestPaymentID ))
            {
                if(clsBeltTest.Delete(TestID))
                {
                    if(clsPayment .Delete(TestPaymentID))
                    {
                        BeltTestDeleted = true;
                    }
                }
            }


        


           

        }

        public static bool DeleteMember(int MemberID)
        {
            _DeleteMemberActivites(MemberID);
            return clsMemberDataAccess.Delete(MemberID);
            
        
        }





    }




  




}
