using Application.DTOs;
using Application.Mappers.Abstractions;
using Common.Mappers;
using Domain.Models;

namespace Application.Mappers.Implementations;

public class ProductDtoMapper: TwoWayMapperBase<ProductDto, Product>, IProductDtoMapper 
{
    public override ProductDto Map(Product obj)
    {
        ArgumentNullException.ThrowIfNull(obj);
        
        return new ProductDto
        {
            Id = obj.Id,
            Name = obj.Name,
            Price = obj.Price,
            Description = obj.Description,
        };
    }

    public override Product Map(ProductDto obj)
    {
        ArgumentNullException.ThrowIfNull(obj);
        
        return new Product
        {
            Id = obj.Id,
            Name = obj.Name,
            Price = obj.Price,
            Description = obj.Description
        };
    }
}