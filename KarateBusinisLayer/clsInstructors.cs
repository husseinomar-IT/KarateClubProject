using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarateDataAccessLayer;
using System.Data;

namespace KarateBusinisLayer
{
   public  class clsInstructors:clsPerson
    {
       public int InstructorID { get; set; }
    

       public string Quelification { get; set; }




       public clsInstructors ()
       {

       }



       public clsInstructors (int PersonID)
       {

           this.InstructorID  =-1;
           this.PersonID = PersonID;
           this.Quelification = string.Empty;
           Mode = enMode.AddNew;
           
       }
       public clsInstructors (int PersonID,string FirstName,string LastName,string Address,string Email,string Phone,int InstructorID,string Quelification)
           :base(PersonID,FirstName,LastName ,Address ,Email,Phone )
       {
           this.InstructorID = InstructorID;
           this.Quelification = Quelification;
           Mode = enMode.Update;
       }





       public static clsInstructors Find(int InstructorID)
       {

           int PersonID = -1;
           string Quelification = "";
         
           string FirstName = "", LastName = "", Address = "", Email = "", Phone = "";

      

           if (clsInstructorDataAccess.Find(InstructorID, ref PersonID, ref Quelification))
           {



               clsPerson Person = clsPerson.Find(PersonID, ref FirstName, ref LastName, ref Address, ref Email, ref Phone);
               if (Person != null)
               {
                   return new clsInstructors(PersonID, FirstName, LastName, Address, Email, Phone, InstructorID, Quelification);
               }

               else
               {
                   return null;
               }
           }

           else
               return null;
       }



       public static DataTable GetAllInstructors()
       {
           return clsInstructorDataAccess.GetAllInstructors();
       }






       private bool _AddNewInstructor()
       {
           this.InstructorID = clsInstructorDataAccess.AddNewInstructor(this.PersonID, this.Quelification);
           return (this.InstructorID > -1);
       }




       public static bool IsInstructorExsits(int InstructorID)
       {
           return clsMemberDataAccess.IsMemberExsits(InstructorID);
       }






       private bool _UpdateInstructor()
       {
           if (clsPersonDataAccess.UpdatePerson(this.PersonID, this.FirstName, this.LastName, this.Address, this.Email, this.Phone))
           {
               return clsInstructorDataAccess.UpdateInstructor(this.InstructorID , this.Quelification);
           }
           else
           {
               return false;
           }


       }





       public static bool DeleteInstructor(int InstructorID)
       {
           return clsInstructorDataAccess.Delete(InstructorID);
       }






           public static int GetInstructorIDByFullName(string FullName)
       {
           int InstructorID = -1;
           if (clsInstructorDataAccess .GetInstuctorIDByFullName (FullName, ref InstructorID))
           {
               return InstructorID;
           }
           return -1;
       }

       public bool Save()
       {
           switch (Mode)
           {


               case enMode.Update:
                   return (_UpdateInstructor());
               case enMode.AddNew:
                   if (_AddNewInstructor())
                   {
                       Mode = enMode.Update;
                       return true;
                   }
                   else
                       return false;
           }
           return false;
       }

    }
}
