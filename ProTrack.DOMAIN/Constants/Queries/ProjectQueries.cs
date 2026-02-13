namespace ProTrack.DOMAIN.Constants.Queries;

public static class ProjectQueries
{
    public const string GetProjectMembershipQuery = @"
        SELECT
            pu.user_id AS UserId,
            pu.role AS Role,
            pu.is_deleted AS IsDeleted
        FROM projects p
        INNER JOIN project_users pu ON p.id = pu.project_id
        WHERE p.id = @ProjectId AND p.is_deleted = false;
    ";
    public const string UpdateProjectMembersToActiveQuery = @"
        UPDATE project_users
        SET is_deleted = false
        WHERE project_id = @ProjectId AND user_id = ANY(@UserIds);
    ";
}
