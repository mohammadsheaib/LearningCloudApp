using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using OrderService.Services;

namespace OrderService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly OrderRepository _repo;

    public OrdersController(OrderRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _repo.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
        => Ok(await _repo.GetById(id));

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderDto dto)
    {
        var order = new Order
        {
            ProductId = dto.ProductId,
            Quantity = dto.Quantity
        };
        await _repo.Create(order);
        return Ok(order);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _repo.Delete(id);
        return NoContent();
    }
}
