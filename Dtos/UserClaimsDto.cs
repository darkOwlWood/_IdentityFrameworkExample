using TestIdentity.Utils.ModulePermissions;
namespace TestIdentity.Dtos;

public class UserClaimsDto
{
    public Dictionary<Module, Dictionary<Permission, bool>> ClaimDictionary { get; set; }
}