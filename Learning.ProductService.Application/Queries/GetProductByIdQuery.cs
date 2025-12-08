using Learning.ProductService.Application.DTOs;
using MediatR;

namespace Learning.ProductService.Application.Queries
{
    /// <summary>
    /// Represents a request to retrieve a product by its unique identifier.
    /// </summary>
    /// <param name="Id">The unique identifier of the product to retrieve.</param>
    public record GetProductByIdQuery(int Id) : IRequest<ProductDto?>;
}
