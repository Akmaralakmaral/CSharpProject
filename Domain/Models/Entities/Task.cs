
namespace Domain.Models.Entities
{
    public class Task
    {
        public Guid Id { get; set; }  // Уникальный идентификатор задачи
        public string TaskName { get; set; }  // Название задачи
        public Guid AuthorId { get; set; }  // Идентификатор автора задачи
        public Employee Author { get; set; }  // Ссылка на сущность сотрудника-автора задачи
        public Guid AssigneeId { get; set; }  // Идентификатор исполнителя задачи
        public Employee Assignee { get; set; }  // Ссылка на сущность сотрудника-исполнителя задачи
        public TaskStatus Status { get; set; }  // Статус задачи
        public string Comment { get; set; }  // Комментарий к задаче

        public Guid ProjectId { get; set; }  // Идентификатор проекта, к которому относится задача
        public Project Project { get; set; }  // Ссылка на сущность проекта

    }
}
