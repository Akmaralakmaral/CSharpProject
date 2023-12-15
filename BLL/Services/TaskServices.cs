
using AutoMapper;
using Domain.Models.DTO;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using Domain.Models.Entities;

namespace BLL.Services
{
    public class TaskServices : ITaskServices
    {
        // Внедрение зависимости репозитория, например, ITaskRepository
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly ITelegramBot _telegramBot;

        public TaskServices(ITaskRepository taskRepository, IMapper mapper, ITelegramBot telegramBot)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _telegramBot = telegramBot;
        }
        public TaskDTO GetTaskById(int taskId)
        {
            // Получить задачу по идентификатору через репозиторий
            var task = _taskRepository.GetTaskById(taskId);
            // Преобразовать задачу в TaskDTO с использованием AutoMapper
            return _mapper.Map<TaskDTO>(task);
        }

        public IEnumerable<TaskDTO> GetTasksByProject(int projectId)
        {
            // Получить задачи, относящиеся к конкретному проекту
            var tasks = _taskRepository.GetTasksByProject(projectId);
            // Преобразовать список задач в список TaskDTO с использованием AutoMapper
            return _mapper.Map<IEnumerable<TaskDTO>>(tasks);
        }

        public IEnumerable<TaskDTO> GetTasksByAssignee(int assigneeId)
        {
            // Получить задачи, назначенные конкретному сотруднику
            var tasks = _taskRepository.GetTasksByAssignee(assigneeId);
            // Преобразовать список задач в список TaskDTO с использованием AutoMapper
            return _mapper.Map<IEnumerable<TaskDTO>>(tasks);
        }

        public List<TaskDTO> GetAllTasks()
        {
            // Получить все задачи
            var tasks = _taskRepository.GetAllTasks();
            // Преобразовать список задач в список TaskDTO с использованием AutoMapper
            return _mapper.Map<List<TaskDTO>>(tasks);
        }

        //public void CreateTask(TaskDTO taskDTO)
        //{
        //    // Преобразовать TaskDTO в задачу Task с использованием AutoMapper
        //    var task = _mapper.Map<Domain.Models.Entities.Task>(taskDTO);
        //    // Сохранить новую задачу через репозиторий
        //    _taskRepository.CreateTask(task);
        //}


        public void CreateTask(TaskDTO taskDTO)
        {
            // Преобразовать TaskDTO в задачу Task с использованием AutoMapper
            var task = _mapper.Map<Domain.Models.Entities.Task>(taskDTO);

            // Сохранить новую задачу через репозиторий
            _taskRepository.CreateTask(task);

            // Отправить уведомление в Telegram о создании новой задачи
            string telegramMessage = $"Новая задача: {taskDTO.TaskName}";
            _telegramBot.SendTaskNotificationAsync("1650190510", telegramMessage).Wait();
        }

        public void UpdateTask(TaskDTO taskDTO)
        {
            // Преобразовать TaskDTO в задачу Task с использованием AutoMapper
            var task = _mapper.Map<Domain.Models.Entities.Task>(taskDTO);
            // Обновить существующую задачу через репозиторий
            _taskRepository.UpdateTask(task);


            //string telegramMessage = $"Обновлена задача: {taskDTO.TaskName}, Статус: {taskDTO.Status}";
            //_telegramBot.SendTaskNotificationAsync("1650190510", telegramMessage).Wait();

            string telegramMessage = $"Обновлена задача:\n" +
                             $"Название: {taskDTO.TaskName}\n" +
                             $"Статус: {taskDTO.Status}\n";

            _telegramBot.SendTaskNotificationAsync("1650190510", telegramMessage).Wait();


        }

        public void DeleteTask(int taskId)
        {
            // Удалить задачу по идентификатору через репозиторий
            _taskRepository.DeleteTask(taskId);
        }
    }
}
