using ProTrack.DOMAIN.Dtos.Projects.Responses;
using ProTrack.DOMAIN.Entities;
using ProTrack.DOMAIN.Interfaces.Repositories;
using ProTrack.DOMAIN.Interfaces.Services;

namespace ProTrack.APPLICATION.Services;

public class ProjectService(IGenericsCommand _command, IProjectAggregateRepository _aggregateRepo) : IProjectService
{
    public async Task AddProjectAsync(Project project, CancellationToken ct)
    {
        await _command.AddAsync(project, ct);
        await _command.SaveChangeAsync(ct);
    }
    public async Task AddMembersToProjectAsync(IEnumerable<ProjectUser> projectUsers, CancellationToken ct)
    {
        await _command.AddRangeAsync(projectUsers, ct);
        await _command.SaveChangeAsync(ct);
    }
    public async Task<Project?> GetProjectMembershipAsync(Guid id, CancellationToken ct)
        => await _aggregateRepo.GetByIdWithMembersAsync(id, ct);
    public async Task SaveChangesAsync(CancellationToken ct)
        => await _command.SaveChangeAsync(ct);
}