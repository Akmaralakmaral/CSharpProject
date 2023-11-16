
using DAL.Context;
using DAL.Repositories.Interfaces;
using Domain.Models.Entities;

namespace DAL.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        // Создание компании
        public void CreateCompany(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        // Просмотр компании по ID
        public Company GetCompanyById(int companyId)
        {
            return _context.Companies.FirstOrDefault(c => c.CompanyId == companyId);
        }

        // Редактирование компании
        public void UpdateCompany(Company company)
        {
            _context.Companies.Update(company);
            _context.SaveChanges();
        }

        // Удаление компании
        public void DeleteCompany(int companyId)
        {
            var company = GetCompanyById(companyId);
            if (company != null)
            {
                _context.Companies.Remove(company);
                _context.SaveChanges();
            }
        }

        // Добавление проекта в компанию
        public void AddProjectToCompany(int companyId, Project project)
        {
            var company = GetCompanyById(companyId);
            if (company != null)
            {
                company.Projects.Add(project);
                _context.SaveChanges();
            }
        }

        // Удаление проекта из компании
        public void RemoveProjectFromCompany(int companyId, int projectId)
        {
            var company = GetCompanyById(companyId);
            if (company != null)
            {
                var project = company.Projects.FirstOrDefault(p => p.ProjectId == projectId);
                if (project != null)
                {
                    company.Projects.Remove(project);
                    _context.SaveChanges();
                }
            }
        }

        // Добавление сотрудника в компанию
        public void AddEmployeeToCompany(int companyId, Employee employee)
        {
            var company = GetCompanyById(companyId);
            if (company != null)
            {
                company.Employees.Add(employee);
                _context.SaveChanges();
            }
        }

        // Удаление сотрудника из компании
        public void RemoveEmployeeFromCompany(int companyId, int employeeId)
        {
            var company = GetCompanyById(companyId);
            if (company != null)
            {
                var employee = company.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
                if (employee != null)
                {
                    company.Employees.Remove(employee);
                    _context.SaveChanges();
                }
            }
        }

        // Фильтрация компаний по названию
        public List<Company> GetCompaniesByName(string companyName)
        {
            return _context.Companies.Where(c => c.CompanyName.Contains(companyName)).ToList();
        }

        // Сортировка компаний по названию (по возрастанию)
        public List<Company> GetCompaniesSortedByName()
        {
            return _context.Companies.OrderBy(c => c.CompanyName).ToList();
        }

        // Получение всех компаний
        public IEnumerable<Company> GetAllCompanies()
        {
            return _context.Companies.ToList();
        }

    }
}
