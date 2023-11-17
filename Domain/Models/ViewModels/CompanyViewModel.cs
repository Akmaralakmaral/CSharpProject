namespace Domain.Models.ViewModels
{
    public class CompanyViewModel
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public List<ProjectViewModel> Projects { get; set; }
        public List<EmployeeViewModel> Employees { get; set; }
    }
}
