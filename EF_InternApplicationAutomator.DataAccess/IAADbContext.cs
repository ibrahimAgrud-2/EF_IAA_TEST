using Microsoft.EntityFrameworkCore;
using System;

namespace EF_InternApplicationAutomator.DataAccess
{
    public  class IAADbContext:DbContext
    {
        //program.CS'de connection string'i bu const ile vereceğiz
        public  IAADbContext(DbContextOptions<IAADbContext> options) : base(options)
        {

        }


        public  DbSet<PersonEntity> People { get; set; }
        
        public DbSet<UserEntity> User { set; get; }
    }
}
