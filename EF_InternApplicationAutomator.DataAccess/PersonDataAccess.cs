using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_InternApplicationAutomator.DataAccess
{
    public  class PersonDataAccess
    {

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


        public int AddPerson(PersonEntity personEntity)
        {
            
            EntityEntry<PersonEntity> pw = _Context.People.Add(personEntity);

            if(_Context.SaveChanges()>0)
            {
                return personEntity.PersonID;
            }

             return -1;
        }


    }
}
