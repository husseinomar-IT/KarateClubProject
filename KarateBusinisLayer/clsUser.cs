using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using KarateDataAccessLayer;
namespace KarateBusinisLayer
{
    public class clsUser : clsPerson
    {



        public enum enUserPerimission
        {
            eAll = -1, eDashboard = 1, eMembers = 2,
            eInstructors = 4, eUsers =8 , eMembersInstructors = 16, eBeltRanks = 32, eSubScriptionPeriod = 64, eBeltTest = 128, ePayment = 256
        };


        // public     enUserPerimission PermissionUser = enUserPerimission.eAll;
        public enum enMode { Update = 0, AddNew = 1 };
        public enMode Mode = enMode.Update;
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Permission { get; set; }
//public int PersonID { get; set; }
        private DateTime _dt = DateTime.Now;





        public clsUser()
        {
            this.UserID = -1;
            this.UserName = string.Empty;
            this.Password = string.Empty;
            this.Permission = 0;
            Mode = enMode.AddNew;
        }


        public clsUser(string Username, int FKPersonID)
        {
            this.UserID = -1;
            this.UserName = Username;
            this.Password = String.Empty;
            this.Permission = -1;
            this.PersonID = FKPersonID;

            Mode = enMode.AddNew;
        }



        public clsUser(int UserID, string FirsName,string LastName, string Address, string Email, string Phone, string Username, string Password, int Permission, int personID)
            : base(personID, FirsName, LastName, Address, Email, Phone)
        {
            this.UserID = UserID;
            this.UserName = Username;
            this.Password = Password;
            this.Permission = Permission;
            Mode = enMode.Update;
        }






        public static clsUser Find(string Username)
        {
            int UserID = -1;
            int PersonID = -1;
            string FirstName = "",LastName="", Address = "", Email = "", Phone = "", Password = "";
            int Permission = -1;
           

            if (clsUserDataAccess.FindByUsername(Username, ref UserID, ref Password, ref Permission, ref  PersonID))
            {


                clsPerson Person = clsPerson.Find(PersonID, ref FirstName,ref LastName , ref Address, ref Email, ref Phone);
                if (Person != null)
                {
                    return new clsUser(UserID, FirstName,LastName, Address, Email, Phone, Username, Password, Permission, PersonID);
                }

                else
                {
                    return null;
                }
            }

            else
                return null;
        }

        public static clsUser Find(string Username, string Password)
        {
            int UserID = -1;
            int PersonID = -1;
            string FirstName = "",LastName="", Address = "", Email = "", Phone = "";
            int Permission = -1;
          

            if (clsUserDataAccess.FindByUsernameAndPassword(Username, ref UserID, Password, ref Permission, ref  PersonID))
            {


                clsPerson Person = clsPerson.Find(PersonID, ref FirstName,ref LastName, ref Address, ref Email, ref Phone);
                if (Person != null)
                {
                    return new clsUser(UserID, FirstName,LastName, Address, Email, Phone, Username, Password, Permission, PersonID);
                }

                else
                {
                    return null;
                }
            }

            else
                return null;
        }



        public static clsUser Find(int UserID)
        {
            string Username = "";
            int PersonID = -1;
            string FirstName = "", LastName = "", Address = "", Email = "", Phone = "", Password = "";
            int Permission = -1;


            if (clsUserDataAccess.FindByID(ref Username, UserID, ref Password, ref Permission, ref  PersonID))
            {


                clsPerson Person = clsPerson.Find(PersonID, ref FirstName, ref LastName, ref Address, ref Email, ref Phone);
                if (Person != null)
                {
                    return new clsUser(UserID, FirstName, LastName, Address, Email, Phone, Username, Password, Permission, PersonID);
                }

                else
                {
                    return null;
                }
            }

            else
                return null;
        }

        public static bool IsUserExsist(string Username)
        {
            return clsUserDataAccess.IsUserExsist(Username);

        }



        public static bool IsUserExsist(string Username,string password)
        {
            return clsUserDataAccess.IsUserExsist(Username, password);

        }








        public bool CheckAccessPerimission(int btnPermission)
        {
            if (this.Permission == -1)
            {
                return true;
            }

            if ((btnPermission & this.Permission) == btnPermission)


                return true;
            else

                return false;

        }


        private bool _UpdateUser()
        
              
        {
            if(clsPersonDataAccess.UpdatePerson(PersonID ,FirstName ,LastName ,Address ,Email ,Phone))
            {
                return clsUserDataAccess.UpdateUser(UserID, UserName, Password, Permission);
            }
            else
            {
                return false;
            }
                
        }






        private bool  _AddNewUser()
        {
            UserID = clsUserDataAccess.AddNewUser(PersonID, UserName, Password, Permission);
            return (UserID > -1);
        }

        public override bool Save()
        {
            switch (Mode)
            {
                case enMode.Update:
                    return _UpdateUser();

                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }


            }
            return false;

        }



        public   bool Delet()
        {
            return clsUserDataAccess.DeleteUser(UserName);
        }




        public static DataTable GetAllUsers()
        {
            return clsUserDataAccess.GetAllUsers();
        }

      
        







     
    }
}
