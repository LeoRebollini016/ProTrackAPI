using FluentResults;
using MediatR;

namespace ProTrack.APPLICATION.Features.Auth.Register;

public record RegisterRequest(string Email, string Password, string UserName, string FullName) : IRequest<Result<bool>>;