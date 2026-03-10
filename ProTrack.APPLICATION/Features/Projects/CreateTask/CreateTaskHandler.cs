using FluentResults;
using MediatR;
using ProTrack.DOMAIN.Entities;
using ProTrack.DOMAIN.Interfaces.Services;
using static ProTrack.APPLICATION.Helpers.FluentResultHelper;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.DomainConstants;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.ResultMessages;

namespace ProTrack.APPLICATION.Features.Projects.CreateTask;

public class CreateTaskHandler(IProjectService _projectService) : IRequestHandler<CreateTaskRequest, Result>
{
    public async Task<Result> Handle(CreateTaskRequest request, CancellationToken ct)
    {
        var project = await _projectService.GetProjectMembershipAsync(request.ProjectId, ct);

        if (project is null)
            return CreateFailResult(string.Format(NotFound, request.ProjectId), request.ProjectId);

        var newTask = new ProjectTask
        {
            Title = request.Dto.Title,
            Description = request.Dto.Description,
            AssignedToUserId = request.Dto.AssignedToUserId,
            ProjectId = request.ProjectId,
            DueDate = request.Dto.DueDate,
            CreatedByUserId = request.RequestorId
        };

        await _projectService.AddTaskAsync(newTask, ct);
        return Result.Ok();
    }
}
