using AutoMapper;
using BusinessLogicLayer.Services.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Data.Interfaces;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Orders> _orderRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public OrderService(IRepository<Orders> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> GetOrderByIdAsync(int orderId, CancellationToken cancellationToken = default)
        {
            var order = await _orderRepository.GetByIdAsync(orderId, cancellationToken);

            if (order is null)
            {
                throw new Exception($"Order with ID {orderId} not found.");
            }
            OrderDto orderDto = _mapper.Map<OrderDto>(order);

            return orderDto;
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync(CancellationToken cancellationToken = default)
        {
            var orders = await _orderRepository.GetAllAsync(cancellationToken);

            List<OrderDto> result = orders.Select(order => _mapper.Map<OrderDto>(order)).ToList();
            return result;
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersByUserIdAsync(int userId, CancellationToken cancellationToken = default)
        {

            var user = (await _userRepository.GetAllAsync(cancellationToken))
                .FirstOrDefault(c => c.Id == userId);
            if (user is null)
            {
                throw new Exception($"User with ID {userId} not found.");
            }

            var orders = (await _orderRepository.GetAllAsync(cancellationToken))
                .Where(o => o.UserId == userId);


            List<OrderDto> result = orders.Select(order => _mapper.Map<OrderDto>(order)).ToList();
            return result;
        }

        public async Task<OrderDto> CreateOrderAsync(OrderDto newOrder, CancellationToken cancellationToken = default)
        {
            var order = new Orders() { Id = newOrder.Id, UserId = newOrder.UserId };
            await _orderRepository.AddAsync(order, cancellationToken);

            OrderDto result = _mapper.Map<OrderDto>(order);
            return result;
        }

        public async Task UpdateOrderAsync(int orderId, OrderDto updatedOrder, CancellationToken cancellationToken = default)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(orderId, cancellationToken);

            if (existingOrder is null)
            {
                throw new Exception($"Order with ID {orderId} not found.");
            }

            var order = _mapper.Map<Orders>(updatedOrder);
            await _orderRepository.UpdateAsync(order);
        }

        public async Task DeleteOrderAsync(int orderId, CancellationToken cancellationToken = default)
        {
            var order = await _orderRepository.GetByIdAsync(orderId, cancellationToken);

            if (order is null)
            {
                throw new Exception($"Order with ID {orderId} not found.");
            }

            await _orderRepository.DeleteAsync(orderId);
        }
    }
}
