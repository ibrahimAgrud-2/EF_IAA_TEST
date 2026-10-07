using System.ComponentModel.DataAnnotations;

namespace Shared.Tasks
{
    public class TaskResponseDTO
    {
        [Required]
        public int TaskID { get; set; }

        public int? CreatedByUserID { get; set; }

        public int? OngoingProjectID { get; set; }

        [MaxLength(100)]
        public string? Title { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? DueDate { get; set; }

        public TaskResponseDTO(
            int taskID,
            int? createdByUserID,
            int? ongoingProjectID,
            string? title,
            DateTime? createdAt,
            DateTime? dueDate)
        {
            TaskID = taskID;
            CreatedByUserID = createdByUserID;
            OngoingProjectID = ongoingProjectID;
            Title = title;
            CreatedAt = createdAt;
            DueDate = dueDate;
        }
    }
}
