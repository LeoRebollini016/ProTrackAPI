using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProTrack.API.Extensions;
using ProTrack.API.Extensions.Infrastructure;
using ProTrack.APPLICATION.Features.Projects.CreateProject;
using ProTrack.APPLICATION.Features.Projects.AddMembers;
using ProTrack.DOMAIN.Dtos.Projects.Requests;
using ProTrack.DOMAIN.Interfaces;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.EndpointsGroupName;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.SwaggerDocumentation;
using ProTrack.APPLICATION.Features.Projects.UpdateMemberRole;
using ProTrack.DOMAIN.Enum;
using ProTrack.APPLICATION.Features.Projects.RemoveMember;
using ProTrack.APPLICATION.Features.Projects.CreateTask;

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
            HttpContext context,
            CancellationToken ct) =>
        {
            var user = jwtService.GetCurrentUser();
            var request = new CreateProjectRequest(dto, user!.Id);
            var result = await mediator.Send(request, ct);
            return result.ToHttpResult(context);
        })
            .RequireAuthorization()
            .WithDocumentation(summary: CreateProjectSummary,
                               description: CreateProjectDescription)
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

        endpointsGroup.MapPost("/{id:guid}/members", async (
            [FromRoute] Guid id,
            [FromBody] AddMembersDto dto,
            IMediator mediator,
            IJwtTokenService jwtService,
            HttpContext context,
            CancellationToken ct) =>
        {
            var user = jwtService.GetCurrentUser();
            var request = new AddMembersRequest(id, user!.Id, dto);
            var result = await mediator.Send(request, ct);

            return result.ToHttpResult(context);
        })
            .RequireAuthorization()
            .WithDocumentation(summary: AddMembersSummary,
                               description: AddMembersDescription)
            .Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);

        endpointsGroup.MapDelete("/{id:guid}/members/{targetUserId:guid}", async (
            [FromRoute] Guid id,
            [FromRoute] Guid targetUserId,
            IMediator mediator,
            IJwtTokenService jwtTokenService,
            HttpContext context,
            CancellationToken ct) =>
        {
            var user = jwtTokenService.GetCurrentUser();
            var request = new RemoveMemberRequest(id, user!.Id, targetUserId);
            var result = await mediator.Send(request, ct);
            return result.ToHttpResult(context);
        })
            .RequireAuthorization()
            .WithDocumentation(summary: RemoveMemberSummary,
                               description: RemoveMemberDescription)
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest);

        endpointsGroup.MapPost("/{id:guid}/members/{targetUserId:guid}/role", async (
            [FromRoute] Guid id,
            [FromRoute] Guid targetUserId,
            [FromBody] ProjectUserRoleEnum role,
            IMediator mediator,
            IJwtTokenService jwtService,
            HttpContext context,
            CancellationToken ct) =>
        {
            var user = jwtService.GetCurrentUser();
            var request = new UpdateMemberRoleRequest(id, targetUserId, user!.Id, role);
            var result = await mediator.Send(request, ct);
            return result.ToHttpResult(context);
        })
            .RequireAuthorization()
            .WithDocumentation(summary: UpdateRoleMemberSummary,
                               description: UpdateRoleMemberDescription)
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest);

        endpointsGroup.MapPost("/{id:guid}/tasks", async (
            [FromRoute] Guid id,
            [FromBody] CreateTaskDto dto,
            IMediator mediator,
            IJwtTokenService jwtService,
            HttpContext context,
            CancellationToken ct) =>
        {
            var user = jwtService.GetCurrentUser();
            var request = new CreateTaskRequest(id, user!.Id, dto);
            var result = await mediator.Send(request, ct);
            return result.ToHttpResult(context);
        })
            .RequireAuthorization()
            .WithDocumentation(summary: CreateTaskSummary,
                               description: CreateTaskDescription)
            .Produces(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

    }
}