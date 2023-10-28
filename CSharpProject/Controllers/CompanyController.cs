using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CSharpProject.Controllers
{
    
    public class CompanyController : Controller
    {
        private readonly IProjectServices _projectServices;

        public CompanyController(IProjectServices projectServices)
        {
            _projectServices = projectServices;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
