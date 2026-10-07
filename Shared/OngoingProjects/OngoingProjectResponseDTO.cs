using System.ComponentModel.DataAnnotations;

namespace Shared.OngoingProjects
{
    public class OngoingProjectResponseDTO
    {
        [Required]
        public int OngoingProjectID { get; set; }

        [Required]
        public int InternID { get; set; }

        [Required]
        public int ProjectID { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public OngoingProjectResponseDTO(
            int ongoingProjectID,
            int internID,
            int projectID,
            DateTime startDate,
            DateTime dueDate)
        {
            OngoingProjectID = ongoingProjectID;
            InternID = internID;
            ProjectID = projectID;
            StartDate = startDate;
            DueDate = dueDate;
        }
    }
}
