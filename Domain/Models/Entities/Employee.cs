
namespace Domain.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }  // Уникальный идентификатор сотрудника
        public string FirstName { get; set; }  // Имя сотрудника
        public string LastName { get; set; }  // Фамилия сотрудника
        public string MiddleName { get; set; }  // Отчество сотрудника
        public string Email { get; set; }  // Электронная почта сотрудника

        public List<Project> Projects { get; set; }  // Список проектов, над которыми работает сотрудник
        public List<Task> AssignedTasks { get; set; }  // Список задач, которые назначены сотруднику
        public List<Task> AuthoredTasks { get; set; }  // Список задач, созданных сотрудником

    }
}
