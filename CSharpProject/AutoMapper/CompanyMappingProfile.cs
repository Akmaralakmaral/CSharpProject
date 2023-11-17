using AutoMapper;
using Domain.Models.DTO;
using Domain.Models.ViewModels;

namespace CSharpProject.AutoMapper
{
    public class CompanyMappingProfile : Profile
    {
        public CompanyMappingProfile()
        {
            CreateMap<CompanyDTO, CompanyViewModel>()
                .ForMember(dest => dest.Projects, opt => opt.MapFrom(src => src.ProjectIds))
                .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.EmployeeIds))
                .ReverseMap();

            CreateMap<ProjectDTO, ProjectViewModel>().ReverseMap();
            CreateMap<EmployeeDTO, EmployeeViewModel>().ReverseMap();
        }
    }
}
