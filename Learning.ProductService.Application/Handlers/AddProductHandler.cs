using Learning.ProductService.Application.Commands;
using Learning.ProductService.Domain.Entities;
using Learning.ProductService.Domain.Interfaces;
using MediatR;

namespace Learning.ProductService.Application.Handlers
{
    /// <summary>
    /// Handler for adding a new product.
    /// </summary>
    public class AddProductHandler : IRequestHandler<AddProductCommand, int>
    {
        private readonly IProductRepository _productRepository;
        public AddProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <inheritdoc />
        public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(
                request.Name,
                request.Description,
                request.Price,
                request.Quantity
            );

            var addedProduct = await _productRepository.AddProduct(product);

            return addedProduct.Id;
        }
    }
}
