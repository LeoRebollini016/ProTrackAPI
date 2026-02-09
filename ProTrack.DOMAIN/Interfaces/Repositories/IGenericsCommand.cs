namespace ProTrack.DOMAIN.Interfaces.Repositories;

public interface IGenericsCommand
{
    Task AddAsync<T>(T entity, CancellationToken ct) where T : class;
    void Update<T>(T entity) where T : class;
    Task SaveChangeAsync(CancellationToken ct);
    void Delete<T>(T entity) where T : class;
}
