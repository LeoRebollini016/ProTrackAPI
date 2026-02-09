using ProTrack.API.Extensions.Infrastructure;

namespace ProTrack.API.Extensions;

public static class EndpointsRegistrationExtensions
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        var endpointTypes = DiscoverEndpointTypes();

        foreach (var type in endpointTypes)
        {
            var instance = (EndpointsGroupBase)ActivatorUtilities.CreateInstance(app.ServiceProvider, type);
            instance.MapEndpoints(app);
        }
    }

    private static IEnumerable<Type> DiscoverEndpointTypes()
        => typeof(EndpointsGroupBase).Assembly
            .GetTypes()
            .Where(t => t is { IsClass: true, IsAbstract: false } &&
                t.IsAssignableTo(typeof(EndpointsGroupBase)));
}