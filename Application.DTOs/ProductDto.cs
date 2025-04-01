namespace Application.DTOs;

/// <summary>
/// Data Transfer Object for Product.
/// </summary>
public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
}