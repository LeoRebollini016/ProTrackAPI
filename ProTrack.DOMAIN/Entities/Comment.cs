using ProTrack.DOMAIN.Common;

namespace ProTrack.DOMAIN.Entities;

public class Comment: BaseEntity
{
    public string Content { get; set; } = string.Empty;
    
    public Guid TaskId { get; set; }
    public virtual ProjectTask Task { get; set; } = null!;
    public Guid UserId { get; set; }
    public virtual User User { get; set; } = null!;
}
