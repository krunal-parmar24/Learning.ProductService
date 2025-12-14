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

        /// <summary>
        /// Asynchronously retrieves a product with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to retrieve. Must be greater than zero.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="Product"/> if
        /// found; otherwise, <see langword="null"/>.</returns>
        public Task<Product?> GetProductById(int id);

        /// <summary>
        /// Asynchronously adds a new product to the repository.
        /// </summary>
        /// <param name="product">The product object which is going to be added in system.</param>
        /// <returns></returns>
        public Task<Product> AddProduct(Product product);
    }
}
