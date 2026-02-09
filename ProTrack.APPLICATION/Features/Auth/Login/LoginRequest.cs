using FluentResults;
using MediatR;

namespace ProTrack.APPLICATION.Features.Auth.Login;

public record LoginRequest(string Email, string Password) : IRequest<Result<LoginResponse>>;