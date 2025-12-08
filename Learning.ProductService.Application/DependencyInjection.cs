using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Learning.ProductService.Application
{
    /// <summary>
    /// Provides extension methods for registering application services with the dependency injection container.
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
