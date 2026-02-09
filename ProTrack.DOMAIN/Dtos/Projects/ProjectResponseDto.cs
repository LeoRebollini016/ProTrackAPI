namespace ProTrack.DOMAIN.Dtos.Projects;

public class ProjectResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreateAt { get; set; }
    public Guid? CreatedByUserId { get; set; }
    public DateTime? UpdateAt { get; set; }
}