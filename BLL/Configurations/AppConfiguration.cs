

using BLL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Configurations
{
    static public class AppConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IProjectServices, IProjectServices>();
            services.AddTransient<IProjectEmployeeServices, IProjectEmployeeServices>();
            services.AddTransient<ICompanyServices, ICompanyServices>();
            services.AddTransient<IEmployeeServices, IEmployeeServices>();
            services.AddTransient<ITaskServices, ITaskServices>();
        }
    }
}
