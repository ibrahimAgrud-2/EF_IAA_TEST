using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shared;


namespace EF_InternApplicationAutomator.DataAccess
{
    public  class PersonDataAccess
    {

        /*
          public class PersonReceiveEntity
        {
            
            public int PersonID { get; set; }

          
            public string FirstName { get; set; }

           
            public string LastName { get; set; }

           
            public string Email { get; set; }

           
            public string Phone { get; set; }

           
            public string Address { get; set; }

           
            public string ImagePath { get; set; }

            
        }

        */

        ///Framework'un gerektirdiği kısımlar
        private  readonly IAADbContext _Context;
        public PersonDataAccess(IAADbContext context)
        {
            _Context = context;
        }




        public PersonResponseSDTO  Find(int PersonID)
        {
            PersonEntity personEntity = _Context.People.Find(PersonID);
            if (personEntity == null)
                return null;
            return new PersonResponseSDTO(personEntity.PersonID, personEntity.FirstName, personEntity.LastName, personEntity.Email, personEntity.Phone, personEntity.Address, personEntity.ImagePath);
        }


        public int Update(int ID, PersonCreateSDTO personCreateDTO)
        {

            var person = _Context.People.Find(ID);
            if(person == null&& personCreateDTO == null)
            {
                return -1;
            }
            person.FirstName = personCreateDTO.FirstName;
            person.LastName = personCreateDTO.LastName;
            person.Email = personCreateDTO.Email;
            person.Phone = personCreateDTO.Phone;
            person.Address = personCreateDTO.Address;
            person.ImagePath = personCreateDTO.ImagePath;
           


            if (_Context.SaveChanges()>0)
            {
                return ID;
            }

             return -1;
        }


    }
}
