using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarateDataAccessLayer;
namespace KarateBusinisLayer
{
    public class clsPerson
    {




        public enum enMode { Update = 0, AddNew = 1 };

        public enMode Mode = enMode.Update;
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }




        public clsPerson()
        {
            this.PersonID = -1;
            this.FirstName  = string.Empty;
            this.LastName = string.Empty;
            this.Address = string.Empty;
            this.Email = string.Empty;
            this.Phone = string.Empty;



            Mode = enMode.AddNew;

        }



        public clsPerson(string FirstName, string LastName, string Address, string Email,string Phone)
        {
            this.PersonID = -1;
            this.FirstName = FirstName      ;
            this.LastName = LastName        ;
            this.Address = Address          ;
            this.Email =Email               ;
            this.Phone = Phone;



            Mode = enMode.AddNew;

        }
        public clsPerson(int PersonID, string FirstName,string LastName, string Address, string Email, string Phone)
        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
            this.Email = Email;
            this.Phone = Phone;



            Mode = enMode.Update;

        }



        public static clsPerson Find(int PersonID, ref string FirstName,ref string LastName, ref string Address, ref string Email, ref string Phone)
        {
            if (clsPersonDataAccess.Find(PersonID, ref FirstName,ref LastName, ref Address, ref Email, ref Phone))
                return new clsPerson(PersonID, FirstName,LastName, Address, Email, Phone);
            else
                return null;
        }



        //public string FullName()
        //{
        //    return (this.FirstName + " " + this.LastName);
        //}


        //private bool _UpdatePerson()
        //{
        //    return clsPersonDataAccess.UpdatePerson(this.PersonID, this.FirstName, this.LastName, this.Email, this.Phone);
        //}


        private bool _AddNewPerson()
        {
           PersonID = clsPersonDataAccess.AddNewPerson(FirstName,LastName ,  Address,  Email,    Phone);
            return (PersonID != -1);
        }




     

        public virtual bool Save()
        {
            switch (Mode)
            {
                //case enMode.Update:
                //    return _UpdateUser();

                case enMode.AddNew:
                    if (_AddNewPerson())
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





    }
}
