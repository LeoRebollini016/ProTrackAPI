namespace ProTrack.DOMAIN.Common;

public abstract class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    public Guid? CreatedByUserId { get; set; }
    public DateTime? UpdateAt { get; set; }
    public bool IsDeleted { get; set; } = false;
}
