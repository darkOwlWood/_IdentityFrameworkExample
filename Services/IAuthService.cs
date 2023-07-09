using TestIdentity.Dtos;
namespace TestIdentity.Services;

public interface IAuthService
{
    Task<bool> Signin(UserSigninDto dto);
    Task<bool> Login(UserLoginDto dto);
    Task Logout();
}