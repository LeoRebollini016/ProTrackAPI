using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProTrack.API.Extensions;
using ProTrack.API.Extensions.Infrastructure;
using ProTrack.APPLICATION.Features.Projects;
using ProTrack.DOMAIN.Dtos.Projects;
using ProTrack.DOMAIN.Interfaces;
using static ProTrack.DOMAIN.Constants.AppConstants.EndpointsGroupName;
using static ProTrack.DOMAIN.Constants.AppConstants.SwaggerDocumentation;
namespace ProTrack.API.Endpoints.Projects;

public class ProjectEndpoints : AppEndpointBase
{
    protected override string GroupName => ProjectsGroupName;

    protected override void MapEndpointsGroup(RouteGroupBuilder endpointsGroup)
    {
        endpointsGroup.MapPost("/create", async (
            [FromBody] CreateProjectDto dto,
            IMediator mediator,
            IJwtTokenService jwtService,
            CancellationToken ct) =>
        {
            var user = jwtService.GetCurrentUser();
            var request = new CreateProjectRequest(dto, user!.Id);
            var result = await mediator.Send(request, ct);
        })
            .RequireAuthorization()
            .WithDocumentation(summary: CreateProjectSummary,
                               description: CreateProjectDescription)
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

    }
}