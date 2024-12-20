using AgroProject.Data;
using AgroProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgroProject.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Zakazchik>> GetAllCustomersAsync();
        Task<Zakazchik> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(Zakazchik customer);
        Task UpdateCustomerAsync(int id, Zakazchik updatedCustomer);
        Task DeleteCustomerAsync(int id);
    }

    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
               public async Task<IEnumerable<Zakazchik>> GetAllCustomersAsync()
        {
            return await _context.Zakazchiks.ToListAsync();
        }

        public async Task<Zakazchik> GetCustomerByIdAsync(int id)
        {
            return await _context.Zakazchiks.FindAsync(id);
        }

        public async Task AddCustomerAsync(Zakazchik customer)
        {
            await _context.Zakazchiks.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(int id, Zakazchik updatedCustomer)
        {
            var customer = await _context.Zakazchiks.FindAsync(id);
            if (customer != null)
            {
                customer.Name = updatedCustomer.Name; // Обновите другие поля по мере необходимости
                customer.Email = updatedCustomer.Email;
                customer.Adress = updatedCustomer.Adress;
                customer.Inn = updatedCustomer.Inn;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCustomerAsync(int id)
        {
            var customer = await _context.Zakazchiks.FindAsync(id);
            if (customer != null)
            {
                _context.Zakazchiks.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}