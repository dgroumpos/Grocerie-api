using Grocerie.Application.DTOs;
using Grocerie.Infrastructure.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Grocerie.API.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var result = await authService.RegisterAsync(request.Email, request.Password);
        return result ? Ok("User registered successfully") : BadRequest("User registration failed");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var token = await authService.LoginAsync(request.Email, request.Password);
        return token != null ? Ok(new { Token = token }) : BadRequest("Invalid credentials");
    }
}