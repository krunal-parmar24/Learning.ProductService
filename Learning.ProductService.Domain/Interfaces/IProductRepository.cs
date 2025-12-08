using Learning.ProductService.Domain.Entities;

namespace Learning.ProductService.Domain.Interfaces
{
    public interface IProductRepository
    {
        /// <summary>
        /// Asynchronously retrieves a list of available products.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of <see cref="Product"/>
        /// objects representing the available products. The list will be empty if no products are found.</returns>
        public Task<List<Product>> GetProducts();
    }
}
