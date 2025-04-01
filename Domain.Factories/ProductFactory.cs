using Application.Requests;
using Domain.Models;

namespace Domain.Factories;

public class ProductFactory : IProductFactory
{
    public Product Create(ProductCreateRequest obj)
    {
        return new Product()
        {
            Id = Guid.NewGuid(),
            Description = obj.Description,
            Name = obj.Name,
            Price = obj.Price
        };
    }
}