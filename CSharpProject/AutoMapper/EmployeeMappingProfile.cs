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
                .ForMember(dest => dest.AssignedTasks, opt => opt.MapFrom(src => src.AssignedTaskIds))
                .ReverseMap();

            CreateMap<ProjectDTO, ProjectViewModel>().ReverseMap();
            CreateMap<TaskDTO, TaskViewModel>().ReverseMap();
        }
    }

}
