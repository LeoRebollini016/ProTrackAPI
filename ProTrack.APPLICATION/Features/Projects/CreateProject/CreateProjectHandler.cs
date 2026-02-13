using AutoMapper;
using FluentResults;
using MediatR;
using ProTrack.DOMAIN.Entities;
using ProTrack.DOMAIN.Enum;
using ProTrack.DOMAIN.Interfaces.Services;

namespace ProTrack.APPLICATION.Features.Projects.CreateProject;

public class CreateProjectHandler(IProjectService _projectService, IMapper _mapper) : IRequestHandler<CreateProjectRequest, Result>
{
    public async Task<Result> Handle(CreateProjectRequest request, CancellationToken ct)
    {
        var project = _mapper.Map<Project>(request.Dto);
        project.CreatedByUserId = request.UserId;

        project.ProjectUsers.Add(new ProjectUser
        {
            UserId = request.UserId,
            Role = ProjectUserRoleEnum.Owner
        });
        await _projectService.AddProjectAsync(project, ct);
        return Result.Ok();
    }
}