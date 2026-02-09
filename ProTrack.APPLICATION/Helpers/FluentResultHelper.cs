using FluentResults;
using static ProTrack.DOMAIN.Constants.AppConstants.ResultMessages;

namespace ProTrack.APPLICATION.Helpers;

public static class FluentResultHelper
{
    public static Result<T> CreateFailResult<T>(string message, object? fieldName)
        => Result.Fail<T>(new Error(InvalidMessage).WithMetadata(MetadataName, $"Property: {fieldName}, Errors: {message}"));
}