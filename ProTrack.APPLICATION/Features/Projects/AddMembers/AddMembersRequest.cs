using FluentResults;
using MediatR;
using ProTrack.DOMAIN.Dtos.Projects.Requests;

namespace ProTrack.APPLICATION.Features.Projects.AddMembers;

public record AddMembersRequest(Guid ProjectId, Guid UserId, AddMembersDto Dto) : IRequest<Result>;
