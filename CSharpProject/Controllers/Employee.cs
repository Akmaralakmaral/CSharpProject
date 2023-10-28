using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CSharpProject.Controllers
{
    public class Employee : Controller
    {
        private readonly IProjectServices _projectServices;

        public Employee(IProjectServices projectServices)
        {
            _projectServices = projectServices;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
