using FluentResults;

namespace ProTrack.API.Extensions;

public static class ResultExtensions
{
    public static IResult ToHttpResult<T>(this Result<T> result, HttpContext context)
    {
        if (result.IsFailed)
        {
            return result.Error() is not ExceptionalError
                ? TypedResults.BadRequest(result.Error().Metadata)
                : TypedResults.Problem(
                    detail: result.Error().Message,
                    statusCode: StatusCodes.Status500InternalServerError,
                    title: "Internal Server Error");
        }
        return context.Request.Method switch
        {
            "GET" => result.Value is not null ? TypedResults.Ok(result.Value) : TypedResults.NotFound(),
            "POST" => TypedResults.Created(string.Empty, result.Value),
            "PUT" => TypedResults.NoContent(),
            "DELETE" => TypedResults.NoContent(),
            _ => TypedResults.Ok(result.Value)
        };
    }
    private static IError Error(this ResultBase result) => result.Errors[0];
}