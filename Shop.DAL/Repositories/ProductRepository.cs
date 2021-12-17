using Microsoft.EntityFrameworkCore;
using Shop.DAL.Models;
using Shop.DAL.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ShopDbContext context;
        public ProductRepository(ShopDbContext context)
        {
            this.context = context;
        }
        public async Task DeleteAllAsync()
        {
            context.Products.RemoveRange(context.Products);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int productId)
        {
            var entity = await context.Products.FindAsync(productId);
            if (entity != null)
            {
                context.Products.Remove(entity);
                await context.SaveChangesAsync();
            }
           
        }

        public IQueryable<Product> GetAll()
        {
            return context.Products;
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            return await context.Products
                .Where(n => n.Id == productId)
                .FirstOrDefaultAsync();
        }

        public async Task InsertAsync(Product product)
        {
            context.Products.Add(product);
            await context.SaveChangesAsync();
        }
    }
}
