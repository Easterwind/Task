using Microsoft.EntityFrameworkCore;
using Shop.DAL.Configurations;
using Shop.DAL.Models;

namespace Shop.DAL
{
    public class ShopDbContext : DbContext
    {
        private readonly string _connectionString;

        public ShopDbContext()
        {
        }
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        { }
        public DbSet<Product> Products { get; set; }
        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(ProductConfiguration.Configure);
        }
        #endregion
    }
}
