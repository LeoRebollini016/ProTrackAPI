using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProTrack.APPLICATION.Services;
using ProTrack.APPLICATION.Validations;
using ProTrack.DOMAIN.Interfaces.Services;
using System.Reflection;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.AssembliesConstants;

namespace ProTrack.BOOTSTRAP.Providers;

public static class ApplicationConfiguration
{
    public static void ConfigureApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddValidatorsFromAssembly(Assembly.Load(Application));
        ValidatorOptions.Global.PropertyNameResolver = (type, memberInfo, expression) => memberInfo?.Name;

        services.AddMediatR(cfg => {
            cfg.RegisterServicesFromAssembly(Assembly.Load(Application));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });
        services.AddTransient<IProjectService, ProjectService>();
        services.AddAutoMapper(cfg => { }, Assembly.Load(Application));
    }
}
