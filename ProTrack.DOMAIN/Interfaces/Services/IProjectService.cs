using ProTrack.DOMAIN.Entities;

namespace ProTrack.DOMAIN.Interfaces.Services;

public interface IProjectService
{
    Task AddProjectAsync(Project project, CancellationToken ct);
}
