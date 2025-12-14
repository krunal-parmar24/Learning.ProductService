namespace Learning.ProductService.Application.DTOs
{
    /// <summary>
    /// Dto to add a new product.
    /// </summary>
    /// <param name="Name">Name of Product</param>
    /// <param name="Description">Description of Product</param>
    /// <param name="Amount">Amount of Product</param>
    /// <param name="Quantity">Total Available Quantity of Product</param>
    public record AddProductDto(string Name, string Description, decimal Amount, int Quantity);
}
