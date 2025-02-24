using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Grocerie.Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Grocerie.Infrastructure.Auth;

public class AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IOptions<JwtSettings> jwtOptions)
    : IAuthService, IAuthenticationService
{
    private readonly JwtSettings _jwtSettings = jwtOptions.Value;

    public async Task<string?> LoginAsync(string email, string password)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user == null || !await userManager.CheckPasswordAsync(user, password)) return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!)
            ]),
            Expires = DateTime.UtcNow.AddDays(2),
            Issuer = _jwtSettings.Issuer, 
            Audience = _jwtSettings.Audience,
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task<bool> RegisterAsync(string email, string password)
    {
        var user = new User {UserName = email, Email = email};
        var result = await userManager.CreateAsync(user, password);
        if (result.Succeeded) return true;
        var errors = string.Join(", ", result.Errors.Select(e => e.Description));
        throw new Exception($"User registration failed: {errors}");

    }

    public async Task<AuthenticateResult> AuthenticateAsync(HttpContext context, string? scheme)
    {
        var authResult = await context.AuthenticateAsync(scheme ?? JwtBearerDefaults.AuthenticationScheme);
        return authResult;
    }

    public async Task ChallengeAsync(HttpContext context, string? scheme, AuthenticationProperties? properties)
    {
        await context.ChallengeAsync(scheme ?? JwtBearerDefaults.AuthenticationScheme, properties);
    }

    public async Task ForbidAsync(HttpContext context, string? scheme, AuthenticationProperties? properties)
    {
        await context.ForbidAsync(scheme ?? JwtBearerDefaults.AuthenticationScheme, properties);
    }

    public async Task SignInAsync(HttpContext context, string? scheme, ClaimsPrincipal principal, AuthenticationProperties? properties)
    {
        await context.SignInAsync(scheme ?? IdentityConstants.ApplicationScheme, principal, properties);
    }

    public async Task SignOutAsync(HttpContext context, string? scheme, AuthenticationProperties? properties)
    {
        await context.SignOutAsync(scheme ?? IdentityConstants.ApplicationScheme, properties);
    }
}

