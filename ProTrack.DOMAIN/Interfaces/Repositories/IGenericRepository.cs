namespace ProTrack.DOMAIN.Interfaces.Repositories;

public interface IGenericRepository
{
    Task<bool> ExistsAsync(string tableName, string columnName, object values, Guid? excludeId, CancellationToken ct);
}