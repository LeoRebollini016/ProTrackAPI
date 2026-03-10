namespace ProTrack.DOMAIN.Dtos.Projects.Requests;

public record CreateTaskDto(string Title, string Description, Guid? AssignedToUserId, DateTimeOffset? DueDate);
