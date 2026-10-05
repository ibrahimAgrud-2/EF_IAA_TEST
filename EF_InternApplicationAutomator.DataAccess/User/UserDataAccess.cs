using Shared;
using Shared.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_InternApplicationAutomator.DataAccess.User
{
    public class UserDataAccess
    {

        private readonly IAADbContext _Context;
        public UserDataAccess(IAADbContext context)
        {
            _Context = context;
        }


        public List<UserResponseDTO> GetAllUser()
        {
            List<UserEntity> userList = _Context.Users.ToList();

            List<UserResponseDTO> userDTOs = new List<UserResponseDTO>();



            //mapping
            foreach (var user in userList)
            {
                userDTOs.Add(new UserResponseDTO(user.UserID,user.PersonID,user.UserName,user.PasswordHash,user.PermissionType,user.CreatedDate,user.IsActive));
            }
            return userDTOs;
        }

    }
}
