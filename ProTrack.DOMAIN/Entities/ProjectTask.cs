using ProTrack.DOMAIN.Common;

namespace ProTrack.DOMAIN.Entities;

public class ProjectTask : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskStatus Status { get; set; } = TaskStatus.ToDo;
    public TaskPriority Priority { get; set; } = TaskPriority.Medium;
    public DateTimeOffset? DueDate { get; set; }

    public Guid ProjectId { get; set; }
    public virtual Project Project { get; set; } = null!;
    public Guid? AssignedToUserId { get; set; }
    public virtual User? AssignedToUser { get; set; } = null!;
}
public enum TaskStatus
{
    ToDo,
    InProgress,
    Review,
    Done
}
public enum TaskPriority
{
    None = 0,
    Low,
    Medium,
    High,
    Urgent
}
