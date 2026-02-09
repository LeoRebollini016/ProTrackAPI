using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ProTrack.DOMAIN.Entities;
using ProTrack.DOMAIN.Interfaces;
using static ProTrack.APPLICATION.Helpers.FluentResultHelper;
using static ProTrack.DOMAIN.Constants.AppConstants.ResultMessages;

namespace ProTrack.APPLICATION.Features.Auth.Login;

public class LoginHandler(SignInManager<User> _signInManager, UserManager<User> _userManager, IJwtTokenService _tokenService) : IRequestHandler<LoginRequest, Result<LoginResponse>>
{
    public async Task<Result<LoginResponse>> Handle(LoginRequest request, CancellationToken ct)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user is null)
            return CreateFailResult<LoginResponse>(InvalidCredentials, null);

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);

        if (!result.Succeeded)
            return CreateFailResult<LoginResponse>(InvalidCredentials, null);

        var roles = await _userManager.GetRolesAsync(user);
        var token = _tokenService.TokenGenerate(user, roles);

        return Result.Ok(new LoginResponse
        (
            user.Id,
            user.Email!,
            user.UserName!,
            token,
            roles.ToList()
        ));
    }
}