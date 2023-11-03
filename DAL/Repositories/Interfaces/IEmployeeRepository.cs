
using Domain.Models.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        // Получить сотрудника по идентификатору
        Employee GetEmployeeById(int employeeId);

        // Получить всех сотрудников
        IEnumerable<Employee> GetAllEmployees();

        // Создать нового сотрудника
        void CreateEmployee(Employee employee);

        // Обновить информацию о сотруднике
        void UpdateEmployee(Employee employee);

        // Удалить сотрудника по идентификатору
        void DeleteEmployee(int employeeId);
    }
}
