
using DAL.Context;
using DAL.Repositories.Interfaces;
using Domain.Models.Entities;
namespace DAL.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddProject(Project project)
        {
            _context.Projects.Add(project);
            //project.CustomerCompany = _context.Companies.FirstOrDefault(x => x.CompanyId == 1);
            //project.ExecutorCompany = _context.Companies.FirstOrDefault(x => x.CompanyId == 2);
            //project.ProjectManager = _context.Employees.FirstOrDefault(x => x.EmployeeId == 1);
            _context.SaveChanges();
        }

        public Project GetProjectById(int projectId)
        {
            return _context.Projects.FirstOrDefault(p => p.ProjectId == projectId);
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _context.Employees.FirstOrDefault(p => p.EmployeeId == employeeId);
        }

        public void UpdateProject(Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
        }

        public void DeleteProject(int projectId)
        {
            var project = GetProjectById(projectId);
            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }
        }



        public void AddEmployeeToProject(int employeeId, int projectId)
        {
            var project = GetProjectById(projectId);
            var employee = GetEmployeeById(employeeId);

            if (project != null && employee != null)
            {
                project.Employees.Add(employee);
                _context.SaveChanges();
            }
        }

        public void RemoveEmployeeFromProject(int employeeId, int projectId)
        {
            var project = GetProjectById(projectId);
            var employee = GetEmployeeById(employeeId);

            if (project != null && employee != null)
            {
                project.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }


        public List<Project> GetProjectsByPriority(int priority)
        {
            return _context.Projects.Where(p => p.Priority == priority).ToList();
        }

        public List<Project> GetAllProjects()
        {
            return _context.Projects.ToList();
        }

    }
}
