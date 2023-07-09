using TestIdentity.Dtos;
namespace TestIdentity.Services;

public interface IUserService
{
    Task<UserClaimsDto> GetPermisions(string userId);
    Task<UserClaimsDto> UpdatePermisions(string userId, UserClaimsDto dto);
}