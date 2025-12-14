using MediatR;

namespace Learning.ProductService.Application.Commands
{
    /// <summary>
    /// Command to update existing product.
    /// </summary>
    /// <param name="Id">Id of Product to be updated</param>
    /// <param name="Name">Name of Product</param>
    /// <param name="Description">Descrition of Product</param>
    /// <param name="Price">Price of Product</param>
    /// <param name="Quantity">Total Available Quantity of Product</param>
    public record UpdateProductCommand(int Id, string Name, string Description, decimal Price, int Quantity) : IRequest;
}
