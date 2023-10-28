using Microsoft.AspNetCore.Mvc;

namespace CSharpProject.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
