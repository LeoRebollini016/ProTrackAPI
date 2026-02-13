using FluentResults;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.ResultMessages;

namespace ProTrack.APPLICATION.Helpers;

public static class FluentResultHelper
{
    public static Result CreateFailResult(string message, object? fieldName)
        => Result.Fail(new Error(InvalidMessage).WithMetadata(MetadataName, $"Property: {fieldName}, Errors: {message}"));
    public static Result<T> CreateFailResult<T>(string message, object? fieldName)
        => Result.Fail<T>(new Error(InvalidMessage).WithMetadata(MetadataName, $"Property: {fieldName}, Errors: {message}"));
}