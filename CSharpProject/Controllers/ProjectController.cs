using BLL.Services.Interfaces;
using Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CSharpProject.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectServices _projectServices;

        public ProjectController(IProjectServices projectServices)
        {
            _projectServices = projectServices;
        }

      
    }
}
