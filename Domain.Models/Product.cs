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

/// <summary>
/// Domain model for a User.
/// </summary>
public class User
{
    public string? EmailAddress { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Address { get; set; }
    public string Username { get; set; }
}