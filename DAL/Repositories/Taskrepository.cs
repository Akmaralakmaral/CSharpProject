
using DAL.Context;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Entities;


namespace DAL.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;
        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        // Метод для получения задачи по идентификатору
        public Domain.Models.Entities.Task GetTaskById(int taskId)
        {
            return _context.Tasks
               .Include(t => t.Author)
               .Include(t => t.Assignee)
               .Include(t => t.Project)
               .FirstOrDefault(t => t.TaskId == taskId);
        }

        // Метод для получения всех задач, относящихся к конкретному проекту
        public IEnumerable<Domain.Models.Entities.Task> GetTasksByProject(int projectId)
        {
            return _context.Tasks
                .Where(t => t.ProjectId == projectId)
                .ToList();
        }

        // Метод для получения всех задач, назначенных конкретному сотруднику
        public IEnumerable<Domain.Models.Entities.Task> GetTasksByAssignee(int assigneeId)
        {
            return _context.Tasks
                .Where(t => t.AssigneeId == assigneeId)
                .ToList();
        }

        // Метод для получения всех задач
        public IEnumerable<Domain.Models.Entities.Task> GetAllTasks()
        {
            return _context.Tasks.ToList();
        }

        // Метод для создания новой задачи
        public void CreateTask(Domain.Models.Entities.Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        // Метод для обновления существующей задачи
        public void UpdateTask(Domain.Models.Entities.Task task)
        {
            _context.Entry(task).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // Метод для удаления задачи по идентификатору
        public void DeleteTask(int taskId)
        {
            var task = _context.Tasks.Find(taskId);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }
    }
}
