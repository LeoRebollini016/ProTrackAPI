using static ProTrack.DOMAIN.Constants.Constants.AppConstants.SwaggerDocs;

namespace ProTrack.API.Extensions.Infrastructure;

public abstract class AppEndpointBase : EndpointsGroupBase
{
    protected virtual string Version => DocName;
    protected override string SwaggerDocName => Version;
    protected override string BuildRoutesPrefix(string groupName)
        => $"api/{Version}/{groupName}";
}