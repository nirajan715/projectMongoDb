using mongoConnection2.Models;

namespace mongoConnection2.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetById(string id);
        Task CreateAsync(Customer customer);
        Task UpdateAsync(string id, Customer customer);
        Task DeleteAsync(string id);
    }
}