using mongoConnection2.Models;

namespace mongoConnection2.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetById(string id);
        Task CreateAsync(Product Product);
        Task UpdateAsync(string id, Product Product);
        Task DeleteAsync(string id);
    }
}