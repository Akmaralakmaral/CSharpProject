
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using Domain.Models.Entities;

namespace BLL.Services
{
    public class ProjectServices : IProjectServices
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectServices(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public void AddProject(Project project)
        {
            _projectRepository.AddProject(project);
        }

        public Project GetProjectById(int projectId)
        {
            return _projectRepository.GetProjectById(projectId);
        }

        public void UpdateProject(Project project)
        {
            _projectRepository.UpdateProject(project);
        }

        public void DeleteProject(int projectId)
        {
            _projectRepository.DeleteProject(projectId);
        }

        public void AddEmployeeToProject(int projectId, int employeeId)
        {
            _projectRepository.AddEmployeeToProject(projectId, employeeId);
        }

        public void RemoveEmployeeFromProject(int projectId, int employeeId)
        {
            _projectRepository.RemoveEmployeeFromProject(projectId, employeeId);
        }

        public List<Project> GetProjectsByPriority(int priority)
        {
            return _projectRepository.GetProjectsByPriority(priority);
        }

        public List<Project> GetAllProjects()
        {
            return _projectRepository.GetAllProjects();
        }
    }
}
