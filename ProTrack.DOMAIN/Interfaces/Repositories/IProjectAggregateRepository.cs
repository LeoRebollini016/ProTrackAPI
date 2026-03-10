using ProTrack.DOMAIN.Entities;

namespace ProTrack.DOMAIN.Interfaces.Repositories;

public interface IProjectAggregateRepository
{
    Task<Project?> GetByIdWithMembersAsync(Guid id, CancellationToken ct);
}
