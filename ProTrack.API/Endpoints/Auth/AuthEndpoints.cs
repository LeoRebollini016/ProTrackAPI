using ProTrack.API.Extensions.Infrastructure;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.EndpointsGroupName;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.SwaggerDocumentation;
using ProTrack.APPLICATION.Features.Auth.Register;
using ProTrack.APPLICATION.Features.Auth.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProTrack.API.Extensions;

namespace ProTrack.API.Endpoints.Auth;

public class AuthEndpoints : AppEndpointBase
{
    protected override string GroupName => AuthGroupName;

    protected override void MapEndpointsGroup(RouteGroupBuilder endpointsGroup)
    {
        endpointsGroup.MapPost("/register", async (
            [FromBody] RegisterRequest request,
            IMediator mediator,
            HttpContext context,
            CancellationToken ct) =>
            {
                var result = await mediator.Send(request, ct);
                return result.ToHttpResult(context);
            })
            .WithDocumentation(summary: RegisterAuthSummary,
                               description: RegisterAuthDescription)
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

        endpointsGroup.MapPost("/login", async (
            [FromBody] LoginRequest request,
            IMediator mediator,
            HttpContext context,
            CancellationToken ct) =>
        {
            var result = await mediator.Send(request, ct);
            return result.ToHttpResult(context);
        })
        .WithDocumentation(summary: LoginAuthSummary,
                           description: LoginAuthDescription)
        .Produces<LoginResponse>(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest);
    }
}
