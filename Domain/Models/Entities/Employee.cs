
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "The FirstName field is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The LastName field is required.")]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field must be a valid email address.")]
        public string Email { get; set; }
        public List<Project> Projects { get; set; }
        public List<Task> AuthoredTasks { get; set; }
        public List<Task> AssignedTasks { get; set; }

        public int CompanyId { get; set; }
    }

}
