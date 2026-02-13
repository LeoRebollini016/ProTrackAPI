using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.ExceptionMessages;

namespace ProTrack.BOOTSTRAP.Middlewares;

public class GlobalExceptionMiddleware(RequestDelegate _next, ILogger<GlobalExceptionMiddleware> _logger, IWebHostEnvironment env)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, UnexpectedError, ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var message = env.IsDevelopment()
            ? ex.Message
            : UnexpectedError;

        var response = new ProblemDetails
        {
            Status = (int)HttpStatusCode.InternalServerError,
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Title = "Error Interno del Servidor",
            Detail = message
        };
        response.Extensions["stackTrace"] = env.IsDevelopment() ? ex.StackTrace : null;
        var json = JsonSerializer.Serialize(response);

        return context.Response.WriteAsync(json);
    }
}
