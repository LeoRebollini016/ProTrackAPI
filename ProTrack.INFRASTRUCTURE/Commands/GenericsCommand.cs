using ProTrack.DOMAIN.Interfaces.Repositories;
using ProTrack.INFRAESTRUCTURE.Context;

namespace ProTrack.INFRASTRUCTURE.Commands;

public class GenericsCommand(ApplicationDbContext context) : IGenericsCommand
{
    private readonly ApplicationDbContext _context = context;

    public async Task AddAsync<T>(T entity, CancellationToken ct) where T : class
        => await _context.AddAsync(entity, ct);
    public async Task AddRangeAsync<T>(IEnumerable<T> entities, CancellationToken ct) where T : class
        => await _context.Set<T>().AddRangeAsync(entities, ct);
    public async Task SaveChangeAsync(CancellationToken ct)
        => await _context.SaveChangesAsync(ct);
    public void Delete<T>(T entity) where T : class
        => _context.Remove(entity);
}
