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

            services.AddLogging(builder =>
            {
                // Здесь вы можете добавить различные провайдеры логирования, например, консоль
                builder.AddConsole();
            });
        }


        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ... другая конфигурация ...

            // Добавление endpoint для health check
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health");
                // ... другие endpoint'ы ...
            });
        }

    }


}
