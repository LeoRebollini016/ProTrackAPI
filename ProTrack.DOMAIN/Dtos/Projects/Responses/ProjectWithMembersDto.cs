namespace ProTrack.DOMAIN.Dtos.Projects.Responses;

public record ProjectWithMembersDto(Guid Id, string Title, string Description, string Status, DateTime? TargetDate, List<Guid> Members);
