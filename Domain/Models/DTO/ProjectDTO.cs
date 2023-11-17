namespace Domain.Models.DTO
{
    public class ProjectDTO
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int CustomerCompanyId { get; set; }
        public int ExecutorCompanyId { get; set; }
        public int ProjectManagerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public List<int> EmployeeIds { get; set; }
        public List<int> TaskIds { get; set; }
    }
}
