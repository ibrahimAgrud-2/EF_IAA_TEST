using System.ComponentModel.DataAnnotations;

namespace Shared.Intern
{
    public class InternCreateDTO
    {
        [Required]
        public int PersonID { get; set; }

        [Required]
        [MaxLength(100)]
        public string PasswordHash { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public byte Status { get; set; }

        public InternCreateDTO(int personID, string passwordHash, DateTime startDate,
            DateTime? endDate, DateTime createdDate, byte status)
        {
            PersonID = personID;
            PasswordHash = passwordHash;
            StartDate = startDate;
            EndDate = endDate;
            CreatedDate = createdDate;
            Status = status;
        }
    }
}