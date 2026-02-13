using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProTrack.DOMAIN.Entities;
using ProTrack.DOMAIN.Interfaces;
using ProTrack.DOMAIN.Interfaces.Repositories;
using ProTrack.DOMAIN.Options;
using ProTrack.INFRAESTRUCTURE.Authentication;
using ProTrack.INFRAESTRUCTURE.Context;
using ProTrack.INFRAESTRUCTURE.Repositories;
using ProTrack.INFRASTRUCTURE.Commands;
using ProTrack.INFRASTRUCTURE.Repositories;

namespace ProTrack.BOOTSTRAP.Providers;

public static class PersistenceConfiguration
{
    public static void ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AuthenticationOptions>(configuration.GetSection(AuthenticationOptions.SectionName));
        services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.Database));
        services.AddDbContext<ApplicationDbContext>();

        services.AddSingleton<IDbConnectionFactory, DbConnectionFactory>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddTransient<IGenericRepository, GenericRepository>();
        services.AddTransient<IGenericsCommand, GenericsCommand>();
        services.AddTransient<IProjectRepository, ProjectRepository>();
        services.AddTransient<IProjectAggregateRepository, ProjectAggregateRepository>();
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
