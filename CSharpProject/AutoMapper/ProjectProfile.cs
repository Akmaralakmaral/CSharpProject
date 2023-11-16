using AutoMapper;
using Domain.Models.DTO;
using Domain.Models.ViewModels;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<ProjectViewModel, ProjectDTO>().ReverseMap();
        CreateMap<ProjectDTO, ProjectViewModel>().ReverseMap();
    }
}