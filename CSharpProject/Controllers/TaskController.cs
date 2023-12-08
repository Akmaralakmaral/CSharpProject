using AutoMapper;
using BLL.Services.Interfaces;
using Domain.Models.DTO;
using Domain.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSharpProject.Controllers
{
       public class TaskController : Controller
    {
        private readonly ITaskServices _taskServices;
        private readonly IEmployeeServices _employeeServices;
        private readonly IProjectServices _projectServices;
        private readonly IMapper _mapper;

        public TaskController(ITaskServices taskServices, IEmployeeServices employeeServices, IProjectServices projectServices, IMapper mapper)
        {
            _taskServices = taskServices;
            _employeeServices = employeeServices;
            _projectServices = projectServices;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            // Получить все задачи
            var tasksDTO = _taskServices.GetAllTasks();

            // Маппим задачи в ViewModel
            var tasksViewModel = _mapper.Map<List<TaskViewModel>>(tasksDTO);

            return View(tasksViewModel);
        }

        public IActionResult Details(int id)
        {
            // Получить задачу по идентификатору
            var taskDTO = _taskServices.GetTaskById(id);
            if (taskDTO == null)
            {
                return NotFound();
            }

            // Маппим задачу в ViewModel
            var taskViewModel = _mapper.Map<TaskViewModel>(taskDTO);

            return View(taskViewModel);
        }

        public IActionResult Create()
        {
            // Получаем списки сотрудников и проектов для выпадающих списков в форме
            var employees = _employeeServices.GetAllEmployees();
            var projects = _projectServices.GetAllProjects();

            var taskViewModel = new TaskViewModel
            {
                EmployeeList = employees.Select(e => new SelectListItem { Value = e.EmployeeId.ToString(), Text = $"{e.FirstName} {e.LastName}" }).ToList(),
                ProjectList = projects.Select(p => new SelectListItem { Value = p.ProjectId.ToString(), Text = p.ProjectName }).ToList()
            };

            // Представление для создания новой задачи
            return View(taskViewModel);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TaskViewModel taskViewModel)
        {
            // Проверяем, прошла ли валидация модели
            if (ModelState.IsValid)
            {
                // Маппим ViewModel в DTO
                var taskDTO = _mapper.Map<TaskDTO>(taskViewModel);

                // Создать новую задачу
                _taskServices.CreateTask(taskDTO);
                return RedirectToAction("Index");
            }

            // Если валидация не удалась, возвращаем представление с ошибками
            return View(taskViewModel);
        }

        public IActionResult Edit(int id)
        {
            // Получить задачу по идентификатору для редактирования
            var taskDTO = _taskServices.GetTaskById(id);
            if (taskDTO == null)
            {
                return NotFound();
            }

            // Получаем списки сотрудников и проектов для выпадающих списков в форме
            var employees = _employeeServices.GetAllEmployees();
            var projects = _projectServices.GetAllProjects();

            var taskViewModel = _mapper.Map<TaskViewModel>(taskDTO);

            // Заполняем список сотрудников и проектов в модели представления
            taskViewModel.EmployeeList = employees.Select(e => new SelectListItem { Value = e.EmployeeId.ToString(), Text = $"{e.FirstName} {e.LastName}" }).ToList();
            taskViewModel.ProjectList = projects.Select(p => new SelectListItem { Value = p.ProjectId.ToString(), Text = p.ProjectName }).ToList();

            // Возвращаем представление для редактирования задачи
            return View(taskViewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, [FromBody] TaskViewModel taskViewModel)
        {
            // Проверяем, прошла ли валидация модели и соответствует ли идентификатор
            if (id != taskViewModel.TaskId || !ModelState.IsValid)
            {
                // Если условия не выполнились, возвращаем 404 Not Found
                return NotFound();
            }

            // Маппим ViewModel в DTO
            var taskDTO = _mapper.Map<TaskDTO>(taskViewModel);

            // Обновить существующую задачу
            _taskServices.UpdateTask(taskDTO);

            // Перенаправляем на список задач
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            // Получить задачу по идентификатору для удаления
            var taskDTO = _taskServices.GetTaskById(id);
            if (taskDTO == null)
            {
                return NotFound();
            }

            // Маппим задачу в ViewModel
            var taskViewModel = _mapper.Map<TaskViewModel>(taskDTO);

            // Получаем списки сотрудников и проектов для отображения в деталях задачи
            var employees = _employeeServices.GetAllEmployees();
            var projects = _projectServices.GetAllProjects();

            // Заполняем список сотрудников и проектов в модели представления
            taskViewModel.EmployeeList = employees.Select(e => new SelectListItem { Value = e.EmployeeId.ToString(), Text = $"{e.FirstName} {e.LastName}" }).ToList();
            taskViewModel.ProjectList = projects.Select(p => new SelectListItem { Value = p.ProjectId.ToString(), Text = p.ProjectName }).ToList();

            // Возвращаем представление для подтверждения удаления задачи
            return View(taskViewModel);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            // Удалить задачу по идентификатору
            _taskServices.DeleteTask(id);

            // Перенаправляем на список задач
            return RedirectToAction("Index");
        }
    }
    
}
