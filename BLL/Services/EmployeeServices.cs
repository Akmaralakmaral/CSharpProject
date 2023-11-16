
using AutoMapper;
using Domain.Models.DTO;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using Domain.Models.Entities;

namespace BLL.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeServices(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Получить информацию о сотруднике по его идентификатору
        public EmployeeDTO GetEmployeeById(int employeeId)
        {
            Employee employee = _repository.GetEmployeeById(employeeId);
            return _mapper.Map<EmployeeDTO>(employee);
        }

        // Получить список всех сотрудников
        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            IEnumerable<Employee> employees = _repository.GetAllEmployees();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
        }

        // Создать нового сотрудника
        public void CreateEmployee(EmployeeDTO employeeDTO)
        {
            Employee employee = _mapper.Map<Employee>(employeeDTO);
            _repository.CreateEmployee(employee);
        }

        // Обновить информацию о существующем сотруднике
        public void UpdateEmployee(EmployeeDTO employeeDTO)
        {
            Employee employee = _mapper.Map<Employee>(employeeDTO);
            _repository.UpdateEmployee(employee);
        }

        // Удалить сотрудника по его идентификатору
        public void DeleteEmployee(int employeeId)
        {
            _repository.DeleteEmployee(employeeId);
        }
    }
}
