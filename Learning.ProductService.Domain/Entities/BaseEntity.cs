namespace Learning.ProductService.Domain.Entities
{
    /// <summary>
    /// Represents the base type for entities with a unique identifier.
    /// </summary>
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
