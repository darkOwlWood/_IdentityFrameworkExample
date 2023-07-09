using TestIdentity.Models;
namespace TestIdentity.Dtos;

public class SaleBaseDto
{
    public int SaleId { get; set; }
    public string ProductName { get; set; }
    public decimal TotalAmount { get; set; }
    public string UserName { get; set; }
    public string UserId { get; set; }
    public UserModel? User { get; set; }
    public bool? Active { get; set; }
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateTime { get; set; }
}