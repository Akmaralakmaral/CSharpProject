using AutoMapper;
using Domain.Models.DTO;
using Domain.Models.ViewModels;

namespace CSharpProject.AutoMapper
{
    public class ProjectMappingProfile : Profile
    {
        public ProjectMappingProfile()
        {
            CreateMap<ProjectViewModel, ProjectDTO>()
                 .ForMember(dest => dest.EmployeeIds, opt => opt.MapFrom(src => src.EmployeeList.Select(e => e.Value)))
                 .ForMember(dest => dest.TaskIds, opt => opt.MapFrom(src => src.TaskIds));

            CreateMap<ProjectDTO, ProjectViewModel>()
                .ForMember(dest => dest.EmployeeList, opt => opt.Ignore()) // Ignore EmployeeList, as it won't be mapped back
                .ForMember(dest => dest.TaskIds, opt => opt.MapFrom(src => src.TaskIds));


        }
    }
}
