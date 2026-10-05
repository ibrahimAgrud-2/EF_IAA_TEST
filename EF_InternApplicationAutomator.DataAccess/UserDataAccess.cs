using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_InternApplicationAutomator.DataAccess
{
    public class UserDataAccess
    {
        private readonly IAADbContext _Context;
        public UserDataAccess(IAADbContext context)
        {
            _Context = context;
        }


    }
}
