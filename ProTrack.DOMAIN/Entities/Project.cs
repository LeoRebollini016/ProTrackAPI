using ProTrack.DOMAIN.Common;

namespace ProTrack.DOMAIN.Entities;

public class Project : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public virtual ICollection<ProjectUser> ProjectUsers { get; set; } = new List<ProjectUser>();
    public virtual ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
}
