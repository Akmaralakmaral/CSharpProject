
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Domain.Models.ViewModels
{
    public class ProjectViewModel
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int CustomerCompanyId { get; set; } // Добавлено
        public int ExecutorCompanyId { get; set; } // Добавлено
        public int ProjectManagerId { get; set; }  // Добавлено
        public string CustomerCompanyName { get; set; }
        public string ExecutorCompanyName { get; set; }
        public string ProjectManagerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public List<string> EmployeeNames { get; set; }
        public List<int> TaskIds { get; set; }

        // Добавленные свойства
        public List<SelectListItem> CompanyList { get; set; }
        public List<SelectListItem> EmployeeList { get; set; }
    }
}
