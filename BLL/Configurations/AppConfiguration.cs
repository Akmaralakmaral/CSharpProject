

using BLL.AutoMapper;
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
            services.AddAutoMapper(typeof(ProjectProfile));

            services.AddTransient<ICompanyServices, CompanyServices>();
            services.AddAutoMapper(typeof(CompanyProfile));

            services.AddTransient<IEmployeeServices, EmployeeServices>();
            services.AddAutoMapper(typeof(EmployeeProfile));

            services.AddTransient<ITaskServices, TaskServices>();
            services.AddAutoMapper(typeof(TaskProfile));



            services.AddTransient<IProjectEmployeeServices, ProjectEmployeeServices>();

            string apiKey = "6598291497:AAEim0JhXfR9_W6zxaEi5P_lr2RnYpKTM80";
            services.AddTransient<ITelegramBot, TelegramBot>(provider => new TelegramBot(apiKey));

        }
    }
}
