using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProTrack.DOMAIN.Options;
using System.Text;

namespace ProTrack.BOOTSTRAP.Providers;

public static class AuthorizationConfiguration
{
    public static void AddJwtAuthentication(this IServiceCollection services)
    {
        var jwtSettings = services.BuildServiceProvider().GetRequiredService<IOptions<AuthenticationOptions>>().Value;
        var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);
        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });
    }
}
