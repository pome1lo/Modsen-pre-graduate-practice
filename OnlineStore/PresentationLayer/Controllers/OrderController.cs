using BusinessLogicLayer.Services.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<OrderDto>> GetOrderById(int id, CancellationToken cancellationToken)
        {
            var order = await _orderService.GetOrderByIdAsync(id, cancellationToken);
            return Ok(order);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrders(CancellationToken cancellationToken = default)
        {
            var orders = await _orderService.GetAllOrdersAsync(cancellationToken);
            return Ok(orders);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<OrderDto>> CreateOrder(OrderDto newOrder,
            CancellationToken cancellationToken = default)
        {
            var createdOrder = await _orderService.CreateOrderAsync(newOrder, cancellationToken);
            return CreatedAtAction(nameof(CreateOrder), new { id = createdOrder.Id }, createdOrder);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult<OrderDto>> UpdateOrder(int id, OrderDto updatedOrder,
            CancellationToken cancellationToken = default)
        {
            await _orderService.UpdateOrderAsync(id, updatedOrder, cancellationToken);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<OrderDto>> DeleteOrder(int id, CancellationToken cancellationToken = default)
        {
            await _orderService.DeleteOrderAsync(id, cancellationToken);
            return NoContent();
        }
    }
}
