namespace ProTrack.DOMAIN.Constants;

public static class GenericQuery
{
    public const string GenericExistQuery = @"
        SELECT EXISTS(
            SELECT 1
            FROM {0}
            WHERE {1} = ANY(@Values)" +
            "\n --ExcludeIdCondition \n " +
        ");";

    public const string ExcludeIdCondition = "AND Id <> '{2}'";
    public const string ExcludeIdConditionString = "--ExcludeIdCondition";
}
