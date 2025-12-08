using Learning.ProductService.Application.DTOs;
using MediatR;

namespace Learning.ProductService.Application.Queries
{
    /// <summary>
    /// Represents a request to retrieve a collection of products.
    /// </summary>
    public record GetProductsQuery : IRequest<List<ProductDto>>;
}
