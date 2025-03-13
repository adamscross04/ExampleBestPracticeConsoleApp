namespace Data.Entities;

/// <summary>
/// Database model for Product.
/// </summary>
public class ProductEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
}