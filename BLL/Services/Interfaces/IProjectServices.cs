
using Domain.Models.Entities;

namespace BLL.Services.Interfaces
{
    public interface IProjectServices
    {
        // Метод для добавления нового проекта
        void AddProject(Project project);

        // Метод для получения проекта по его ID
        Project GetProjectById(int projectId);

        // Метод для обновления данных проекта
        void UpdateProject(Project project);

        // Метод для удаления проекта по его ID
        void DeleteProject(int projectId);

        // Метод для добавления сотрудника к проекту
        void AddEmployeeToProject(int projectId, int employeeId);

        // Метод для удаления сотрудника с проекта
        void RemoveEmployeeFromProject(int projectId, int employeeId);

        // Метод для получения списка проектов по их приоритету
        List<Project> GetProjectsByPriority(int priority);
       
    }
}
