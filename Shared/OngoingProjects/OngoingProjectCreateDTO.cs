using System.ComponentModel.DataAnnotations;

namespace Shared.OngoingProjects
{
    public class OngoingProjectCreateDTO
    {
        [Required]
        public int InternID { get; set; }

        [Required]
        public int ProjectID { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public OngoingProjectCreateDTO(int internID, int projectID, DateTime startDate, DateTime dueDate)
        {
            InternID = internID;
            ProjectID = projectID;
            StartDate = startDate;
            DueDate = dueDate;
        }
    }
}
