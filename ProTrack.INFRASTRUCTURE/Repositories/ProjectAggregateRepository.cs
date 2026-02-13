using Microsoft.EntityFrameworkCore;
using ProTrack.DOMAIN.Entities;
using ProTrack.DOMAIN.Interfaces.Repositories;
using ProTrack.INFRAESTRUCTURE.Context;

namespace ProTrack.INFRASTRUCTURE.Repositories;

public class ProjectAggregateRepository(ApplicationDbContext _context) : IProjectAggregateRepository
{
    public async Task<Project?> GetByIdWithMembersAsync(Guid id, CancellationToken ct)
        => await _context.Projects.Include(p => p.ProjectUsers)
                                  .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted, ct);
}
