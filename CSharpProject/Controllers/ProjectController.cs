using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CSharpProject.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectServices _projectServices;

        public ProjectController(IProjectServices projectServices)
        {
            _projectServices = projectServices;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
