
using AutoMapper;
using Domain.Models.DTO;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using DAL.Repositories;

namespace BLL.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private readonly IProjectRepository _projectRepository;
        public EmployeeServices(IEmployeeRepository employeeRepository, IMapper mapper, AppDbContext context)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _context = context;
        }

        // Получить информацию о сотруднике по его идентификатору
        public EmployeeDTO GetEmployeeById(int employeeId)
        {
            Employee employee = _employeeRepository.GetEmployeeById(employeeId);
            return _mapper.Map<EmployeeDTO>(employee);
        }

        // Получить список всех сотрудников
        public List<EmployeeDTO> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return _mapper.Map<List<EmployeeDTO>>(employees);
        }

        

        // Создать нового сотрудника
        public void CreateEmployee(EmployeeDTO employeeDTO)
        {
            try
            {
                Employee employee = _mapper.Map<Employee>(employeeDTO);
                _employeeRepository.CreateEmployee(employee);

                // Логирование успешного создания
                Console.WriteLine($"Employee created: {employee.EmployeeId}, {employee.FirstName}, {employee.LastName}");
            }
            catch (Exception ex)
            {
                // Логгирование ошибки
                Console.WriteLine($"Error creating employee: {ex.Message}");
                throw; // Возможно, стоит выбросить исключение дальше
            }
        }
    

        // Обновить информацию о существующем сотруднике
        public void UpdateEmployee(EmployeeDTO employeeDTO)
        {
            Employee employee = _mapper.Map<Employee>(employeeDTO);
            _employeeRepository.UpdateEmployee(employee);
        }

        // Удалить сотрудника по его идентификатору
        public void DeleteEmployee(int employeeId)
        {
            _employeeRepository.DeleteEmployee(employeeId);
        }
    }
}
