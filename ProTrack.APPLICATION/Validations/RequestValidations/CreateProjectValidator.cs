using FluentValidation;
using ProTrack.APPLICATION.Features.Projects;
using ProTrack.DOMAIN.Interfaces.Repositories;
using static ProTrack.DOMAIN.Constants.AppConstants.CommonValidationsMessage;
using static ProTrack.DOMAIN.Constants.AppConstants.ProjectConstants;

namespace ProTrack.APPLICATION.Validations.RequestValidations;

public class CreateProjectValidator : AbstractValidator<CreateProjectRequest>
{
    public CreateProjectValidator(IGenericRepository _repository)
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(RequiredField);
        RuleFor(x => x.Dto.Title)
            .MustAsync((title, ct) => ExistsAsync(title, ct, _repository))
            .WithMessage(request => string.Format(TitleAlreadyExist, request.Dto.Title));
    }

    private async Task<bool> ExistsAsync(string title, CancellationToken ct, IGenericRepository repository)
        => await repository.ExistsAsync(ProjectTable, TitleColumn, title, null, ct);
}