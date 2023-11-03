
namespace Domain.Models.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int CustomerCompanyId { get; set; }
        public int ExecutorCompanyId { get; set; }
        public int ProjectManagerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }

        public Company CustomerCompany { get; set; }
        public Company ExecutorCompany { get; set; }
        public Employee ProjectManager { get; set; }
        public List<Employee> Employees { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
