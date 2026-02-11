using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ProTrack.DOMAIN.Dtos.Users;
using ProTrack.DOMAIN.Entities;
using ProTrack.DOMAIN.Interfaces;
using ProTrack.DOMAIN.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProTrack.INFRAESTRUCTURE.Authentication;

public class JwtTokenService(IOptions<AuthenticationOptions> jwtOptions, IHttpContextAccessor httpContextAccessor) : IJwtTokenService
{
    private readonly AuthenticationOptions _jwtSettings = jwtOptions.Value;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public string TokenGenerate(User user, IEnumerable<string> roles)
    {
        var key = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);
        var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim>
        {
            new("sub", user.Id.ToString()),
            new("email", user.Email!),
            new("jti", Guid.NewGuid().ToString()),
            new("username", user.UserName!)
        };

        claims.AddRange(roles.Select(role => new Claim("role", role)));

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: GetExpiresToken(),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    public UserAuthenticated? GetCurrentUser()
    {
        var user = _httpContextAccessor.HttpContext?.User;

        if (user?.Identity?.IsAuthenticated != true)
            return null;
        
        var idClaim = user.FindFirst(ClaimTypes.NameIdentifier);

        return new UserAuthenticated
        {
            Id = Guid.Parse(idClaim!.Value),
            Email = user.FindFirstValue(ClaimTypes.Email) ?? string.Empty,
            UserName = user.FindFirstValue(ClaimTypes.Name) ?? string.Empty,
            Roles = user.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList()
        };
    }
    private DateTime GetExpiresToken()
        => _jwtSettings.IsDevelopmentMode
            ? DateTime.UtcNow.AddMinutes(_jwtSettings.Expire)
            : DateTime.UtcNow.AddMonths(_jwtSettings.Expire);
}
