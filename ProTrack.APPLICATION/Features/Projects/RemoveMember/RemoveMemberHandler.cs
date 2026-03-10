using FluentResults;
using MediatR;
using ProTrack.DOMAIN.Interfaces.Services;
using static ProTrack.APPLICATION.Helpers.FluentResultHelper;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.ResultMessages;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.DomainConstants;


namespace ProTrack.APPLICATION.Features.Projects.RemoveMember;

public class RemoveMemberHandler(IProjectService _projectService) : IRequestHandler<RemoveMemberRequest, Result>
{
    public async Task<Result> Handle(RemoveMemberRequest request, CancellationToken ct)
    {
        var project = await _projectService.GetProjectMembershipAsync(request.ProjectId, ct);

        var error = project!.RemoveMember(request.RequestorId, request.TargetUserId);

        if (error is EntityNotFound)
            return CreateFailResult(NotFound, request.TargetUserId);
        if (error is UnauthorizedAction)
            return CreateFailResult(UnauthorizedAction, null);

        await _projectService.SaveChangesAsync(ct);
        return Result.Ok();
    }
}
