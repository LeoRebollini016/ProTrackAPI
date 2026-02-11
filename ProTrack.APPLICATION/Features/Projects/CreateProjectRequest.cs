using FluentResults;
using MediatR;
using ProTrack.DOMAIN.Dtos.Projects;

namespace ProTrack.APPLICATION.Features.Projects;

public record CreateProjectRequest(CreateProjectDto Dto, Guid UserId) : IRequest<Result>;