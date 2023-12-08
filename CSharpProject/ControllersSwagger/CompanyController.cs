using BLL.Services;
using BLL.Services.Interfaces;
using Domain.Models.DTO;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharpProject.ControllersSwagger
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyServices _companyServices;

        public CompanyController(ICompanyServices companyServices)
        {
            _companyServices = companyServices;
        }

        [HttpGet]
        public List<CompanyDTO> GetAllEmployees()
        {
            var companies = _companyServices.GetAllCompanies();
            return companies;
        }

        [HttpPost]
        public IActionResult CreateCompany(CompanyDTO companyDTO)
        {
            _companyServices.CreateCompany(companyDTO);
            return Ok("Company created successfully");
        }

        [HttpDelete("{companyId}")]
        public IActionResult DeleteCompany(int companyId)
        {
            _companyServices.DeleteCompany(companyId);
            return Ok($"Employee with ID {companyId} deleted successfully");
        }

        [HttpPut]
        public IActionResult UpdateCompany([FromBody] CompanyDTO CompanyDTO)
        {
            _companyServices.UpdateCompany(CompanyDTO);
            return Ok($"Company with ID {CompanyDTO.CompanyId} updated successfully");
        }


    }
}
