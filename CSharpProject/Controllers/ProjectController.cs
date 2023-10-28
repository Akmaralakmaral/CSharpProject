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

        public IActionResult Index()
        {
            List<Project> projects = _projectServices.GetAllProjects();
            return View(projects);
        }

        public IActionResult Details(int id)
        {
            Project project = _projectServices.GetProjectById(id);
            return View(project);
        }

        public IActionResult Create()
        {
            // Вывести форму для создания проекта
            return View();
        }

        [HttpPost]
        public IActionResult Create(Project project)
        {
            // Обработать данные формы и добавить новый проект
            _projectServices.AddProject(project);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Project project = _projectServices.GetProjectById(id);
            return View(project);
        }

        [HttpPost]
        public IActionResult Edit(Project project)
        {
            // Обработать данные формы и обновить проект
            _projectServices.UpdateProject(project);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Project project = _projectServices.GetProjectById(id);
            return View(project);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            // Удалить проект
            _projectServices.DeleteProject(id);
            return RedirectToAction("Index");
        }
    }
}
