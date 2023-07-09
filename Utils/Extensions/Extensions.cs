using TestIdentity.Dtos;
using TestIdentity.Models;
namespace TestIdentity.Utils.Extensions;

public static class Extensions
{
    public static SaleBaseDto ToDto(this SaleModel model)
    {
        return new SaleBaseDto
        {
            SaleId = model.SaleModelId,
            ProductName = model.ProductName,
            TotalAmount = model.TotalAmount,
            UserId = model.UserModelId,
            UserName = $"{model.User.Name} {model.User.LastName}",
        };
    }

    public static SaleModel ToModel(this SaleCreateDto dto, string userId)
    {
        return new SaleModel
        {
            UserModelId = userId,
            ProductName = dto.ProductName,
            TotalAmount = dto.TotalAmount,
        };
    }
}