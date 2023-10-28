

using BLL.Services;
using BLL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Configurations
{
    static public class AppConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IProjectServices, ProjectServices>();
            services.AddTransient<IProjectEmployeeServices, ProjectEmployeeServices>();
            services.AddTransient<ICompanyServices, CompanyServices>();
            services.AddTransient<IEmployeeServices, EmployeeServices>();
            services.AddTransient<ITaskServices, TaskServices>();
            
        }
    }
}
