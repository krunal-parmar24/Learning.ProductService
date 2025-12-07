using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Learning.ProductService.Infrastructure.Data
{
    /// <summary>
    /// Provides a design-time factory for creating instances of the ProductDbContext for use with Entity Framework Core tools.
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ProductDbContext>
    {
        public ProductDbContext CreateDbContext(string[] args)
        {
            // Navigate to API project directory to find appsettings.json
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "Learning.ProductService.API");
            
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ProductDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new ProductDbContext(optionsBuilder.Options);
        }
    }
}
