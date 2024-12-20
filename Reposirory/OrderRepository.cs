using AgroProject.Data;
using AgroProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgroProject.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<RegistraciaObrazcov>> GetAllOrdersAsync();
        Task<RegistraciaObrazcov> GetOrderByIdAsync(int id);
        Task AddOrderAsync(RegistraciaObrazcov order);
        Task UpdateOrderAsync(int id, RegistraciaObrazcov updatedOrder);
        Task DeleteOrderAsync(int id);
        Task<IEnumerable<RegistraciaObrazcov>> GetOrdersByCustomerIdAsync(int customerId);
    }

    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RegistraciaObrazcov>> GetAllOrdersAsync()
        {
            return await _context.RegistraciaObrazcovs.ToListAsync();
        }

        public async Task<RegistraciaObrazcov> GetOrderByIdAsync(int id)
        {
            return await _context.RegistraciaObrazcovs.FindAsync(id);
        }

        public async Task AddOrderAsync(RegistraciaObrazcov order)
        {
            await _context.RegistraciaObrazcovs.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOrderAsync(int id, RegistraciaObrazcov updatedOrder)
        {
            var order = await _context.RegistraciaObrazcovs.FindAsync(id);
            if (order != null)
            {
                order.Kulture = updatedOrder.Kulture; // Обновите другие поля по мере необходимости
                order.Sort = updatedOrder.Sort;
                // и так далее для других полей...
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _context.RegistraciaObrazcovs.FindAsync(id);
            if (order != null)
            {
                _context.RegistraciaObrazcovs.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<RegistraciaObrazcov>> GetOrdersByCustomerIdAsync(int customerId)
        {
            return await _context.RegistraciaObrazcovs.Where(o => o.Zakazchik == customerId).ToListAsync();
        }
    }
}