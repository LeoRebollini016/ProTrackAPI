using static ProTrack.DOMAIN.Constants.GenericQuery;
namespace ProTrack.INFRAESTRUCTURE.Extensions;

public static class SqlGenericExtensions
{
    public static string AddExcludeIdConditionQuery(this string query, Guid? excludeId)
        => excludeId.HasValue
            ? query.Replace(ExcludeIdConditionString, ExcludeIdCondition)
            : query;
}
