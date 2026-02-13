using FluentResults;
using MediatR;
using ProTrack.DOMAIN.Entities;
using ProTrack.DOMAIN.Interfaces.Services;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.DomainConstants;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.ResultMessages;
using static ProTrack.APPLICATION.Helpers.FluentResultHelper;

namespace ProTrack.APPLICATION.Features.Projects.UpdateMemberRole;

public class UpdateMemberRoleHandler(IProjectService _projectService) : IRequestHandler<UpdateMemberRoleRequest, Result>
{
    public async Task<Result> Handle(UpdateMemberRoleRequest request, CancellationToken ct)
    {
        var project = await _projectService.GetProjectMembershipAsync(request.ProjectId, ct);

        var error = project!.UpdateMemberRole(request.UserId, request.TargetUserId, request.NewRole);

        if (error is EntityNotFound)
            return CreateFailResult(string.Format(NotFound, request.ProjectId), null);

        if (error is CompletedProject)
            return CreateFailResult(CompletedProject, null);

        await _projectService.SaveChangesAsync(ct);
        return Result.Ok();
    }
}
