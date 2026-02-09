namespace ProTrack.APPLICATION.Features.Auth.Login;

public record LoginResponse(
    Guid UserId,
    string Email,
    string UserName,
    string Token,
    List<string> Roles
);