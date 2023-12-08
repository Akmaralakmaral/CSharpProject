using BLL.Services;
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

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            _employeeServices.CreateEmployee(employeeDTO);
            return Ok("Employee created successfully");
        }

        [HttpDelete("{employeeId}")]
        public IActionResult DeleteEmployee(int employeeId)
        {
            _employeeServices.DeleteEmployee(employeeId);
            return Ok($"Employee with ID {employeeId} deleted successfully");
        }

        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] EmployeeDTO updatedEmployeeDTO)
        {
            _employeeServices.UpdateEmployee(updatedEmployeeDTO);
            return Ok($"Employee with ID {updatedEmployeeDTO.EmployeeId} updated successfully");
        }

    }
}
