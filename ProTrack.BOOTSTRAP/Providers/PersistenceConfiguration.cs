using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ProTrack.DOMAIN.Entities;
using ProTrack.DOMAIN.Interfaces;
using ProTrack.DOMAIN.Interfaces.Repositories;
using ProTrack.DOMAIN.Options;
using ProTrack.INFRAESTRUCTURE.Authentication;
using ProTrack.INFRAESTRUCTURE.Commands;
using ProTrack.INFRAESTRUCTURE.Context;
using ProTrack.INFRAESTRUCTURE.Repositories;
using System.Data;

namespace ProTrack.BOOTSTRAP.Providers;

public static class PersistenceConfiguration
{
    public static void ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AuthenticationOptions>(configuration.GetSection(AuthenticationOptions.SectionName));
        services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.Database));
        services.AddDbContext<ApplicationDbContext>();

        services.AddTransient<IDbConnection>(b =>
        {
            var databaseSettings = b.GetRequiredService<IOptions<DatabaseOptions>>().Value;
            return new Npgsql.NpgsqlConnection(databaseSettings.DefaultConnection);
        });
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddTransient<IGenericRepository, GenericRepository>();
        services.AddTransient<IGenericsCommand, GenericsCommand>();
        services.AddIdentityCore<User>(options =>
                {
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredUniqueChars = 0;
                })
                .AddRoles<Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddSignInManager();
    }
}
