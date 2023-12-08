
using DAL.Context;
using DAL.Repositories.Interfaces;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        // Метод для получения сотрудника по идентификатору
        public Employee GetEmployeeById(int employeeId)
        {
            return _context.Employees
                .Include(e => e.Projects)
                .Include(e => e.AuthoredTasks)
                .Include(e => e.AssignedTasks)
                .FirstOrDefault(e => e.EmployeeId == employeeId);
        }

        // Метод для получения всех сотрудников
        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.ToList();
        }

        

        // Метод для создания нового сотрудника
        public void CreateEmployee(Employee employee)
        {
           
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // Логгирование ошибки
                Console.WriteLine($"Error creating employee: {ex.Message}");
                throw; // Возможно, стоит выбросить исключение дальше
            }
        }

        // Метод для обновления информации о существующем сотруднике
        public void UpdateEmployee(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // Метод для удаления сотрудника по идентификатору
        public void DeleteEmployee(int employeeId)
        {
            var employee = _context.Employees.Find(employeeId);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }

    }
}
