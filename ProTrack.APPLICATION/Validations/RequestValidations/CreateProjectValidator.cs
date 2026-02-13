using FluentValidation;
using ProTrack.APPLICATION.Features.Projects.CreateProject;
using ProTrack.DOMAIN.Interfaces.Repositories;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.ValidationMessages;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.ProjectConstants;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.ResultMessages;

namespace ProTrack.APPLICATION.Validations.RequestValidations;

public class CreateProjectValidator : AbstractValidator<CreateProjectRequest>
{
    public CreateProjectValidator(IGenericRepository _repository)
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(RequiredField);

        RuleFor(x => x.Dto.Title)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(RequiredField)
            .MustAsync((title, ct) => ExistsAsync([title], ct, _repository))
            .WithMessage(request => string.Format(AlreadyExists, request.Dto.Title));
    }

    private async Task<bool> ExistsAsync(string[] title, CancellationToken ct, IGenericRepository repository)
        => await repository.ExistsAsync(ProjectTable, TitleColumn, title, null, ct);
}