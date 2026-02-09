using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ProTrack.DOMAIN.Entities;
using static ProTrack.DOMAIN.Constants.AppConstants.ResultMessages;
using static ProTrack.APPLICATION.Helpers.FluentResultHelper;

namespace ProTrack.APPLICATION.Features.Auth.Register;

public class RegisterHandler(UserManager<User> _userManager) : IRequestHandler<RegisterRequest, Result<bool>>
{
    public async Task<Result<bool>> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Email = request.Email,
            UserName = request.UserName,
            FullName = request.FullName,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            return CreateFailResult<bool>(UserCreationFailed, null);

        return Result.Ok(true);
    }
}
