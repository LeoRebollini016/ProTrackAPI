namespace ProTrack.API.Extensions.Infrastructure;

public abstract class EndpointsGroupBase
{
    protected abstract string GroupName { get; }
    protected abstract string SwaggerDocName { get; }

    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        var routeGroupBuilder = CreateRouteGroupBuilder(endpoints);
        ConfigureOpenApi(routeGroupBuilder);
        MapEndpointsGroup(routeGroupBuilder);
    }
    protected abstract string BuildRoutesPrefix(string groupName);
    protected abstract void MapEndpointsGroup(RouteGroupBuilder endpointsGroup);

    private RouteGroupBuilder CreateRouteGroupBuilder(IEndpointRouteBuilder endpoints)
    {
        var routesPrefix = BuildRoutesPrefix(GroupName);
        return endpoints.MapGroup(routesPrefix);
    }
    private void ConfigureOpenApi(RouteGroupBuilder endpointsGroup)
    {
        endpointsGroup
            .WithTags(GroupName)
            .WithGroupName(SwaggerDocName);
    }
}
