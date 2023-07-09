using TestIdentity.Dtos;
namespace TestIdentity.Services;

public interface ISaleService
{
    public IEnumerable<SaleBaseDto> GetAll();
    public Task<SaleBaseDto?> GetSaleBySaleId(string userId, int saleId);
    public IEnumerable<SaleBaseDto?> GetSalesByUserId(string userId);
    public Task<SaleBaseDto> Create(string userId, SaleCreateDto dto);
    public Task Delete(string userId, int saleId);
}