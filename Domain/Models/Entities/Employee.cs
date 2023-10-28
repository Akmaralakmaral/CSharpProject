
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public List<Project> Projects { get; set; }
        public List<Task> AuthoredTasks { get; set; }
        public List<Task> AssignedTasks { get; set; }
    }

}
