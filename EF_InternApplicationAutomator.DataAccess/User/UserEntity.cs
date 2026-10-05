using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_InternApplicationAutomator.DataAccess.User
{
    [Table("Users")]
    public class UserEntity
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(20)]
        public int PersonID { get; set; }


        [Required]
        [MaxLength(20)]
        public string PermissionType { get; set; }


        [Required]
        [MaxLength(20)]
        public string PasswordHash { get; set; }


        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public UserEntity(int UserID, int personID, string userName, string passwordHash, string permissionType, DateTime createdDate, bool isActive)
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
