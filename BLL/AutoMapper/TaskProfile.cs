using AutoMapper;
using Domain.Models.DTO;

namespace BLL.AutoMapper
{
    
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            // Создание сопоставления (mapping) между сущностью Task и DTO TaskDTO
            CreateMap<Domain.Models.Entities.Task, TaskDTO>() 

            .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.Author.EmployeeId))
            .ForMember(dest => dest.AssigneeId, opt => opt.MapFrom(src => src.Assignee.EmployeeId))
            .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.Project.ProjectId))
            .ReverseMap();// Позволяет совершать обратное сопоставление (из TaskDTO в Task)
        }
    }
}
