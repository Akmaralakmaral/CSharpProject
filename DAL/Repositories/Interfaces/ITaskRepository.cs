
namespace DAL.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        // Метод для получения задачи по идентификатору
        Domain.Models.Entities.Task GetTaskById(int taskId);

        // Метод для получения всех задач, относящихся к конкретному проекту
        IEnumerable<Domain.Models.Entities.Task> GetTasksByProject(int projectId);

        // Метод для получения всех задач, назначенных конкретному сотруднику
        IEnumerable<Domain.Models.Entities.Task> GetTasksByAssignee(int assigneeId);

        // Метод для получения всех задач
        IEnumerable<Domain.Models.Entities.Task> GetAllTasks();

        // Метод для создания новой задачи
        void CreateTask(Domain.Models.Entities.Task task);

        // Метод для обновления существующей задачи
        void UpdateTask(Domain.Models.Entities.Task task);

        // Метод для удаления задачи по идентификатору
        void DeleteTask(int taskId);
    }
}
