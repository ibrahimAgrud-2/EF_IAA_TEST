using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_InternApplicationAutomator.DataAccess.Tasks
{
    [Table("Tasks")]
    public class TaskEntity
    {
        [Key]
        public int TaskID { get; set; }

        public int? CreatedByUserID { get; set; }

        public int? OngoingProjectID { get; set; }

        [MaxLength(100)]
        public string? Title { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? DueDate { get; set; }

        public TaskEntity(
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
