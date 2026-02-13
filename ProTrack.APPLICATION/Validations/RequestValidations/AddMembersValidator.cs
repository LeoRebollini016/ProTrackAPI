using FluentValidation;
using ProTrack.APPLICATION.Features.Projects.AddMembers;
using ProTrack.DOMAIN.Interfaces.Repositories;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.ResultMessages;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.ValidationMessages;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.ProjectConstants;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.AuthConstants;

namespace ProTrack.APPLICATION.Validations.RequestValidations;

public class AddMembersValidator : AbstractValidator<AddMembersRequest>
{
    public AddMembersValidator(IGenericRepository repository)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x.ProjectId)
            .NotEmpty().WithMessage(RequiredField)
            .MustAsync((projectId, ct) => ExistAsync(ProjectTable, [projectId], ct, repository))
            .WithMessage(x => string.Format(NotFound, x.ProjectId));

        RuleFor(x => x.Dto.UserIds)
            .NotEmpty().WithMessage(RequiredField)
            .MustAsync((request, userIds, ct) => ExistAsync(UserTable, userIds.ToArray(), ct, repository))
            .WithMessage(UserNotExist);

        RuleFor(x => x.Dto.UserIds)
            .NotEmpty().WithMessage(RequiredField)
            .Must(ids => ids.Distinct().Count() == ids.Count())
            .WithMessage(x => string.Format(DuplicateInList, nameof(x.Dto.UserIds)));
    }
    private async Task<bool> ExistAsync(string table, Guid[] values, CancellationToken ct, IGenericRepository repository)
        => await repository.ExistsAsync(table, "id", values, null, ct);
}
