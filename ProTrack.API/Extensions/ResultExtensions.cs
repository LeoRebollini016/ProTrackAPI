using FluentResults;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.ResultMessages;

namespace ProTrack.API.Extensions;

/// <summary>
/// Extensión de métodos para convertir objetos Result y Result<T> en respuestas HTTP apropiadas para una API RESTful.
/// </summary>
public static class ResultExtensions
{
    public static IResult ToHttpResult(this Result result, HttpContext context)
    {
        if (result.IsFailed)
        {
            return HandleFailure(result);
        }
        return context.Request.Method switch
        {
            "GET" => TypedResults.Ok(),
            "POST" => TypedResults.Created(string.Empty),
            "PUT" or "DELETE" => TypedResults.NoContent(),
            _ => TypedResults.Ok()
        };

    }
    public static IResult ToHttpResult<T>(this Result<T> result, HttpContext context)
    {
        if (result.IsFailed)
        {
            return HandleFailure(result);
        }
        return context.Request.Method switch
        {
            "GET" => result.Value is not null ? TypedResults.Ok(result.Value) : TypedResults.NotFound(),
            "POST" => TypedResults.Created(string.Empty, result.Value),
            "PUT" or "DELETE" => TypedResults.NoContent(),
            _ => TypedResults.Ok(result.Value)
        };
    }

    private static IResult HandleFailure(ResultBase result)
        => result.Error() is not ExceptionalError
            ? TypedResults.BadRequest(new
            {
                Title = InvalidMessage,
                Status = StatusCodes.Status400BadRequest,
                Errors = GetErrorDetails(result.Errors)
            })
            : TypedResults.Problem(
                detail: result.Error().Message,
                statusCode: StatusCodes.Status500InternalServerError,
                title: "Internal Server Error");

    private static IEnumerable<object> GetErrorDetails(IEnumerable<IError> errors)
        => errors.Select(e => new
        {
            Property = e.Metadata.TryGetValue("Property", out var prop) ? prop : null,
            Message = e.Message
        });
    public static IError Error(this ResultBase result) => result.Errors[0];
}