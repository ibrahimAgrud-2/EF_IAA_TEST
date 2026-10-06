using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.User
{
    public class UserCreateDTO
    {

        [Required]
        public string UserName { get; set; }

        [Required]
        public int PersonID { get; set; }

        [Required]
        public int PermissionType { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public UserCreateDTO( int personID, string userName, string passwordHash, int permissionType, DateTime createdDate, bool isActive)
        {

            PersonID = personID;
            PermissionType = permissionType;
            CreatedDate = createdDate;
            IsActive = isActive;
            PasswordHash = passwordHash;
            UserName = userName;
        }


    }
}
