using AutoMapper;
using Domain.Models.DTO;
using BLL.Services.Interfaces;
using Domain.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CSharpProject.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectServices _projectServices;
        private readonly IEmployeeServices _employeeServices;
        private readonly IMapper _mapper;

        public ProjectController(IProjectServices projectServices, IEmployeeServices employeeServices, IMapper mapper)
        {
            _projectServices = projectServices;
            _employeeServices = employeeServices;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            // Метод для просмотра всех проектов
            var projects = _projectServices.GetAllProjects();
            var projectViewModels = _mapper.Map<List<ProjectViewModel>>(projects);
            return View(projectViewModels);
        }

        public IActionResult Create()
        {
            // Метод для создания нового проекта
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProjectViewModel projectViewModel)
        {
            if (ModelState.IsValid)
            {
                var projectDTO = _mapper.Map<ProjectDTO>(projectViewModel);
                _projectServices.AddProject(projectDTO);
                return RedirectToAction("Index");
            }

            return View(projectViewModel);
        }

        public IActionResult Edit(int id)
        {
            // Метод для редактирования проекта
            var project = _projectServices.GetProjectById(id);
            var projectViewModel = _mapper.Map<ProjectViewModel>(project);
            return View(projectViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProjectViewModel projectViewModel)
        {
            if (ModelState.IsValid)
            {
                var projectDTO = _mapper.Map<ProjectDTO>(projectViewModel);
                _projectServices.UpdateProject(projectDTO);
                return RedirectToAction("Index");
            }

            return View(projectViewModel);
        }

        public IActionResult Delete(int id)
        {
            // Метод для удаления проекта
            var project = _projectServices.GetProjectById(id);
            var projectViewModel = _mapper.Map<ProjectViewModel>(project);
            return View(projectViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _projectServices.DeleteProject(id);
            return RedirectToAction("Index");
        }

        public IActionResult AddEmployee(int projectId)
        {
            // Метод для добавления сотрудника к проекту
            var employees = _employeeServices.GetAllEmployees();
            var employeeViewModels = _mapper.Map<List<EmployeeViewModel>>(employees);
            ViewBag.ProjectId = projectId;
            return View(employeeViewModels);
        }

        [HttpPost]
        public IActionResult AddEmployee(int projectId, List<int> employeeIds)
        {
            if (employeeIds != null && employeeIds.Any())
            {
                foreach (var employeeId in employeeIds)
                {
                    _projectServices.AddEmployeeToProject(employeeId, projectId);
                }
            }
            return RedirectToAction("Index");
        }

        //public IActionResult RemoveEmployee(int projectId)
        //{
        //    // Метод для удаления сотрудника с проекта
        //    var employees = _projectServices.GetEmployeesByProject(projectId);
        //    var employeeViewModels = _mapper.Map<List<EmployeeViewModel>>(employees);
        //    ViewBag.ProjectId = projectId;
        //    return View(employeeViewModels);
        //}

        [HttpPost]
        public IActionResult RemoveEmployee(int projectId, List<int> employeeIds)
        {
            if (employeeIds != null && employeeIds.Any())
            {
                foreach (var employeeId in employeeIds)
                {
                    _projectServices.RemoveEmployeeFromProject(employeeId, projectId);
                }
            }
            return RedirectToAction("Index");
        }

        //public IActionResult FilterByStartDate(DateTime startDate)
        //{
        //    // Метод для фильтрации проектов по дате начала
        //    var projects = _projectServices.FilterProjectsByStartDate(startDate);
        //    var projectViewModels = _mapper.Map<List<ProjectViewModel>>(projects);
        //    return View("Index", projectViewModels);
        //}

        //public IActionResult FilterByPriority(int priority)
        //{
        //    // Метод для фильтрации проектов по приоритету
        //    var projects = _projectServices.FilterProjectsByPriority(priority);
        //    var projectViewModels = _mapper.Map<List<ProjectViewModel>>(projects);
        //    return View("Index", projectViewModels);
        //}

        public IActionResult SortByName()
        {
            // Метод для сортировки проектов по названию
            var projects = _projectServices.SortProjectsByName();
            var projectViewModels = _mapper.Map<List<ProjectViewModel>>(projects);
            return View("Index", projectViewModels);
        }



    }
}
