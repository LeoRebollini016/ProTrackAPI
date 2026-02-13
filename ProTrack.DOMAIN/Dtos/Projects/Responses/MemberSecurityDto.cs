using ProTrack.DOMAIN.Enum;

namespace ProTrack.DOMAIN.Dtos.Projects.Responses;

public class MemberSecurityDto
{
    public Guid UserId { get; set; }
    public ProjectUserRoleEnum Role { get; set; }
    public bool IsDeleted { get; set; }
}
