using Learning.ProductService.Application.Commands;
using Learning.ProductService.Domain.Interfaces;
using MediatR;

namespace Learning.ProductService.Application.Handlers
{
    /// <summary>
    /// Handler for updating existing product.
    /// </summary>
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <inheritdoc />
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var dbProduct = await _productRepository.GetProductById(request.Id);

            if (dbProduct == null)
            {
                throw new KeyNotFoundException($"Product with ID {request.Id} not found.");
            }

            dbProduct.UpdateDetails(request.Name, request.Description, request.Price, request.Quantity);

            await _productRepository.UpdateProduct(dbProduct);
        }
    }
}
