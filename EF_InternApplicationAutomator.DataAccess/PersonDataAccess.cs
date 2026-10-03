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

        //BL'nin DAL'a bağlanmasını const ile yapıyoruz. Aslında fonksiyonları static tanımlayamadığımız için
        //Mecbur obje üzerinde erişmemiz gerekiyor. Bu yüzden bir şekilde obje oluşturmalı sonra erişim sağlamalıyız.
        //Ayrıca BL'de personDataAccess pd = new PersonDataAccess()'de diyemiyoruz çünkü IAADbContext objesi olduğu için 
        //sınıfın içinde EF buna izin vermiyor. Arka planda new işlemini EF kontrol ediyor o hallediyor
        public PersonDataAccess(IAADbContext context)
        {
            _Context = context;
        }

        //CRUD buradan itibaren başlıyor
        public   List<PersonEntity> GetAllPeople()
        {
            return  _Context.People.ToList();
        }

        public PersonEntity Find(int PersonID)
        {
            //Find çağırıldığında personEntity sınıfındaki key attribute'tuna sahip olan property'i 
            //primary key olarak kabul ediyor ve bu o property'e personID değerini atıyor.
            //EF reflection ile bu eşleştirmeyi yapıyor.
            return _Context.People.Find(PersonID);
        }

        //EF'de her bir işlem için hazır fonksiyon yoktur. Bazı durumlarda kendi istediğin şekilde 
        //fonksiyon olması için belli modifiyeler yapman gerekir
        public int AddPerson(PersonEntity personEntity)
        {
            /*personID identity olduğu için değeri 0 olarark verilmeli. Çünkü
            //EF, eğer ID değeri sıfırsa yani defaul değerde eşitse, o değerin 
            //DB tarafından verileceğini biliyor. Bu yüzden PersonID 0 olmlı.
            //personEntity.PersonID = 0;
            //defaul değer zaten sıfır olduğu için tekrar = 0 dememize gerek yok*/
            EntityEntry<PersonEntity> pw = _Context.People.Add(personEntity);

            if(_Context.SaveChanges()>0)
            {
                return personEntity.PersonID;
            }

             return -1;
        }
        //public bool UpdatePerson(PersonEntity personEntity)
        //{
        //    EntityEntry<PersonEntity> pw = _Context.People.Update(personEntity);

            
        //    Console.WriteLine($"\n****************{_Context.SaveChanges()}*********\n");
            

        //    return true;
        //}
    }
}
