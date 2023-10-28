using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CSharpProject.Controllers
{
    public class TaskController : Controller
    {
        private readonly IProjectServices _projectServices;

        public TaskController(IProjectServices projectServices)
        {
            _projectServices = projectServices;
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
