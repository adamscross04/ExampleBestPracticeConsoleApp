using Data.Entities;
using Domain.Models;

namespace Data.Mappers.Tests;

/// <summary>
/// Unit tests for the ProductDataMapper class.
/// </summary>
public class ProductDataMapperTests
{
    private readonly ProductDataMapper _mapper = new();

    /// <summary>
    /// Tests that a Product object is correctly mapped to a ProductEntity object.
    /// </summary>
    [Fact]
    public void Map_ProductToProductEntity_MapsCorrectly()
    {
        var product = new Product { Id = Guid.NewGuid(), Name = "Test Product", Description = "Test Description", Price = 9.99m };

        var result = _mapper.Map(product);

        Assert.Equal(product.Id, result.Id);
        Assert.Equal(product.Name, result.Name);
        Assert.Equal(product.Description, result.Description);
        Assert.Equal(product.Price, result.Price);
    }

    /// <summary>
    /// Tests that a ProductEntity object is correctly mapped to a Product object.
    /// </summary>
    [Fact]
    public void Map_ProductEntityToProduct_MapsCorrectly()
    {
        var productEntity = new ProductEntity { Id = Guid.NewGuid(), Name = "Test Product", Description = "Test Description", Price = 9.99m };

        var result = _mapper.Map(productEntity);

        Assert.Equal(productEntity.Id, result.Id);
        Assert.Equal(productEntity.Description, result.Description);
        Assert.Equal(productEntity.Price, result.Price);
    }

    /// <summary>
    /// Tests that mapping a null Product object throws an ArgumentNullException.
    /// </summary>
    [Fact]
    public void Map_ProductToProductEntity_NullProduct_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _mapper.Map((Product)null!));
    }

    /// <summary>
    /// Tests that mapping a null ProductEntity object throws an ArgumentNullException.
    /// </summary>
    [Fact]
    public void Map_ProductEntityToProduct_NullProductEntity_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _mapper.Map((ProductEntity)null!));
    }
}