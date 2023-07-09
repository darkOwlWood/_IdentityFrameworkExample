using TestIdentity.Dtos;
using TestIdentity.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace TestIdentity.Controller;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private IUserService _service { get; init; }
    public UserController(IUserService service) => _service = service;

    [Authorize]
    [HttpGet("permisions")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        var permissionList = await _service.GetPermisions(userId);
        return Ok(permissionList);
    }

    [Authorize]
    [HttpPut("permisions")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Put(UserClaimsDto dto)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        var permissionList = await _service.UpdatePermisions(userId, dto);
        return Ok(permissionList);
    }
}