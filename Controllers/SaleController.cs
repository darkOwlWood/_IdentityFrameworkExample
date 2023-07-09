using TestIdentity.Dtos;
using TestIdentity.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace TestIdentity.Controller;

[ApiController]
[Route("[controller]")]
public class SaleController : ControllerBase
{
    private ISaleService _service { get; init; }
    public SaleController(ISaleService service) => _service = service;

    // [Authorize]
    // [HttpGet("all")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // public IActionResult GetAll() => Ok(_service.GetAll());

    [Authorize]
    [HttpGet("{saleId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSaleById(int saleId)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        var sale = await _service.GetSaleBySaleId(userId, saleId);
        return sale is not null ? Ok(sale) : NotFound();
    }

    [Authorize]
    [HttpGet("user")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetSalesByUser() => Ok(_service.GetSalesByUserId(User.FindFirst(ClaimTypes.NameIdentifier).Value));

    [Authorize]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Post(SaleCreateDto dto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var sale = await _service.Create(userId, dto);
        return CreatedAtAction(
            nameof(GetSaleById),
            new { saleId = sale.SaleId },
            sale
        );
    }

    [Authorize]
    [HttpDelete("{saleId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(int saleId)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        await _service.Delete(userId, saleId);
        return NoContent();
    }
}