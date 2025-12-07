namespace Learning.ProductService.Domain.Entities
{
    /// <summary>
    /// Represents a product with details such as name, description, price, quantity, and timestamps for creation and updates.
    /// </summary>
    public class Product : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required int Quantity { get; set; }
    }
}
