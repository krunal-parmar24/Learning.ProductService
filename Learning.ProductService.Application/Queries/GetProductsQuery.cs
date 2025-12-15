using Learning.ProductService.Application.DTOs;
using MediatR;

namespace Learning.ProductService.Application.Queries
{
    /// <summary>
    /// Represents a request to retrieve a collection of products.
    /// </summary>
    ///<param name="ProductIds">The list of product IDs to retrieve.</param>
    public record GetProductsQuery(List<int> ProductIds) : IRequest<List<ProductDto>>;
}
