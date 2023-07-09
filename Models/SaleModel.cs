namespace TestIdentity.Models;

public class SaleModel
{
    public int SaleModelId { get; set; }
    public string ProductName { get; set; }
    public decimal TotalAmount { get; set; }
    public string UserModelId { get; set; }
    public UserModel User { get; set; }
    public bool? Active { get; set; }
    public DateTimeOffset CreateDate { get; set; }
    public DateTimeOffset UpdateDate { get; set; }
}