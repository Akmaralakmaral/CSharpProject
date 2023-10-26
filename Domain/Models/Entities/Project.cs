
namespace Domain.Models.Entities
{
    public class Project
    {
        public Guid Id { get; set; }  // Уникальный идентификатор проекта
        public string ProjectName { get; set; }  // Название проекта
        public DateTime StartDate { get; set; }  // Дата начала проекта
        public DateTime EndDate { get; set; }  // Дата окончания проекта

        public Guid CustomerCompanyId { get; set; }  // Идентификатор компании-заказчика
        public Company CustomerCompany { get; set; }  // Ссылка на компанию-заказчика

        public Guid ExecutorCompanyId { get; set; }  // Идентификатор компании-исполнителя
        public Company ExecutorCompany { get; set; }  // Ссылка на компанию-исполнителя

        public Guid ProjectManagerId { get; set; }  // Идентификатор руководителя проекта
        public Employee ProjectManager { get; set; }  // Ссылка на сущность сотрудника, являющегося руководителем проекта

        public List<Employee> Employees { get; set; }  // Список сотрудников, работающих над проектом
        public List<Task> Tasks { get; set; }  // Список задач, связанных с проектом


    }
}
