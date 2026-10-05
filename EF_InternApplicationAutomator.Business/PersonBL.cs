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



        public int PersonID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " "  + LastName; }

        }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        public string ImagePath { get; set; }

        public PersonBL(int personID,string firstName, string lastName, string email,
                string phone, string address, string imagePath)
        {

            FirstName = firstName;
            LastName = lastName;
            Email = email;
            this.Phone = phone;
            Address = address;
            ImagePath = imagePath;
            PersonID = personID;
            this.Mode = enMode.Update;
        }
        public PersonBL()
        {

            FirstName = "";
            LastName = "";
            Email = "";
            this.Phone = "";
            Address = "";
            ImagePath = "";
            PersonID =-1;
            this.Mode = enMode.AddNew;

        }
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public PersonResponseSDTO createSDTO { get { return new PersonResponseSDTO(this.PersonID, this.FirstName, this.LastName, this.Email, this.Phone, this.Address, this.ImagePath); } }


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

        public PersonBL Find(int PersonID)
        {
            PersonResponseSDTO pcd = _PersonDataAccess.Find(PersonID);
            if (pcd!=null)
            {
                return new PersonBL(pcd.PersonID, pcd.FirstName, pcd.LastName, pcd.Email, pcd.Phone, pcd.Address, pcd.ImagePath);
            }
            return null;
        }

        public bool UpdatePerson(int personID, PersonCreateSDTO personCreateDTO)
        {

            return _PersonDataAccess.Update(personID, personCreateDTO) !=-1;
        }

    }
}
