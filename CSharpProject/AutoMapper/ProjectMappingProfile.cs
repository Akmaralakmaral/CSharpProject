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
            .ForMember(dest => dest.CustomerCompanyId, opt => opt.MapFrom(src => src.CustomerCompanyName != null ? src.CustomerCompanyName : "DefaultCompany"))
            .ForMember(dest => dest.ExecutorCompanyId, opt => opt.MapFrom(src => src.ExecutorCompanyName != null ? src.ExecutorCompanyName : "DefaultCompany"))
            .ForMember(dest => dest.ProjectManagerId, opt => opt.MapFrom(src => src.ProjectManagerName != null ? src.ProjectManagerName : "DefaultManager"))
            .ForMember(dest => dest.EmployeeIds, opt => opt.MapFrom(src => src.EmployeeNames != null ? src.EmployeeNames : new List<string>()))
            .ReverseMap();

        }
    }
}
