namespace ProTrack.API.Extensions;

public static class SwaggerExtensions
{
    public static RouteHandlerBuilder WithDocumentation(this RouteHandlerBuilder builder, string summary, string description)
        => builder.WithOpenApi(op =>
        {
            op.Summary = summary;
            op.Description = description;
            return op;
        });
}