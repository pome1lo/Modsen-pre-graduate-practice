using AutoMapper;
using BusinessLogicLayer.Services.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Data.Interfaces;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Services;

public class OrderItemService(
    IOrderRepository orderRepository,
    IOrderItemRepository orderItemRepository,
    IMapper mapper
) : IOrderItemService
{
    public async Task<OrderItemDto> CreateOrderItemAsync(OrderItemDto newOrderItem, CancellationToken cancellationToken = default)
    {
        var orderItem = mapper.Map<OrderItems>(newOrderItem);
        await orderItemRepository.AddAsync(orderItem);
        return mapper.Map<OrderItemDto>(orderItem);
    }

    public async Task DeleteOrderItemAsync(int orderItemId, CancellationToken cancellationToken = default)
    {
        var orderItem = await orderRepository.GetByIdAsync(orderItemId);

        if (orderItem is null)
        {
            throw new KeyNotFoundException($"OrderItem with ID {orderItemId} not found.");
        }

        await orderItemRepository.DeleteAsync(orderItemId);
    }

    public async Task<OrderItemDto> GetOrderItemByIdAsync(int orderItemId, CancellationToken cancellationToken = default)
    {
        var orderItem = await orderItemRepository.GetByIdAsync(orderItemId);
        if (orderItem is null)
        {
            throw new KeyNotFoundException($"OrderItem with ID {orderItemId} not found.");
        }
        return mapper.Map<OrderItemDto>(orderItem);
    }

    public async Task<IEnumerable<OrderItemDto>> GetOrderItemsByOrderIdAsync(int orderId, CancellationToken cancellationToken = default)
    {
        var orderItems = await orderItemRepository.GetOrderItemsByOrderIdAsync(orderId);
        if (orderItems is null)
        {
            throw new KeyNotFoundException($"OrderItem with ID {orderId} not found.");
        }

        return mapper.Map<IEnumerable<OrderItemDto>>(orderItems);
    }

    public async Task UpdateOrderItemAsync(int orderItemId, OrderItemDto updatedOrderItem, CancellationToken cancellationToken = default)
    {
        var orderItem = mapper.Map<OrderItems>(updatedOrderItem);
        await orderItemRepository.UpdateAsync(orderItem);
    }
}