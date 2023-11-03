
using AutoMapper;
using BLL.DTO;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using Domain.Models.Entities;

namespace BLL.Services
{
    public class ProjectServices : IProjectServices
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectServices(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public void AddProject(ProjectDTO project)
        {
            var projectEntity = _mapper.Map<Project>(project);
            _projectRepository.AddProject(projectEntity);
        }

        public ProjectDTO GetProjectById(int projectId)
        {
            var project = _projectRepository.GetProjectById(projectId);
            return _mapper.Map<ProjectDTO>(project);
        }

        public void UpdateProject(ProjectDTO project)
        {
            var projectEntity = _mapper.Map<Project>(project);
            _projectRepository.UpdateProject(projectEntity);
        }

        public void DeleteProject(int projectId)
        {
            _projectRepository.DeleteProject(projectId);
        }

        public void AddEmployeeToProject(int employeeId, int projectId)
        {
            _projectRepository.AddEmployeeToProject(employeeId, projectId);
        }

        public void RemoveEmployeeFromProject(int employeeId, int projectId)
        {
            _projectRepository.RemoveEmployeeFromProject(employeeId, projectId);
        }

        public List<ProjectDTO> GetProjectsByPriority(int priority)
        {
            var projects = _projectRepository.GetProjectsByPriority(priority);
            return _mapper.Map<List<ProjectDTO>>(projects);
        }

        public List<ProjectDTO> GetAllProjects()
        {
            var projects = _projectRepository.GetAllProjects();
            return _mapper.Map<List<ProjectDTO>>(projects);
        }
    }
}
