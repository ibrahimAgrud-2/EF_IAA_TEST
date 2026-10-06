using System.ComponentModel.DataAnnotations;

namespace Shared.Intern
{
    public class InternResponseDTO
    {
        [Required]
        public int InternID { get; set; }

        [Required]
        public int PersonID { get; set; }



        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public byte Status { get; set; }

        public InternResponseDTO(int internID, int personID,
            DateTime startDate, DateTime? endDate, DateTime createdDate, byte status)
        {
            InternID = internID;
            PersonID = personID;
            StartDate = startDate;
            EndDate = endDate;
            CreatedDate = createdDate;
            Status = status;
        }
    }
}