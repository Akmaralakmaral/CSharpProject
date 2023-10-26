
namespace Domain.Models.Entities
{
    public class Company
    {
        public Guid Id { get; set; }  // Уникальный идентификатор компании
        public string CompanyName { get; set; }  // Название компании

        public List<Project> CustomerProjects { get; set; }  // Список проектов, где компания является заказчиком
        public List<Project> ExecutorProjects { get; set; }  // Список проектов, где компания является исполнителем

    }
}
