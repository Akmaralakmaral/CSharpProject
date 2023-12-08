using BLL.Services.Interfaces;
using Domain.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharpProject.ControllersSwagger
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _employeeServices;

        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeServices = employeeServices;
        }

        [HttpGet]
        public List<EmployeeDTO> GetAllEmployees() 
        {
            var employees = _employeeServices.GetAllEmployees();
            return employees;
        }
    }
}
