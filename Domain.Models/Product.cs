namespace Domain.Models;

/// <summary>
/// Domain model for a Product.
/// </summary>
public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
}