using ProTrack.DOMAIN.Dtos.Users;
using ProTrack.DOMAIN.Entities;

namespace ProTrack.DOMAIN.Interfaces;

public interface IJwtTokenService
{
    UserAuthenticated? GetCurrentUser();
    string TokenGenerate(User user, IEnumerable<string> roles);
}
