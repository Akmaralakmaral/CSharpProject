
using Domain.Models.DTO;

namespace BLL.Services.Interfaces
{
    public interface ITaskServices
    {
        // Получить задачу по идентификатору
        TaskDTO GetTaskById(int taskId);

        // Получить задачи, относящиеся к конкретному проекту
        IEnumerable<TaskDTO> GetTasksByProject(int projectId);

        // Получить задачи, назначенные конкретному сотруднику
        IEnumerable<TaskDTO> GetTasksByAssignee(int assigneeId);

        // Получить все задачи
        List<TaskDTO> GetAllTasks();

        // Создать новую задачу
        void CreateTask(TaskDTO taskDTO);

        // Обновить существующую задачу
        void UpdateTask(TaskDTO taskDTO);

        // Удалить задачу по идентификатору
        void DeleteTask(int taskId);
    }
}
