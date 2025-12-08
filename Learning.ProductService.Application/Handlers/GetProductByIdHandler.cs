using Learning.ProductService.Application.DTOs;
using Learning.ProductService.Application.Queries;
using Learning.ProductService.Domain.Interfaces;
using MediatR;

namespace Learning.ProductService.Application.Handlers
{
    /// <summary>
    /// Handles queries to retrieve a product by its unique identifier.
    /// </summary>
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
    {
        private readonly IProductRepository _repository;

        public GetProductByIdHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetProductById(request.Id);
            return product == null ? null : new ProductDto(
                product.Id,
                product.Name,
                product.Description,
                product.Price,
                product.Quantity,
                product.CreatedAt,
                product.UpdatedAt
            );
        }
    }
}
