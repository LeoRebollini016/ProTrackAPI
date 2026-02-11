using FluentResults;
using FluentValidation;
using MediatR;

namespace ProTrack.APPLICATION.Validations;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> _validators) : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : ResultBase
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if(!_validators.Any())
            return await next();

        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken))
        );
        var failures = validationResults.SelectMany(r => r.Errors)
                                        .Where(f => f != null)
                                        .ToList();
        if (failures.Count != 0)
        {
            var errors = failures.Select(f => new Error(f.ErrorMessage)
            .WithMetadata("Property", f.PropertyName));

            return CreateErrorResult<TResponse>(errors);
        }
        return await next();
    }

    private static TResponse CreateErrorResult<T>(IEnumerable<IError> errors)
    {
        if(typeof(T) == typeof(Result))
        {
            return (TResponse)(object)Result.Fail(errors);
        }
        var resultType = typeof(T);

        var result = (ResultBase)Activator.CreateInstance(resultType)!;
        result.Reasons.AddRange(errors);

        return (TResponse)result;
    }
}
