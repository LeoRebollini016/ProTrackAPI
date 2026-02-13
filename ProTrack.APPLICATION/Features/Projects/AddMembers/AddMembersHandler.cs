using FluentResults;
using MediatR;
using ProTrack.DOMAIN.Entities;
using ProTrack.DOMAIN.Enum;
using ProTrack.DOMAIN.Interfaces.Services;
using static ProTrack.APPLICATION.Helpers.FluentResultHelper;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.ResultMessages;

namespace ProTrack.APPLICATION.Features.Projects.AddMembers;

public class AddMembersHandler(IProjectService _projectService) : IRequestHandler<AddMembersRequest, Result>
{
    public async Task<Result> Handle(AddMembersRequest request, CancellationToken ct)
    {
        var project = await _projectService.GetProjectMembershipAsync(request.ProjectId, ct);

        if(project is null)
            return CreateFailResult(string.Format(NotFound, request.ProjectId), request.ProjectId);

        var requestor = project.ProjectUsers.FirstOrDefault(m => m.UserId == request.UserId);
        if (requestor is null || (requestor.Role != ProjectUserRoleEnum.Owner && requestor.Role != ProjectUserRoleEnum.Admin))
            return CreateFailResult(UnauthorizedAction, null);

        foreach (var userId in request.Dto.UserIds)
        {
            var member = project.ProjectUsers.FirstOrDefault(m => m.UserId == userId);

            if (member is null)
            {
                project.ProjectUsers.Add(new ProjectUser
                {
                    ProjectId = request.ProjectId,
                    UserId = userId,
                    Role = ProjectUserRoleEnum.Member,
                    IsDeleted = false
                });
            }
            else if (member.IsDeleted)
            {
                member.IsDeleted = false;
                member.Role = ProjectUserRoleEnum.Member;
            }
        }
        await _projectService.SaveChangesAsync(ct);
        return Result.Ok();
    }
}
