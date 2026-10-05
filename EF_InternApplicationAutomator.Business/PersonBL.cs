using EF_InternApplicationAutomator.DataAccess;
using Shared;
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

        //DTOS
        /*
        public class PersonCreateDTO
        {
           

            [Required]
            public string FirstName { get; set; }

            [Required]
            public string LastName { get; set; }

            [Required]
            public string Email { get; set; }

            [Required]
            public string Phone { get; set; }

            [Required]
            public string Address { get; set; }

            public string ImagePath { get; set; }
            public PersonCreateDTO(string firstName, string lastName, string email,
                    string Phone, string address, string imagePath)
            {
              
                FirstName = firstName;
                LastName = lastName;
                Email = email;
                this.Phone = Phone;
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
            public string Phone { get; set; }

            [Required]
            public string Address { get; set; }

            public string ImagePath { get; set; }
            public PersonResponseDTO(int ID,string firstName, string lastName, string email,
                    string Phone, string address, string imagePath)
            {

                FirstName = firstName;
                LastName = lastName;
                Email = email;
                this.Phone = Phone;
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

        */

        public PersonResponseSDTO Find(int PersonID)
        {
            return _PersonDataAccess.Find(PersonID);
        }

        public bool UpdatePerson(int personID, PersonCreateSDTO personCreateDTO)
        {
            //PersonResponseSDTO person = Find(personID);
            //person.FirstName = personCreateDTO.FirstName;
            //person.LastName = personCreateDTO.LastName;
            //person.Email = personCreateDTO.Email;
            //person.Phone = personCreateDTO.Phone;
            //person.Address = personCreateDTO.Address;
            //person.ImagePath = personCreateDTO.ImagePath;


            //check if Exists 



            return _PersonDataAccess.Update(personID, personCreateDTO) !=-1;
        }

    }
}
