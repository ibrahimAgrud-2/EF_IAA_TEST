using EF_InternApplicationAutomator.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF_InternApplicationAutomator.Business
{

    public class PersonBL
    {
        PersonDataAccess _PersonDataAccess;

        //PersonBL ile DAL'ı bağlıyor.
        public PersonBL(PersonDataAccess personDataAccess)
        {
            _PersonDataAccess = personDataAccess;
        }


        public class PersonCreateDTO
        {
           

            [Required]
            public string FirstName { get; set; }

            [Required]
            public string LastName { get; set; }

            [Required]
            public string Email { get; set; }

            [Required]
            public string phone { get; set; }

            [Required]
            public string Address { get; set; }

            public string ImagePath { get; set; }
            public PersonCreateDTO(string firstName, string lastName, string email,
                    string phone, string address, string imagePath)
            {
              
                FirstName = firstName;
                LastName = lastName;
                Email = email;
                this.phone = phone;
                Address = address;
                ImagePath = imagePath;
            }

        }


        public PersonEntity Find(int PersonID)
        {
            PersonEntity personEntity = _PersonDataAccess.Find(PersonID);

            if (personEntity != null)
            {
                return new PersonEntity(personEntity.PersonID, personEntity.FirstName, personEntity.LastName, personEntity.Email, personEntity.Phone, personEntity.Address, personEntity.ImagePath);
            }
            return null;
        }



        //sorun bu olabilir
        public int AddPerson(PersonEntity personEntity)
        {
            return _PersonDataAccess.AddPerson(personEntity);
        }

        public bool UpdatePerson(int personID, PersonEntity PersonEntity)
        {
            return _PersonDataAccess.AddPerson(PersonEntity) !=1;
        }

    }
}
