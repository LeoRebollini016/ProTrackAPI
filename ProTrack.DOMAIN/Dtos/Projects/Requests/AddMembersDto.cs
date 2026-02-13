using ProTrack.DOMAIN.Enum;

namespace ProTrack.DOMAIN.Dtos.Projects.Requests;

public record AddMembersDto(List<Guid> UserIds);