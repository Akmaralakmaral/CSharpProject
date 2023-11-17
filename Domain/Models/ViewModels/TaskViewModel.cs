namespace Domain.Models.ViewModels
{
    public class TaskViewModel
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public EmployeeViewModel Author { get; set; }
        public EmployeeViewModel Assignee { get; set; }
        public TaskStatus Status { get; set; }
        public string Comment { get; set; }
        public int Priority { get; set; }
        public ProjectViewModel Project { get; set; }
    }
}
