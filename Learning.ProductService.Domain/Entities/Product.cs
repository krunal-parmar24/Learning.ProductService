namespace Learning.ProductService.Domain.Entities
{
    /// <summary>
    /// Represents a product with details such as name, description, price, quantity, and timestamps for creation and updates.
    /// </summary>
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        private Product() { }

        public Product(string name, string description, decimal price, int quantity)
        {
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            CreatedAt = DateTime.UtcNow;
        }

        public void UpdateDetails(string name, string description, decimal price, int quantity)
        {
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
