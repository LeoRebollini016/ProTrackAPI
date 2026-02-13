namespace ProTrack.DOMAIN.Dtos.Users;

public record UserAuthenticated(Guid Id, string Email, string UserName, List<string> Roles);