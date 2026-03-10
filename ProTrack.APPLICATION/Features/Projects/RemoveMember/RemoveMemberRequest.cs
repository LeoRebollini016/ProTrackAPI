using FluentResults;
using MediatR;

namespace ProTrack.APPLICATION.Features.Projects.RemoveMember;

public record RemoveMemberRequest(Guid ProjectId, Guid RequestorId, Guid TargetUserId): IRequest<Result>;