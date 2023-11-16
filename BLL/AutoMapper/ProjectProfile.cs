
using AutoMapper;
using Domain.Models.DTO;
using Domain.Models.Entities;

namespace BLL.AutoMapper
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDTO>()
                .ForMember(dest => dest.EmployeeIds, opt => opt.MapFrom(src => src.Employees.Select(e => e.EmployeeId)))
                .ForMember(dest => dest.TaskIds, opt => opt.MapFrom(src => src.Tasks.Select(t => t.TaskId)));
            CreateMap<ProjectDTO, Project>()
                .ForMember(dest => dest.Employees, opt => opt.Ignore()) // Ignore Employees list, as we won't be mapping it back
                .ForMember(dest => dest.Tasks, opt => opt.Ignore()); // Ignore Tasks list, as we won't be mapping it back
        }
    }
}
