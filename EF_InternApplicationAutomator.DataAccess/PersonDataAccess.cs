using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_InternApplicationAutomator.DataAccess
{
    public  class PersonDataAccess
    {


          public class PersonEntity2
        {
            
            public int PersonID { get; set; }

          
            public string FirstName { get; set; }

           
            public string LastName { get; set; }

           
            public string Email { get; set; }

           
            public string Phone { get; set; }

           
            public string Address { get; set; }

           
            public string ImagePath { get; set; }

            
        }



        ///Framework'un gerektirdiği kısımlar
        private  readonly IAADbContext _Context;
        public PersonDataAccess(IAADbContext context)
        {
            _Context = context;
        }




        public PersonEntity Find(int PersonID)
        {
            return _Context.People.Find(PersonID);
        }


        public int Update(int ID, PersonEntity2 pe)
        {

            var pw = _Context.People.Find(ID);
            if(pw==null&&pe==null)
            {
                return -1;
            }

            pw.FirstName = pe.FirstName;
            pw.LastName = pe.LastName;
            pw.Address = pe.Address;


            if(_Context.SaveChanges()>0)
            {
                return ID;
            }

             return -1;
        }


    }
}
