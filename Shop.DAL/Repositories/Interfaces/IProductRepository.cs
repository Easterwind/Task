using Shop.DAL.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.DAL.Repositories.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAll();
        Task DeleteAsync(int productId);
        Task DeleteAllAsync();
        Task InsertAsync(Product product);
        Task<Product> GetByIdAsync(int productId);
    }
}
