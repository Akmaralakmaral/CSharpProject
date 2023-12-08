using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.Services.Interfaces;
using Domain.Models.DTO;

namespace CSharpProject.ControllersSwagger
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectServices _projectServices;
        public ProjectController(IProjectServices projectServices)
        {
            _projectServices= projectServices;
        }
        [HttpGet]
        public List<ProjectDTO> GetAllProjects()
        {
            var projects = _projectServices.GetAllProjects();
            return projects;
        }

        [HttpPost]
        public IActionResult AddProject([FromBody] ProjectDTO projectDTO)
        {
            _projectServices.AddProject(projectDTO);
            return Ok("Project added successfully");
        }

        [HttpDelete("{projectId}")]
        public IActionResult DeleteProject(int projectId)
        {
            _projectServices.DeleteProject(projectId);
            return Ok($"Project with ID {projectId} deleted successfully");

        }

        [HttpPut]
        public IActionResult UpdateProject([FromBody] ProjectDTO projectDTO)
        {
            _projectServices.UpdateProject(projectDTO);
            return Ok($"Project with ID {projectDTO.ProjectId} updated successfully");
        }

    }
}
