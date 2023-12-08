namespace Domain.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string EmployeeName { get; set; }
        public List<ProjectViewModel> Projects { get; set; }
        public List<TaskViewModel> AuthoredTasks { get; set; }
        public List<TaskViewModel> AssignedTasks { get; set; }
    }
}
