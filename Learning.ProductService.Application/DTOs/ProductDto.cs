namespace Learning.ProductService.Application.DTOs
{
    /// <summary>
    /// Represents a data transfer object containing product details, including identification, descriptive information, pricing, inventory, and timestamps.
    /// </summary>
    /// <param name="Id">The unique identifier for the product.</param>
    /// <param name="Name">The name of the product. Cannot be null.</param>
    /// <param name="Description">A description of the product. Cannot be null.</param>
    /// <param name="Price">The price of the product. Must be greater than or equal to zero.</param>
    /// <param name="Quantity">The available quantity of the product in stock. Must be zero or greater.</param>
    /// <param name="CreatedAt">The date and time when the product was created.</param>
    /// <param name="UpdatedAt">The date and time when the product was last updated, or null if the product has not been updated since creation.</param>
    public record ProductDto(int Id, string Name, string Description, decimal Price, int Quantity, DateTime CreatedAt, DateTime? UpdatedAt);
}
