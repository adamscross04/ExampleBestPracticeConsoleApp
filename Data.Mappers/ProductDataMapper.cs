using Common.Mappers;
using Data.Entities;
using Data.Mappers.Abstractions;
using Domain.Models;

namespace Data.Mappers;

/// <summary>
/// Maps between ProductEntity and Product objects.
/// </summary>
public class ProductDataMapper: TwoWayMapperBase<ProductEntity, Product>, IProductDataMapper
{
    /// <summary>
    /// Maps a Product object to a ProductEntity object.
    /// </summary>
    /// <param name="obj">The Product object to map.</param>
    /// <returns>The mapped ProductEntity object.</returns>
    public override ProductEntity Map(Product obj)
    {
        ArgumentNullException.ThrowIfNull(obj, nameof(obj));
        
        return new()
        {
            Id = obj.Id,
            Name = obj.Name,
            Description = obj.Description,
            Price = obj.Price,
        };
    }

    /// <summary>
    /// Maps a ProductEntity object to a Product object.
    /// </summary>
    /// <param name="obj">The ProductEntity object to map.</param>
    /// <returns>The mapped Product object.</returns>
    public override Product Map(ProductEntity obj)
    {
        ArgumentNullException.ThrowIfNull(obj, nameof(obj));
        
        return new()
        {
            Id = obj.Id,
            Name = obj.Name,
            Description = obj.Description,
            Price = obj.Price,
        };
    }
}