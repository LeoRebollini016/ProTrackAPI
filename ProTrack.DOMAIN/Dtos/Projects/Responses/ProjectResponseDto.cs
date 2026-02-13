namespace ProTrack.DOMAIN.Dtos.Projects.Responses;

public record ProjectResponseDto(Guid Id, string Title, string Description, DateTime CreateAt, Guid? CreatedByUserId, DateTime? UpdateAt);