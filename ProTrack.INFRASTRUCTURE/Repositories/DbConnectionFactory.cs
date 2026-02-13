using Microsoft.Extensions.Options;
using ProTrack.DOMAIN.Interfaces.Repositories;
using ProTrack.DOMAIN.Options;
using System.Data;

namespace ProTrack.INFRASTRUCTURE.Repositories;

public class DbConnectionFactory(IOptions<DatabaseOptions> options) : IDbConnectionFactory
{
    public IDbConnection CreateConnection()
        => new Npgsql.NpgsqlConnection(options.Value.DefaultConnection);
}
