using FluentResults;
using MediatR;
using ProTrack.DOMAIN.Enum;

namespace ProTrack.APPLICATION.Features.Projects.UpdateMemberRole;

public record UpdateMemberRoleRequest(Guid ProjectId, Guid TargetUserId, Guid UserId, ProjectUserRoleEnum NewRole) : IRequest<Result>;
