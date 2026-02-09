using Dapper;
using ProTrack.DOMAIN.Interfaces.Repositories;
using ProTrack.INFRAESTRUCTURE.Extensions;
using System.Data;
using static ProTrack.DOMAIN.Constants.GenericQuery;

namespace ProTrack.INFRAESTRUCTURE.Repositories;

public class GenericRepository : IGenericRepository
{
    private readonly IDbConnection _connection;

    public GenericRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<bool> ExistsAsync(string tableName, string columnName, object values, Guid? exclusedId, CancellationToken ct)
    {
        var query = GenericExistQuery.AddExcludeIdConditionQuery(exclusedId);

        var sql = string.Format(query, tableName, columnName, exclusedId);

        return await _connection.QueryFirstOrDefaultAsync<bool>(new CommandDefinition(
            sql,
            new { Values = values },
            cancellationToken: ct
        ));
    }
}
