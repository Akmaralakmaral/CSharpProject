
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public List<Project> Projects { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
