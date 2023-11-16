using AutoMapper;
using Domain.Models.DTO;
using Domain.Models.Entities;

namespace BLL.AutoMapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>()
            .ForMember(dest => dest.ProjectIds, opt => opt.MapFrom(src => src.Projects.Select(p => p.ProjectId).ToList()))
            .ForMember(dest => dest.AuthoredTaskIds, opt => opt.MapFrom(src => src.AuthoredTasks.Select(t => t.TaskId).ToList()))
            .ForMember(dest => dest.AssignedTaskIds, opt => opt.MapFrom(src => src.AssignedTasks.Select(t => t.TaskId).ToList()))
            .ReverseMap();
        }
    }
}
