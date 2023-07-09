namespace TestIdentity.Utils.ModulePermissions;

public static class ModulePermissions
{
    private static List<Permission> permissionList = Enum.GetValues<Permission>().Cast<Permission>().ToList();
    public static Dictionary<Permission, bool> GetPermissionsFromString(string permisions)
    {
        var permisionsData = new Dictionary<Permission, bool>();
        permissionList.ForEach(permission => permisionsData.Add(permission, permisions.Contains(permission.ToString())));
        return permisionsData;
    }

    public static string GetStringFromPermissions(Dictionary<Permission, bool> permisionsData) =>
        string.Join("", permisionsData.Keys.Select(key => permisionsData[key] ? key.ToString() : ""));
}