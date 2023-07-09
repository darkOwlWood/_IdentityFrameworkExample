using TestIdentity.Dtos;
using TestIdentity.Models;
using Microsoft.AspNetCore.Identity;
using TestIdentity.Utils.ModulePermissions;
using System.Security.Claims;

namespace TestIdentity.Services;

public class AuthService : IAuthService
{
    private UserManager<UserModel> _userManager { get; init; }
    private SignInManager<UserModel> _signinManager { get; init; }
    public AuthService(UserManager<UserModel> userManager, SignInManager<UserModel> signinManager) =>
    (_userManager, _signinManager) = (userManager, signinManager);

    public async Task<bool> Signin(UserSigninDto dto)
    {
        var claimList = Enum
            .GetNames<Module>()
            .ToList()
            .Select(name => new Claim(name, ""));

        var user = new UserModel
        {
            UserName = dto.UserName,
            Email = dto.Email,
            Name = dto.Name,
            LastName = dto.LastName,
        };

        var result = await _userManager.CreateAsync(user, dto.Password);
        dto.Password = "";
        await _userManager.AddClaimsAsync(user, claimList);

        return result.Succeeded;
    }

    public async Task<bool> Login(UserLoginDto dto)
    {
        var result = await _signinManager.PasswordSignInAsync(dto.UserName, dto.Password, true, false);
        return result.Succeeded;
    }

    public async Task Logout() => await _signinManager.SignOutAsync();
}