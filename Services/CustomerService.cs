using AgroProject.Models;
using AgroProject.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgroProject.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Zakazchik>> GetAllCustomersAsync();
        Task<Zakazchik> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(Zakazchik customer);
        Task UpdateCustomerAsync(int id, Zakazchik updatedCustomer);
        Task DeleteCustomerAsync(int id);
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Zakazchik>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllCustomersAsync();
        }

        public async Task<Zakazchik> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetCustomerByIdAsync(id);
        }

        public async Task AddCustomerAsync(Zakazchik customer)
        {
            await _customerRepository.AddCustomerAsync(customer);
        }

        public async Task UpdateCustomerAsync(int id, Zakazchik updatedCustomer)
        {
            await _customerRepository.UpdateCustomerAsync(id, updatedCustomer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteCustomerAsync(id);
        }
    }
}