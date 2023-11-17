using BLL.Services.Interfaces;
using Domain.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CSharpProject.Controllers
{
      public class TaskController : Controller
        {
            private readonly ITaskServices _taskServices;

            public TaskController(ITaskServices taskServices)
            {
                _taskServices = taskServices;
            }

            public IActionResult Index()
            {
                // Получить все задачи
                var tasks = _taskServices.GetAllTasks();
                return View(tasks);
            }

            public IActionResult Details(int id)
            {
                // Получить задачу по идентификатору
                var task = _taskServices.GetTaskById(id);
                if (task == null)
                {
                    return NotFound();
                }
                return View(task);
            }

            public IActionResult Create()
            {
                // Представление для создания новой задачи
                return View();
            }

            [HttpPost]
            public IActionResult Create(TaskDTO taskDTO)
            {
                // Создать новую задачу
                _taskServices.CreateTask(taskDTO);
                return RedirectToAction("Index");
            }

            public IActionResult Edit(int id)
            {
                // Получить задачу по идентификатору для редактирования
                var task = _taskServices.GetTaskById(id);
                if (task == null)
                {
                    return NotFound();
                }
                return View(task);
            }

            [HttpPost]
            public IActionResult Edit(int id, TaskDTO taskDTO)
            {
                // Обновить существующую задачу
                _taskServices.UpdateTask(taskDTO);
                return RedirectToAction("Index");
            }

            public IActionResult Delete(int id)
            {
                // Получить задачу по идентификатору для удаления
                var task = _taskServices.GetTaskById(id);
                if (task == null)
                {
                    return NotFound();
                }
                return View(task);
            }

            [HttpPost, ActionName("Delete")]
            public IActionResult DeleteConfirmed(int id)
            {
                // Удалить задачу по идентификатору
                _taskServices.DeleteTask(id);
                return RedirectToAction("Index");
            }
       }
    
}
