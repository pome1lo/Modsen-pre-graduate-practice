using BusinessLogicLayer.Services.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderItemController(
    IOrderItemService orderItemService
) : ControllerBase
{

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderItemDto>> GetOrderItemById(int id, CancellationToken cancellationToken)
    {
        var orderItem = await orderItemService.GetOrderItemByIdAsync(id, cancellationToken);
        return Ok(orderItem);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderItemDto>>> GetAllOrderItems(int id,
        CancellationToken cancellationToken = default)
    {
        var orderItems = await orderItemService.GetOrderItemsByOrderIdAsync(id, cancellationToken);
        return Ok(orderItems);
    }

    [HttpPost]
    public async Task<ActionResult<OrderItemDto>> CreateOrderItem(OrderItemDto newOrderItem,
        CancellationToken cancellationToken = default)
    {
        var createdOrderItem = await orderItemService.CreateOrderItemAsync(newOrderItem, cancellationToken);
        return Ok(createdOrderItem);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<OrderItemDto>> UpdateOrderItem(int id, OrderItemDto updatedOrderItem,
        CancellationToken cancellationToken = default)
    {
        await orderItemService.UpdateOrderItemAsync(id, updatedOrderItem, cancellationToken);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<OrderItemDto>> DeleteOrderItem(int id, CancellationToken cancellationToken = default)
    {
        await orderItemService.DeleteOrderItemAsync(id, cancellationToken);
        return Ok();
    }
}