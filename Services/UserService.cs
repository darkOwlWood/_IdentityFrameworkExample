using TestIdentity.Dtos;
using TestIdentity.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using TestIdentity.Utils.ModulePermissions;

namespace TestIdentity.Services;

public class UserService : IUserService
{
    private UserManager<UserModel> _userManager { get; init; }
    public UserService(UserManager<UserModel> userManager) => (_userManager) = (userManager);

    public async Task<UserClaimsDto> GetPermisions(string userId)
    {
        var (user, claimList) = await GetUserClaimList(userId);
        return GetUserClaimsDto(claimList);
    }

    public async Task<UserClaimsDto> UpdatePermisions(string userId, UserClaimsDto dto)
    {
        var (user, claimList) = await GetUserClaimList(userId);
        var (claimsToAdd, claimsToRemove) = GetClaimsToAddAndRemove(dto, claimList);

        var resultRemove = await _userManager.RemoveClaimsAsync(user, claimsToRemove);
        var resultAdd = await _userManager.AddClaimsAsync(user, claimsToAdd);

        return (resultRemove.Succeeded && resultAdd.Succeeded) ?
            GetUserClaimsDto(claimsToAdd.Union(claimList).DistinctBy(claim => claim.Type))
            : GetUserClaimsDto(claimList);
    }

    private async Task<(UserModel, IEnumerable<Claim>)> GetUserClaimList(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var claimList = await _userManager.GetClaimsAsync(user);

        return (user, claimList);
    }

    private static UserClaimsDto GetUserClaimsDto(IEnumerable<Claim> claimList)
    {
        var permissionList = new Dictionary<Module, Dictionary<Permission, bool>>();

        claimList.ToList().ForEach(claim =>
        {
            Module module;
            Enum.TryParse<Module>(claim.Type, out module);
            permissionList.Add(module, ModulePermissions.GetPermissionsFromString(claim.Value));
        });

        return new UserClaimsDto()
        {
            ClaimDictionary = permissionList,
        };
    }

    private static (IEnumerable<Claim>, IEnumerable<Claim>) GetClaimsToAddAndRemove(UserClaimsDto dto, IEnumerable<Claim> claimList)
    {
        var claimsToAdd = dto.ClaimDictionary.Keys
            .ToList()
            .Select(key => new Claim(key.ToString(), ModulePermissions.GetStringFromPermissions(dto.ClaimDictionary[key])));
        var permissionListNames = claimsToAdd.Select(claim => claim.Type);

        var claimsToRemove = claimList
            .Where(claim => permissionListNames.Contains(claim.Type))
            .ToList();

        return (claimsToAdd, claimsToRemove);
    }
}