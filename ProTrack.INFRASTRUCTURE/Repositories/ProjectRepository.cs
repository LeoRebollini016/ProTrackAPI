using Dapper;
using ProTrack.DOMAIN.Dtos.Projects.Responses;
using ProTrack.DOMAIN.Interfaces.Repositories;
using static ProTrack.DOMAIN.Constants.Queries.ProjectQueries;

namespace ProTrack.INFRASTRUCTURE.Repositories;

public class ProjectRepository(IDbConnectionFactory _factory) : IProjectRepository
{
}
