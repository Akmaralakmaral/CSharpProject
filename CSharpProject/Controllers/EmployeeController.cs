using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CSharpProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IProjectServices _projectServices;

        public EmployeeController(IProjectServices projectServices)
        {
            _projectServices = projectServices;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
