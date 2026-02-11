using ProTrack.DOMAIN.Entities;
using ProTrack.DOMAIN.Interfaces.Repositories;
using ProTrack.DOMAIN.Interfaces.Services;

namespace ProTrack.APPLICATION.Services;

public class ProjectService(IGenericsCommand _command) : IProjectService
{
    public async Task AddProjectAsync(Project project, CancellationToken ct)
    {
        await _command.AddAsync(project, ct);
        await _command.SaveChangeAsync(ct);
    }
}