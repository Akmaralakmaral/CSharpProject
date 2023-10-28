using Domain.Enum;
using TaskStatus = Domain.Enum.TaskStatus;

namespace Domain.Models.Entities
{
    public class Task
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int AuthorId { get; set; }
        public int AssigneeId { get; set; }
        public TaskStatus Status { get; set; } // Используем enum
        public string Comment { get; set; }
        public int Priority { get; set; }
        public int ProjectId { get; set; }

        public Employee Author { get; set; }
        public Employee Assignee { get; set; }
        public Project Project { get; set; }
        
    }
}
