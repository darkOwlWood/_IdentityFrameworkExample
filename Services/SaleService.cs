using Microsoft.EntityFrameworkCore;
using TestIdentity.Dtos;
using TestIdentity.Models;
using TestIdentity.Utils.Extensions;
namespace TestIdentity.Services;

public class SaleService : ISaleService
{
    private DbContextTestIdentity _context { get; init; }
    public SaleService(DbContextTestIdentity context) => _context = context;

    public IEnumerable<SaleBaseDto> GetAll() => _context.Sales.Include(sale => sale.User).ToList().Select(sale => sale.ToDto());

    public async Task<SaleBaseDto?> GetSaleBySaleId(string userId, int saleId)
    {
        var sale = await _context.Sales.Where(sale => sale.SaleModelId == saleId && sale.UserModelId == userId).FirstOrDefaultAsync();
        if (sale is not null)
        {
            await _context.Entry(sale).Reference(sale => sale.User).LoadAsync();
        }
        return sale?.ToDto();
    }

    public IEnumerable<SaleBaseDto> GetSalesByUserId(string userId) =>
        _context.Sales
            .Where(sale => sale.UserModelId == userId)
            .Include(sale => sale.User)
            .ToList()
            .Select(sale => sale.ToDto());

    public async Task<SaleBaseDto> Create(string userId, SaleCreateDto dto)
    {
        var sale = dto.ToModel(userId);
        await _context.Sales.AddAsync(sale);
        await _context.SaveChangesAsync();
        await _context.Sales.Entry(sale).Reference(m => m.User).LoadAsync();
        return sale.ToDto();
    }

    public async Task Delete(string userId, int saleId)
    {
        var sale = await _context.Sales.FindAsync(saleId);
        if (sale is not null && sale.UserModelId == userId)
        {
            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();
        }
    }
}