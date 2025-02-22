using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Grocerie.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Grocerie.Infrastructure.Auth;

public class AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IOptions<JwtSettings> jwtOptions)
    : IAuthService
{
    private readonly JwtSettings _jwtSettings = jwtOptions.Value;
    public async Task<string?> LoginAsync(string email, string password)
    {
        var user = await userManager.FindByEmailAsync(email);
        if (user == null || await userManager.CheckPasswordAsync(user, password)) return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity([
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email!)
            ]),
            Expires = DateTime.UtcNow.AddDays(2),
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
        return result.Succeeded;
    }
}