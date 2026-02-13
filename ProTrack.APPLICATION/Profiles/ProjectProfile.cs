using AutoMapper;
using ProTrack.DOMAIN.Dtos.Projects.Requests;
using ProTrack.DOMAIN.Dtos.Projects.Responses;
using ProTrack.DOMAIN.Entities;

namespace ProTrack.APPLICATION.Profiles;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<CreateProjectDto, Project>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreateAt, opt => opt.Ignore())
            .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());

        CreateMap<Project, ProjectResponseDto>();
    }
}
