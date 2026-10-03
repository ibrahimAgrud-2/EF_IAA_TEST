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
        public class PersonResponseDTO
        {
            public int ID { get; set; }

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
            public PersonResponseDTO(int ID,string firstName, string lastName, string email,
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


        public PersonResponseDTO Find(int PersonID)
        {
            PersonEntity personEntity = _PersonDataAccess.Find(PersonID);

            if (personEntity != null)
            {
                return new PersonResponseDTO(personEntity.PersonID, personEntity.FirstName, personEntity.LastName, personEntity.Email, personEntity.Phone, personEntity.Address, personEntity.ImagePath);
            }
            return null;
        }


        public bool UpdatePerson(int personID, PersonCreateDTO personCreateDTO)
        {
            PersonDataAccess.PersonEntity2 pe = new PersonDataAccess.PersonEntity2();
            pe.FirstName = personCreateDTO.FirstName;
            pe.LastName = personCreateDTO.LastName;
            pe.Email = personCreateDTO.Email;
            pe.Phone = personCreateDTO.phone;
            pe.Address = personCreateDTO.Address;
            pe.ImagePath = personCreateDTO.ImagePath;



            return _PersonDataAccess.Update(personID, pe) !=-1;
        }

    }
}
