
using Domain.Models.DTO;

namespace BLL.Services.Interfaces
{
    public interface IProjectServices
    {
        // Метод для добавления нового проекта
        void AddProject(ProjectDTO project);

        // Метод для получения проекта по его ID
        ProjectDTO GetProjectById(int projectId);

        // Метод для обновления данных проекта
        void UpdateProject(ProjectDTO project);

        // Метод для удаления проекта по его ID
        void DeleteProject(int projectId);

        // Метод для добавления сотрудника к проекту
        void AddEmployeeToProject(int employeeId, int projectId);

        // Метод для удаления сотрудника с проекта
        void RemoveEmployeeFromProject(int employeeId, int projectId);

        // Метод для получения списка проектов по их приоритету
        List<ProjectDTO> GetProjectsByPriority(int priority);

        List<ProjectDTO> GetAllProjects();

        // Метод для сортировки проектов по названию
        List<ProjectDTO> SortProjectsByName();
    }
}
