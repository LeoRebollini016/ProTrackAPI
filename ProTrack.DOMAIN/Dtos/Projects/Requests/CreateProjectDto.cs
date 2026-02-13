namespace ProTrack.DOMAIN.Dtos.Projects.Requests;

public record CreateProjectDto(string Title, string Description, DateTime? TargetDate, Guid CreatedByUserId);