using Learning.ProductService.Domain.Interfaces;
using Learning.ProductService.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Learning.ProductService.Infrastructure
{
    /// <summary>
    /// Provides extension methods for registering infrastructure-related services with the dependency injection container.
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Repositories
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
