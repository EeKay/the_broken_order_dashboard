using Microsoft.AspNetCore.Mvc;
using OrderDashboard.Api.Models;
using OrderDashboard.Api.Services;

namespace OrderDashboard.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        var result = _authService.Login(request.Email, request.Password);
        if (result is null)
        {
            return Unauthorized(new { message = "Ongeldige combinatie van e-mail en wachtwoord." });
        }

        return Ok(result);
    }
}
