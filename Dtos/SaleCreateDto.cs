using System.ComponentModel.DataAnnotations;
namespace TestIdentity.Dtos;

public class SaleCreateDto
{
    [Required]
    [MaxLength(120)]
    public string ProductName { get; set; }
    [Required]
    [Range(1, 99999999)]
    public decimal TotalAmount { get; set; }
}