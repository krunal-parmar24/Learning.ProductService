using Learning.ProductService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Learning.ProductService.Infrastructure.Data
{
    /// <summary>
    /// Represents the Entity Framework Core database context for accessing and managing product data.
    /// </summary>
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
    }
}
