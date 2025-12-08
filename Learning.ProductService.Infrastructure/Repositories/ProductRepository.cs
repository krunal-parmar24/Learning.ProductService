using Learning.ProductService.Domain.Entities;
using Learning.ProductService.Domain.Interfaces;
using Learning.ProductService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Learning.ProductService.Infrastructure.Repositories
{
    /// <summary>
    /// Provides methods for accessing and managing products in the data store.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbContext;

        public ProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc />
        public async Task<List<Product>> GetProducts()
        {
            return await _dbContext.Products.ToListAsync();            
        }
    }
}
