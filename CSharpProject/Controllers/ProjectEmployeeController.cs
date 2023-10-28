using Microsoft.AspNetCore.Mvc;

namespace CSharpProject.Controllers
{
    public class ProjectEmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
