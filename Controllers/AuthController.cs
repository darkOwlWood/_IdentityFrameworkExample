using TestIdentity.Dtos;
using TestIdentity.Services;
using Microsoft.AspNetCore.Mvc;
namespace TestIdentity.Controller;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private IAuthService _service { get; init; }
    public AuthController(IAuthService service) => _service = service;

    [HttpPost("signin")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Signin(UserSigninDto dto)
    {
        var result = await _service.Signin(dto);
        return result ? Created("", null) : BadRequest();
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login(UserLoginDto dto)
    {
        var result = await _service.Login(dto);
        return result ? Ok() : Unauthorized();
    }

    [HttpPost("logout")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Logout()
    {
        await _service.Logout();
        return NoContent();
    }
}