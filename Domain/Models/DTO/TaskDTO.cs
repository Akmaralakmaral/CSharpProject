
namespace Domain.Models.DTO
{
    public class TaskDTO
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int AuthorId { get; set; }
        public int AssigneeId { get; set; }
        public TaskStatus Status { get; set; }
        public string Comment { get; set; }
        public int Priority { get; set; }
        public int ProjectId { get; set; }
    }
}
