
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Configurations
{
    public static class Appconfiguration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IProjectEmployeeRepository, ProjectEmployeeRepository>();
        }


    }
}
    