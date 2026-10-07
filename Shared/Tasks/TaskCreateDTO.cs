using System.ComponentModel.DataAnnotations;

namespace Shared.Tasks
{
    public class TaskCreateDTO
    {
        public int? CreatedByUserID { get; set; }

        public int? OngoingProjectID { get; set; }

        [MaxLength(100)]
        public string? Title { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? DueDate { get; set; }

        public TaskCreateDTO(
            int? createdByUserID,
            int? ongoingProjectID,
            string? title,
            DateTime? createdAt,
            DateTime? dueDate)
        {
            CreatedByUserID = createdByUserID;
            OngoingProjectID = ongoingProjectID;
            Title = title;
            CreatedAt = createdAt;
            DueDate = dueDate;
        }
    }
}
