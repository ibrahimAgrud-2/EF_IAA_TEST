using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.User
{
    public class UserResponseDTO
    {

        [Required]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        public int PersonID { get; set; }

        [Required]
        public string PermissionType { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public UserResponseDTO(int UserID, int personID, string userName, string passwordHash, string permissionType, DateTime createdDate, bool isActive)
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
