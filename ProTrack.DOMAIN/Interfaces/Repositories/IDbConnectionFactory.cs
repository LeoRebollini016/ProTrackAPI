using System.Data;

namespace ProTrack.DOMAIN.Interfaces.Repositories;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}
