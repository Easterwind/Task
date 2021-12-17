using Shop.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shop.DAL.Configurations
{
    public static class ProductConfiguration
    {
        public static void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products").HasKey(n => n.Id);
            builder.Property(n => n.Id).ValueGeneratedOnAdd();
        }
    }
}
