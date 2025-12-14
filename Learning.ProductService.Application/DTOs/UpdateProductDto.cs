namespace Learning.ProductService.Application.DTOs
{
    /// <summary>
    /// Dto to update existing product.
    /// </summary>
    /// <param name="Name">Name of Product</param>
    /// <param name="Description">Description of Product</param>
    /// <param name="Amount">Amount of Product</param>
    /// <param name="Quantity">Total Available Quantity of Product</param>
    public record UpdateProductDto(string Name, string Description, decimal Amount, int Quantity);
}
