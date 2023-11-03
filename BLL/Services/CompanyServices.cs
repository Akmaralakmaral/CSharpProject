

using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using Domain.Models.Entities;

namespace BLL.Services
{
    public class CompanyServices : ICompanyServices
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyServices(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        // Создание компании
        public void CreateCompany(Company company)
        {
            _companyRepository.CreateCompany(company);
        }

        // Получение компании по ID
        public Company GetCompanyById(int companyId)
        {
            return _companyRepository.GetCompanyById(companyId);
        }

        // Редактирование компании
        public void UpdateCompany(Company company)
        {
            _companyRepository.UpdateCompany(company);
        }

        // Удаление компании
        public void DeleteCompany(int companyId)
        {
            _companyRepository.DeleteCompany(companyId);
        }

        // Добавление проекта в компанию
        public void AddProjectToCompany(int companyId, Project project)
        {
            _companyRepository.AddProjectToCompany(companyId, project);
        }

        // Удаление проекта из компании
        public void RemoveProjectFromCompany(int companyId, int projectId)
        {
            _companyRepository.RemoveProjectFromCompany(companyId, projectId);
        }

        // Добавление сотрудника в компанию
        public void AddEmployeeToCompany(int companyId, Employee employee)
        {
            _companyRepository.AddEmployeeToCompany(companyId, employee);
        }

        // Удаление сотрудника из компании
        public void RemoveEmployeeFromCompany(int companyId, int employeeId)
        {
            _companyRepository.RemoveEmployeeFromCompany(companyId, employeeId);
        }

        // Фильтрация компаний по названию
        public List<Company> GetCompaniesByName(string companyName)
        {
            return _companyRepository.GetCompaniesByName(companyName);
        }

        // Сортировка компаний по названию (по возрастанию)
        public List<Company> GetCompaniesSortedByName()
        {
            return _companyRepository.GetCompaniesSortedByName();
        }
    }
}
   