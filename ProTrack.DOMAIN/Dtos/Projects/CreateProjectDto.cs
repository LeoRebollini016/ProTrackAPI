namespace ProTrack.DOMAIN.Dtos.Projects;

public class CreateProjectDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid CreatedByUserId { get; set; }
}