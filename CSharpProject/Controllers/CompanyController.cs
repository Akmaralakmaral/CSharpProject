using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CSharpProject.Controllers
{
    
    public class CompanyController : Controller
    {
        private readonly ICompanyServices _companyRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public CompanyController(ICompanyServices companyRepository, UserManager<IdentityUser> userManager)
        {
            _companyRepository = companyRepository;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
