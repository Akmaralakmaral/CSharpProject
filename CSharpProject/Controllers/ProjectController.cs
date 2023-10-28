using Microsoft.AspNetCore.Mvc;

namespace CSharpProject.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
