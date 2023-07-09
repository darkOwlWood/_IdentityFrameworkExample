using Microsoft.AspNetCore.Identity;
namespace TestIdentity.Models;

public class UserModel : IdentityUser
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public ICollection<SaleModel> SaleModelList { get; set; }
    public bool? Active { get; set; }
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
}