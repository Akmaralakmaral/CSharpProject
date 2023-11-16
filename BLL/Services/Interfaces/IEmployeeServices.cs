
using Domain.Models.DTO;

namespace BLL.Services.Interfaces
{
    public interface IEmployeeServices
    {
        // Получить информацию о сотруднике по его идентификатору
        EmployeeDTO GetEmployeeById(int employeeId);

        // Получить список всех сотрудников
        IEnumerable<EmployeeDTO> GetAllEmployees();

        // Создать нового сотрудника
        void CreateEmployee(EmployeeDTO employeeDTO);

        // Обновить информацию о существующем сотруднике
        void UpdateEmployee(EmployeeDTO employeeDTO);

        // Удалить сотрудника по его идентификатору
        void DeleteEmployee(int employeeId);
    }
}
