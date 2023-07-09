using System.ComponentModel;
namespace TestIdentity.Utils.ModulePermissions;

public enum Permission
{
    [Description("Create")]
    C,
    [Description("Read")]
    R,
    [Description("Update")]
    U,
    [Description("Delete")]
    D,
}