using MediatR;

namespace Learning.ProductService.Application.Commands
{
    /// <summary>
    /// Command to add a new product.
    /// </summary>
    /// <param name="Name">Name of Product</param>
    /// <param name="Description">Descrition of Product</param>
    /// <param name="Price">Price of Product</param>
    /// <param name="Quantity">Total Available Quantity of Product</param>
    public record AddProductCommand(string Name, string Description, decimal Price, int Quantity) : IRequest<int>;
}
