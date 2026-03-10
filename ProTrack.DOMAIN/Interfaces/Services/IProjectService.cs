using ProTrack.DOMAIN.Dtos.Projects.Responses;
using ProTrack.DOMAIN.Entities;

namespace ProTrack.DOMAIN.Interfaces.Services;

public interface IProjectService
{
    Task AddMembersToProjectAsync(IEnumerable<ProjectUser> projectUsers, CancellationToken ct);
    Task AddProjectAsync(Project project, CancellationToken ct);
    Task AddTaskAsync(ProjectTask task, CancellationToken ct);
    Task<Project?> GetProjectMembershipAsync(Guid id, CancellationToken ct);
    Task SaveChangesAsync(CancellationToken ct);
}