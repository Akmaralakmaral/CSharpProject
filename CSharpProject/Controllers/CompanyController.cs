using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CSharpProject.Controllers
{
    
    public class CompanyController : Controller
    {
        private readonly ICompanyServices _companyRepository;

        public CompanyController(ICompanyServices companyRepository)
        {
            _companyRepository = companyRepository;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
