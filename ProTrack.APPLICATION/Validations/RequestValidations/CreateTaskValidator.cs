using FluentValidation;
using ProTrack.APPLICATION.Features.Projects.CreateTask;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.ValidationMessages;

namespace ProTrack.APPLICATION.Validations.RequestValidations;

public class CreateTaskValidator : AbstractValidator<CreateTaskRequest>
{
    public CreateTaskValidator()
    {
        RuleFor(x => x.ProjectId)
            .NotEmpty()
            .WithMessage(RequiredField);

        RuleFor(x => x.RequestorId)
            .NotEmpty()
            .WithMessage(RequiredField);

        RuleFor(x => x.Dto.Title)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(RequiredField)
            .MaximumLength(100).WithMessage(MaxLength);

        RuleFor(x => x.Dto.Description)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage(RequiredField)
            .MaximumLength(500).WithMessage(MaxLength);

        RuleFor(x => x.Dto.DueDate)
            .GreaterThan(DateTimeOffset.UtcNow)
            .When(x => x.Dto.DueDate.HasValue)
            .WithMessage("La fecha de vencimiento debe ser futura.");
    }
}
