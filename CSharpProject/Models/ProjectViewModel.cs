namespace CSharpProject.Models
{
    public class ProjectViewModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string CustomerCompanyName { get; set; }
        public string ExecutorCompanyName { get; set; }
        public string ProjectManagerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public List<string> EmployeeNames { get; set; }
        public List<int> TaskIds { get; set; }
    }
}
