using AutoMapper;
using Domain.Models.DTO;
using BLL.Services.Interfaces;
using Domain.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSharpProject.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectServices _projectServices;
        private readonly IEmployeeServices _employeeServices;
        private readonly ICompanyServices _companyServices;
        private readonly IMapper _mapper;


        public ProjectController(IProjectServices projectServices, IEmployeeServices employeeServices,  IMapper mapper, ICompanyServices companyServices)
        {
            _projectServices = projectServices;
            _employeeServices = employeeServices;
            _mapper = mapper;
            _companyServices = companyServices;
        }

        // Действие для отображения списка проектов
        public IActionResult Index()
        {
            // Получаем все проекты из сервиса
            var projects = _projectServices.GetAllProjects();

            // Маппим проекты в ViewModel
            var projectViewModels = _mapper.Map<List<ProjectViewModel>>(projects);

            // Возвращаем представление с списком проектов
            return View(projectViewModels);
        }

        // Действие для отображения деталей проекта
        public IActionResult Details(int id)
        {
            // Получаем проект по идентификатору из сервиса
            var project = _projectServices.GetProjectById(id);

            // Маппим проект в ViewModel
            var projectViewModel = _mapper.Map<ProjectViewModel>(project);

            // Возвращаем представление с деталями проекта
            return View(projectViewModel);
        }

        // Действие для отображения формы создания проекта
        public IActionResult Create()
        {
            var companies = _companyServices.GetAllCompanies();
            var employees = _employeeServices.GetAllEmployees();

            var projectViewModel = new ProjectViewModel
            {
                CompanyList = companies.Select(c => new SelectListItem { Value = c.CompanyName, Text = c.CompanyName }).ToList(),
                EmployeeList = employees.Select(e => new SelectListItem { Value = e.EmployeeId.ToString(), Text = $"{e.FirstName} {e.LastName}" }).ToList()
            };

            return View(projectViewModel);
        }

        // Действие для обработки создания проекта
        [HttpPost]
        public IActionResult Create(ProjectViewModel projectViewModel)
        {
            // Проверяем, прошла ли валидация модели
            if (ModelState.IsValid)
            {
                // Маппим ViewModel в DTO
                var projectDTO = _mapper.Map<ProjectDTO>(projectViewModel);

                // Вызываем сервис для добавления проекта
                _projectServices.AddProject(projectDTO);

                // Перенаправляем на список проектов
                return RedirectToAction(nameof(Index));
            }

            // Если валидация не удалась, возвращаем представление с ошибками
            return View(projectViewModel);
        }

        // Действие для отображения формы редактирования проекта
        public IActionResult Edit(int id)
        {
            // Получаем проект по идентификатору из сервиса
            var project = _projectServices.GetProjectById(id);

            // Маппим проект в ViewModel
            var projectViewModel = _mapper.Map<ProjectViewModel>(project);

            // Возвращаем представление для редактирования проекта
            return View(projectViewModel);
        }

        // Действие для обработки редактирования проекта
        [HttpPost]
        public IActionResult Edit(int id, ProjectViewModel projectViewModel)
        {
            // Проверяем, прошла ли валидация модели и соответствует ли идентификатор
            if (id != projectViewModel.ProjectId || !ModelState.IsValid)
            {
                // Если условия не выполнились, возвращаем 404 Not Found
                return NotFound();
            }

            // Маппим ViewModel в DTO
            var projectDTO = _mapper.Map<ProjectDTO>(projectViewModel);

            // Вызываем сервис для обновления проекта
            _projectServices.UpdateProject(projectDTO);

            // Перенаправляем на список проектов
            return RedirectToAction(nameof(Index));
        }

        // Действие для отображения формы подтверждения удаления проекта
        public IActionResult Delete(int id)
        {
            // Получаем проект по идентификатору из сервиса
            var project = _projectServices.GetProjectById(id);

            // Маппим проект в ViewModel
            var projectViewModel = _mapper.Map<ProjectViewModel>(project);

            // Возвращаем представление для подтверждения удаления проекта
            return View(projectViewModel);
        }

        // Действие для обработки подтверждения удаления проекта
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Вызываем сервис для удаления проекта
            _projectServices.DeleteProject(id);

            // Перенаправляем на список проектов
            return RedirectToAction(nameof(Index));
        }
    }


    //public ProjectController(IProjectServices projectServices, IEmployeeServices employeeServices, IMapper mapper)
    //{
    //    _projectServices = projectServices;
    //    _employeeServices = employeeServices;
    //    _mapper = mapper;
    //}

    //public IActionResult Index()
    //{
    //    // Метод для просмотра всех проектов
    //    var projects = _projectServices.GetAllProjects();
    //    var projectViewModels = _mapper.Map<List<ProjectViewModel>>(projects);
    //    return View(projectViewModels);
    //}

    //public IActionResult Create()
    //{
    //    // Метод для создания нового проекта
    //    return View();
    //}

    //[HttpPost]
    //public IActionResult Create(ProjectViewModel projectViewModel)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        var projectDTO = _mapper.Map<ProjectDTO>(projectViewModel);
    //        _projectServices.AddProject(projectDTO);
    //        return RedirectToAction("Index");
    //    }

    //    return View(projectViewModel);
    //}

    //public IActionResult Edit(int id)
    //{
    //    // Метод для редактирования проекта
    //    var project = _projectServices.GetProjectById(id);
    //    var projectViewModel = _mapper.Map<ProjectViewModel>(project);
    //    return View(projectViewModel);
    //}

    //[HttpPost]
    //public IActionResult Edit(ProjectViewModel projectViewModel)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        var projectDTO = _mapper.Map<ProjectDTO>(projectViewModel);
    //        _projectServices.UpdateProject(projectDTO);
    //        return RedirectToAction("Index");
    //    }

    //    return View(projectViewModel);
    //}

    //public IActionResult Delete(int id)
    //{
    //    // Метод для удаления проекта
    //    var project = _projectServices.GetProjectById(id);
    //    var projectViewModel = _mapper.Map<ProjectViewModel>(project);
    //    return View(projectViewModel);
    //}

    //[HttpPost, ActionName("Delete")]
    //public IActionResult DeleteConfirmed(int id)
    //{
    //    _projectServices.DeleteProject(id);
    //    return RedirectToAction("Index");
    //}

    //public IActionResult AddEmployee(int projectId)
    //{
    //    // Метод для добавления сотрудника к проекту
    //    var employees = _employeeServices.GetAllEmployees();
    //    var employeeViewModels = _mapper.Map<List<EmployeeViewModel>>(employees);
    //    ViewBag.ProjectId = projectId;
    //    return View(employeeViewModels);
    //}

    //[HttpPost]
    //public IActionResult AddEmployee(int projectId, List<int> employeeIds)
    //{
    //    if (employeeIds != null && employeeIds.Any())
    //    {
    //        foreach (var employeeId in employeeIds)
    //        {
    //            _projectServices.AddEmployeeToProject(employeeId, projectId);
    //        }
    //    }
    //    return RedirectToAction("Index");
    //}


    //[HttpPost]
    //public IActionResult RemoveEmployee(int projectId, List<int> employeeIds)
    //{
    //    if (employeeIds != null && employeeIds.Any())
    //    {
    //        foreach (var employeeId in employeeIds)
    //        {
    //            _projectServices.RemoveEmployeeFromProject(employeeId, projectId);
    //        }
    //    }
    //    return RedirectToAction("Index");
    //}

    //public IActionResult SortByName()
    //{
    //    // Метод для сортировки проектов по названию
    //    var projects = _projectServices.SortProjectsByName();
    //    var projectViewModels = _mapper.Map<List<ProjectViewModel>>(projects);
    //    return View("Index", projectViewModels);
    //}



}

