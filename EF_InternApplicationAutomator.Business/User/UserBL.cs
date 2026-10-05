using EF_InternApplicationAutomator.DataAccess;
using EF_InternApplicationAutomator.DataAccess.User;
using Shared;
using Shared.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_InternApplicationAutomator.Business.User
{
    public  class UserBL
    {
        UserDataAccess _userDataAccess;

      
        public UserBL(UserDataAccess personDataAccess)
        {
            _userDataAccess = personDataAccess;
        }

        public List<UserResponseDTO> GetAllUser()
        {
            return _userDataAccess.GetAllUser();
        }
    }
}
