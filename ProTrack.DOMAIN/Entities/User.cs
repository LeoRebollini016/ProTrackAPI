using Microsoft.AspNetCore.Identity;

namespace ProTrack.DOMAIN.Entities;

public class User: IdentityUser<Guid>
{
    public string FullName { get; set; } = string.Empty;
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;

    public virtual ICollection<ProjectUser> ProjectUsers { get; set; } = new List<ProjectUser>();
    public virtual ICollection<ProjectTask> AssignedTasks { get; set; } = new List<ProjectTask>();
}
