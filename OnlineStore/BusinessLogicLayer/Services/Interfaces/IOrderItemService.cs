using BusinessLogicLayer.Services.DTOs;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IOrderItemService
    {
        Task<OrderItemDto> GetOrderItemByIdAsync(int orderItemId, CancellationToken cancellationToken = default);
        Task<IEnumerable<OrderItemDto>> GetOrderItemsByOrderIdAsync(int orderId, CancellationToken cancellationToken = default);
        Task<OrderItemDto> CreateOrderItemAsync(OrderItemDto newOrderItem, CancellationToken cancellationToken = default);
        Task UpdateOrderItemAsync(int orderItemId, OrderItemDto updatedOrderItem, CancellationToken cancellationToken = default);
        Task DeleteOrderItemAsync(int orderItemId, CancellationToken cancellationToken = default);
    }
}
