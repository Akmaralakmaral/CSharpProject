
namespace Domain.Models.DTO
{
    public class CompanyDTO
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public List<int> ProjectIds { get; set; }
        public List<int> EmployeeIds { get; set; }
    }
}
