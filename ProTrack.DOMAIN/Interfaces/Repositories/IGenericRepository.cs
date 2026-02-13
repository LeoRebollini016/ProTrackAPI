namespace ProTrack.DOMAIN.Interfaces.Repositories;

public interface IGenericRepository
{
    Task<bool> ExistsAsync<T>(string tableName, string columnName, T[] values, Guid? excludeId, CancellationToken ct);
}