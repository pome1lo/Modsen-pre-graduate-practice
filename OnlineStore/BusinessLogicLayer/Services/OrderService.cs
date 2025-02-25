using BusinessLogicLayer.Services.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Data.Interfaces;
using DataAccessLayer.Data.Repositories;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Orders> _orderRepository;
        private readonly IRepository<Users> _userRepository;

        public OrderService(IRepository<Orders> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderDto> GetOrderByIdAsync(int orderId, CancellationToken cancellationToken = default)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);

            if (order is null)
            {
                throw new Exception($"Order with ID {orderId} not found.");
            }
            OrderDto orderDto = new OrderDto() { Id = order.Id, UserId = order.UserId };

            return orderDto;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync(CancellationToken cancellationToken = default)
        {
            var orders = await _orderRepository.GetAllAsync();

            List<OrderDto> result = orders.Select(order => new OrderDto
            {
                Id = order.Id,
                UserId = order.UserId
            }).ToList();
            return result;
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(int userId, CancellationToken cancellationToken = default)
        {

            var user = (await _userRepository.GetAllAsync())
                .FirstOrDefault(c => c.Id == userId);
            if (user is null)
            {
                throw new Exception($"User with ID {userId} not found.");
            }

            var orders = (await _orderRepository.GetAllAsync())
                .Where(o => o.UserId == userId);


            List<OrderDto> result = orders.Select(order => new OrderDto { Id = order.Id, UserId = order.UserId}).ToList(); 
            return result;
        }

        public async Task<OrderDto> CreateOrderAsync(OrderDto newOrder, CancellationToken cancellationToken = default)
        {
            var order = new Orders() { Id = newOrder.Id, UserId = newOrder.UserId };
            await _orderRepository.AddAsync(order);

            OrderDto result = new OrderDto() { Id = order.Id, UserId = order.UserId };
            return result;
        }

        public async Task UpdateOrderAsync(int orderId, OrderDto updatedOrder, CancellationToken cancellationToken = default)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(orderId);

            if (existingOrder is null)
            {
                throw new Exception($"Order with ID {orderId} not found.");
            }

            var order = new Orders() { Id = updatedOrder.Id, UserId = updatedOrder.UserId};
            await _orderRepository.UpdateAsync(order);
        }

        public async Task DeleteOrderAsync(int orderId, CancellationToken cancellationToken = default)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);

            if (order is null)
            {
                throw new Exception($"Order with ID {orderId} not found.");
            }

            await _orderRepository.DeleteAsync(orderId);
        }
    }
}
