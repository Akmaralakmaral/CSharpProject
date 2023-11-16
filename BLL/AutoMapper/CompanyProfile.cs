
using AutoMapper;
using Domain.Models.DTO;
using Domain.Models.Entities;

namespace BLL.AutoMapper
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDTO>()
                .ForMember(dest => dest.ProjectIds, opt => opt.MapFrom(src => src.Projects.Select(p => p.ProjectId).ToList()))
                .ForMember(dest => dest.EmployeeIds, opt => opt.MapFrom(src => src.Employees.Select(e => e.EmployeeId).ToList()))
                .ReverseMap();
        }
    }
}
