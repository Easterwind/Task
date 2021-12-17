using Shop.DAL.Models;
using Shop.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.BLL.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<List<Product>> GetFilteredAsync(ProductFilterDto filter);
        Task DeleteAsync(int productId);
        Task DeleteAllAsync();
        Task InsertAsync(Product product);
        Task<int> CountAsync();
        Task<Product> ExpensivestAsync();
        Task<Product> CheapestAsync();
        Task<Product> MedianAsync();
        Task<Product> GetByIdAsync(int productId);
    }
}
