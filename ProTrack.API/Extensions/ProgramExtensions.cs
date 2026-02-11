using ProTrack.BOOTSTRAP.Providers;
namespace ProTrack.API.Extensions;

public static class ProgramExtensions
{
    public static void ConfigureWebApplicationBuilder(this WebApplicationBuilder builder)
    {
        builder.Services.ConfigurePersistenceServices(builder.Configuration);
        builder.Services.AddJwtAuthentication();
        builder.Services.ConfigureApplicationServices(builder.Configuration);
    }
}
