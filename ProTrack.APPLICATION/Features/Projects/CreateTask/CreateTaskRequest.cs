using FluentResults;
using MediatR;
using ProTrack.DOMAIN.Dtos.Projects.Requests;

namespace ProTrack.APPLICATION.Features.Projects.CreateTask;

public record CreateTaskRequest(Guid ProjectId, Guid RequestorId, CreateTaskDto Dto) : IRequest<Result>;
