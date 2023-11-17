using AutoMapper;
using Domain.Models.DTO;
using Domain.Models.ViewModels;

namespace CSharpProject.AutoMapper
{
    public class TaskMappingProfile : Profile
    {
        public TaskMappingProfile()
        {
            CreateMap<TaskDTO, TaskViewModel>()
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => new EmployeeViewModel { EmployeeId = src.AuthorId }))
                .ForMember(dest => dest.Assignee, opt => opt.MapFrom(src => new EmployeeViewModel { EmployeeId = src.AssigneeId }))
                .ForMember(dest => dest.Project, opt => opt.MapFrom(src => new ProjectViewModel { ProjectId = src.ProjectId }))
                .ReverseMap();
        }
    }
}
