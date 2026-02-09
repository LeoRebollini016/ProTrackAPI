using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace ProTrack.INFRAESTRUCTURE.Extensions;

public static class ModelBuilderExtensions
{
    public static void ConfigureIdentityTableNames(this ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            var tableName = entity.GetTableName();
            if (tableName != null && tableName.StartsWith("AspNet"))
            {
                var nameWithoutPrefix = tableName.Replace("AspNet", "");

                var snakeCaseName = ConvertToSnakeCase(nameWithoutPrefix);

                entity.SetTableName(snakeCaseName);
            }
        }
    }
    private static string ConvertToSnakeCase(string input)
        => Regex.Replace(input, @"(?<!^)(?=[A-Z])", "_").ToLower();
}
