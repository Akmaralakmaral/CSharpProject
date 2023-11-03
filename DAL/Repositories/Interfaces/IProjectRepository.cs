using System.Collections.Generic;
using Domain.Models.Entities;

namespace DAL.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        // Добавление нового проекта
        void AddProject(Project project);

        // Получение проекта по идентификатору
        Project GetProjectById(int projectId);

        // Обновление информации о проекте
        void UpdateProject(Project project);

        // Удаление проекта по идентификатору
        void DeleteProject(int projectId);

        // Добавление сотрудника к проекту
        void AddEmployeeToProject(int projectId, int employeeId);

        // Удаление сотрудника с проекта
        void RemoveEmployeeFromProject(int projectId, int employeeId);

        // Получение списка проектов с указанным приоритетом
        List<Project> GetProjectsByPriority(int priority);

        // Новый метод для получения всех проектов
        List<Project> GetAllProjects();
    }
}
