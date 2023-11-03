
using Domain.Models.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        // Создание компании
        void CreateCompany(Company company);

        // Получение компании по ID
        Company GetCompanyById(int companyId);

        // Редактирование компании
        void UpdateCompany(Company company);

        // Удаление компании
        void DeleteCompany(int companyId);

        // Добавление проекта в компанию
        void AddProjectToCompany(int companyId, Project project);

        // Удаление проекта из компании
        void RemoveProjectFromCompany(int companyId, int projectId);

        // Добавление сотрудника в компанию
        void AddEmployeeToCompany(int companyId, Employee employee);

        // Удаление сотрудника из компании
        void RemoveEmployeeFromCompany(int companyId, int employeeId);

        // Фильтрация компаний по названию
        List<Company> GetCompaniesByName(string companyName);

        // Сортировка компаний по названию (по возрастанию)
        List<Company> GetCompaniesSortedByName();
    }
}
