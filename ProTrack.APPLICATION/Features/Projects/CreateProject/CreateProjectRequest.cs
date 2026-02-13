using FluentResults;
using MediatR;
using ProTrack.DOMAIN.Dtos.Projects.Requests;

namespace ProTrack.APPLICATION.Features.Projects.CreateProject;

public record CreateProjectRequest(CreateProjectDto Dto, Guid UserId) : IRequest<Result>;