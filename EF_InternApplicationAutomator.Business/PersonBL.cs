using EF_InternApplicationAutomator.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_InternApplicationAutomator.Business
{


    public class PersonBL
    {
        public class PersonResponseDto
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
            public PersonResponseDto(int id, string firstName, string lastName, string email,
                    string phone, string address, string imagePath)
            {
                ID = id;
                FirstName = firstName;
                LastName = lastName;
                Email = email;
                this.phone = phone;
                Address = address;
                ImagePath = imagePath;
            }

        }

        //Add yaparken ID istememize Gerek yok. çünkü ID identical. Bu yüzden Aynı personDTO'sunu 
        //kullanamayız. Bu yüzden create'e özel DTO kullnırız
        //profesyonel API'lerde tek bir DTO değil, işleme göre (Create/Update/Response) birden
        //fazla DTO görmek çok yaygındır.
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


        public class PersonUpdateDTO
        {
            private int ID { get; set; }

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

        //ADO projelerimizde tüm fonksiyonları static tanımlayıp direk erişim yapardık
        //ama EF mimarisinde static tanımlayaöadığımız için objeler üzerinden erişim yapmalıyız.
        //new keyword'de kullanamayız. O zaman const ile objeyi oluşturarak erişim sağlayabiliriz
        PersonDataAccess _PersonDataAccess;

        //PersonBL ile DAL'ı bağlıyor.
        public PersonBL(PersonDataAccess personDataAccess)
        {
            _PersonDataAccess = personDataAccess;
        }
        
        
        public  List<PersonResponseDto> GetAllPeople()
        {

            List<PersonEntity> personEntities = _PersonDataAccess.GetAllPeople();

            List<PersonResponseDto> personDTOs = new List<PersonResponseDto>();

           

            //mapping
            foreach (var student in personEntities)
            {
                personDTOs.Add(new PersonResponseDto(student.PersonID, student.FirstName, student.LastName, student.Email, student.Phone, student.Address, student.ImagePath));
            }
            return personDTOs;

        }

        public PersonResponseDto Find(int PersonID)
        {
            PersonEntity personEntity = _PersonDataAccess.Find(PersonID);

            if(personEntity!=null)
            {
                return new PersonResponseDto(personEntity.PersonID,personEntity.FirstName,personEntity.LastName,personEntity.Email,personEntity.Phone,personEntity.Address,personEntity.ImagePath);
            }
            return null;
        }
        
        public int AddPerson(PersonCreateDTO personDTO)
        {
            PersonEntity personEntity = new PersonEntity(0,personDTO.FirstName, personDTO.LastName, personDTO.Email, personDTO.phone, personDTO.Address, personDTO.ImagePath);

            return _PersonDataAccess.AddPerson(personEntity);
        }

        public bool UpdatePerson(int personID,PersonCreateDTO personDTO)
        {
            PersonEntity personEntity = new PersonEntity(personID, personDTO.FirstName, personDTO.LastName, personDTO.Email, personDTO.phone, personDTO.Address, personDTO.ImagePath);
  
            return _PersonDataAccess.AddPerson(personEntity)!=1;
        }

    }
}
