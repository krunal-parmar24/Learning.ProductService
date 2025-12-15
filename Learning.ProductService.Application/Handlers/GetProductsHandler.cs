using Learning.ProductService.Application.DTOs;
using Learning.ProductService.Application.Queries;
using Learning.ProductService.Domain.Interfaces;
using MediatR;

namespace Learning.ProductService.Application.Handlers
{
    /// <summary>
    /// Handles requests to retrieve a collection of products and maps them to data transfer objects.
    /// </summary>
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProducts(request.ProductIds);
            return products.Select(x => new ProductDto(
                x.Id,
                x.Name,
                x.Description,
                x.Price,
                x.Quantity,
                x.CreatedAt,
                x.UpdatedAt))
            .ToList();
        }
    }
}
