using FluentValidation;
using ProTrack.APPLICATION.Features.Projects.UpdateMemberRole;
using ProTrack.DOMAIN.Enum;
using ProTrack.DOMAIN.Interfaces.Repositories;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.ResultMessages;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.ValidationMessages;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.ProjectConstants;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.AuthConstants;

namespace ProTrack.APPLICATION.Validations.RequestValidations;

public class UpdateMemberRoleValidator : AbstractValidator<UpdateMemberRoleRequest>
{
    public UpdateMemberRoleValidator(IGenericRepository repository)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;
        RuleFor(x => x.ProjectId)
            .NotEmpty().WithMessage(RequiredField)
            .MustAsync((request, targetId, userId, ct) => Exists(ProjectTable, [request.ProjectId], ct, repository))
            .WithMessage(x => string.Format(NotFound, x.ProjectId));

        RuleFor(x => x.TargetUserId)
            .NotEmpty().WithMessage(RequiredField)
            .MustAsync((request, targetId, userId, ct) => Exists(UserTable, [request.TargetUserId], ct, repository))
            .WithMessage(x => string.Format(NotFound, x.TargetUserId));

        RuleFor(x => x.NewRole)
            .NotEmpty().WithMessage(RequiredField)
            .IsInEnum().WithMessage(InvalidFormat)
            .NotEqual(ProjectUserRoleEnum.Owner)
            .WithMessage(ProjectNonTransferable);
    }
    private async Task<bool> Exists(string table, Guid[] value, CancellationToken ct, IGenericRepository repository)
        => await repository.ExistsAsync(table, "id", value, null, ct);
}
