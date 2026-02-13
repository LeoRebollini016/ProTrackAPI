using ProTrack.DOMAIN.Enum;

namespace ProTrack.DOMAIN.Entities;

public class ProjectUser
{
    public Guid ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public ProjectUserRoleEnum Role { get; set; } = ProjectUserRoleEnum.Member;
    public bool IsDeleted { get; set; } = false;
}