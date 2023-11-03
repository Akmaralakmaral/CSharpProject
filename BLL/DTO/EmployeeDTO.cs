using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public List<int> ProjectIds { get; set; }
        public List<int> AuthoredTaskIds { get; set; }
        public List<int> AssignedTaskIds { get; set; }
    }
}
