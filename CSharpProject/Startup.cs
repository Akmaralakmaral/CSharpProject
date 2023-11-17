using BLL.Services.Interfaces;
using BLL.Services;
using CSharpProject.AutoMapper;

namespace CSharpProject
{
    static  public class Startup
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IProjectServices, ProjectServices>();
            services.AddScoped<IEmployeeServices, EmployeeServices>();
            services.AddAutoMapper(typeof(ProjectMappingProfile));
            services.AddAutoMapper(typeof(CompanyMappingProfile));
            services.AddAutoMapper(typeof(EmployeeMappingProfile));
            services.AddAutoMapper(typeof(TaskMappingProfile));
        }

    }


}
