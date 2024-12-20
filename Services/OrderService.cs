using AgroProject.Models;
using AgroProject.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgroProject.Services
{
    public interface IOrdersService
    {
        Task<IEnumerable<RegistraciaObrazcov>> GetAllOrdersAsync();
        Task<RegistraciaObrazcov> GetOrderByIdAsync(int id);
        Task AddOrderAsync(RegistraciaObrazcov order);
        Task UpdateOrderAsync(int id, RegistraciaObrazcov updatedOrder);
        Task DeleteOrderAsync(int id);
    }

    public class OrdersService : IOrdersService
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<RegistraciaObrazcov>> GetAllOrdersAsync()
        {
            return await _orderRepository.GetAllOrdersAsync();
        }

        public async Task<RegistraciaObrazcov> GetOrderByIdAsync(int id)
        {
            return await _orderRepository.GetOrderByIdAsync(id);
        }

        public async Task AddOrderAsync(RegistraciaObrazcov order)
        {
            await _orderRepository.AddOrderAsync(order);
        }

        public async Task UpdateOrderAsync(int id, RegistraciaObrazcov updatedOrder)
        {
            await _orderRepository.UpdateOrderAsync(id, updatedOrder);
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _orderRepository.DeleteOrderAsync(id);
        }
    }
}