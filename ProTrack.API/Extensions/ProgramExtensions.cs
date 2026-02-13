using Microsoft.AspNetCore.Http.Json;
using ProTrack.BOOTSTRAP.Providers;
using System.Text.Json.Serialization;
namespace ProTrack.API.Extensions;

public static class ProgramExtensions
{
    public static void ConfigureWebApplicationBuilder(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<JsonOptions>(options =>
        {
            options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
        builder.Services.ConfigurePersistenceServices(builder.Configuration);
        builder.Services.ConfigureApplicationServices(builder.Configuration);
        builder.Services.AddJwtAuthentication();
    }
}
