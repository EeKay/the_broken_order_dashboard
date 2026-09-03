using Microsoft.AspNetCore.Mvc;
using OrderDashboard.Api.Models;
using OrderDashboard.Api.Services;

namespace OrderDashboard.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrdersController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public IActionResult GetOrders()
    {
        var orders = _orderService.GetOrdersAsync().Result;
        return Ok(orders);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetOrder(int id)
    {
        var order = _orderService.GetOrderAsync(id).Result;
        if (order is null)
        {
            return NotFound();
        }

        return Ok(order);
    }

    [HttpPatch("{id:int}/status")]
    public IActionResult UpdateStatus(int id, [FromBody] UpdateOrderStatusRequest request)
    {
        var order = _orderService.UpdateStatusAsync(id, request.Status).Result;
        if (order is null)
        {
            return NotFound();
        }

        return Ok(order);
    }
}
