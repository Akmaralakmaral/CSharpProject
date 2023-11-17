using AutoMapper;
using Domain.Models.DTO;
using Domain.Models.ViewModels;

namespace CSharpProject.AutoMapper
{
   
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<EmployeeDTO, EmployeeViewModel>()
                .ForMember(dest => dest.Projects, opt => opt.MapFrom(src => src.ProjectIds))
                .ForMember(dest => dest.AuthoredTasks, opt => opt.MapFrom(src => src.AuthoredTaskIds))
                .ForMember(dest => dest.AssignedTasks, opt => opt.MapFrom(src => src.AssignedTaskIds));

            CreateMap<EmployeeViewModel, EmployeeDTO>()
                .ForMember(dest => dest.ProjectIds, opt => opt.MapFrom(src => src.Projects))
                .ForMember(dest => dest.AuthoredTaskIds, opt => opt.MapFrom(src => src.AuthoredTasks))
                .ForMember(dest => dest.AssignedTaskIds, opt => opt.MapFrom(src => src.AssignedTasks));

            CreateMap<ProjectDTO, ProjectViewModel>().ReverseMap();
            CreateMap<TaskDTO, TaskViewModel>().ReverseMap();

            // Явные сопоставления для списков
            CreateMap<int, ProjectViewModel>().ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src));
            CreateMap<int, TaskViewModel>().ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src));
        }
    }

}
