using Dapper;
using ProTrack.DOMAIN.Interfaces.Repositories;
using ProTrack.INFRAESTRUCTURE.Extensions;
using static ProTrack.DOMAIN.Constants.Queries.GenericQuery;

namespace ProTrack.INFRAESTRUCTURE.Repositories;

public class GenericRepository(IDbConnectionFactory _factory) : IGenericRepository
{
    public async Task<bool> ExistsAsync<T>(string tableName, string columnName, T[] values, Guid? exclusedId, CancellationToken ct)
    {
        var valuesArray = values.ToArray();
        using var _conn = _factory.CreateConnection();
        var query = GenericExistQuery.AddExcludeIdConditionQuery(exclusedId);

        var sql = string.Format(query, tableName, columnName, exclusedId);

        var count = await _conn.QueryFirstOrDefaultAsync<int>(new CommandDefinition(
            sql,
            new { Values = valuesArray },
            cancellationToken: ct
        ));

        return count >= values.Distinct().Count();
    }
}