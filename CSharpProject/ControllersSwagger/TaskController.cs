using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Models.DTO; 
using Domain.Models.Entities; 

namespace CSharpProject.ControllersSwagger
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskServices _taskServices;
        private readonly ITelegramBot _telegramBot; // Добавьте это поле

        public TaskController(ITaskServices taskServices, ITelegramBot telegramBot)
        {
            _taskServices = taskServices;
            _telegramBot = telegramBot; // Инициализируйте переменную в конструкторе
        }

        [HttpGet]
        public List<TaskDTO> GetAllTasks()
        {
            var tasks = _taskServices.GetAllTasks();
            return tasks;
        }

        [HttpPost]
        public IActionResult CreateTask(TaskDTO taskDTO)
        {
            //_taskServices.CreateTask(taskDTO);
            //return Ok("Task created successfully");

            _taskServices.CreateTask(taskDTO);

           

            return Ok("Task created successfully");
        }

        [HttpDelete("{taskId}")]
        public IActionResult DeleteTask(int taskId)
        {
            _taskServices.DeleteTask(taskId);
            return Ok($"Task with ID {taskId} deleted successfully");

        }

        [HttpPut]
        public IActionResult UpdateTask([FromBody] TaskDTO taskDTO)
        {
            _taskServices.UpdateTask(taskDTO);
            return Ok($"Project with ID {taskDTO.ProjectId} updated successfully");
        }

    }
}
