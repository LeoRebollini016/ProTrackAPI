using ProTrack.DOMAIN.Entities;

namespace ProTrack.DOMAIN.Interfaces.Repositories;

public interface IProjectAggregateRepository
{
    /// <summary>
    /// Obtieene el proyecto con sus miembros cargados para permitir modificaciones de estado.
    /// </summary>
    Task<Project?> GetByIdWithMembersAsync(Guid id, CancellationToken ct);
}
