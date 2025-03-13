using Application.DTOs;
using Domain.Models;

namespace Application.Mappers.Tests;

/// <summary>
/// Unit tests for the ProductDtoMapper class.
/// </summary>
public class ProductDtoMapperTests
{
    private readonly ProductDtoMapper _mapper = new();

    /// <summary>
    /// Tests that a Product object is correctly mapped to a ProductDto object.
    /// </summary>
    [Fact]
    public void Map_ProductToProductDto_MapsCorrectly()
    {
        var product = new Product { Id = Guid.NewGuid(), Name = "Test Product", Price = 9.99m };

        var result = _mapper.Map(product);

        Assert.Equal(product.Id, result.Id);
        Assert.Equal(product.Name, result.Name);
        Assert.Equal(product.Price, result.Price);
    }

    /// <summary>
    /// Tests that a ProductDto object is correctly mapped to a Product object.
    /// </summary>
    [Fact]
    public void Map_ProductDtoToProduct_MapsCorrectly()
    {
        var productDto = new ProductDto { Id = Guid.NewGuid(), Name = "Test Product", Price = 9.99m };

        var result = _mapper.Map(productDto);

        Assert.Equal(productDto.Id, result.Id);
        Assert.Equal(productDto.Name, result.Name);
        Assert.Equal(productDto.Price, result.Price);
    }

    /// <summary>
    /// Tests that mapping a null Product object throws an ArgumentNullException.
    /// </summary>
    [Fact]
    public void Map_ProductToProductDto_NullProduct_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _mapper.Map((Product) null!));
    }

    /// <summary>
    /// Tests that mapping a null ProductDto object throws an ArgumentNullException.
    /// </summary>
    [Fact]
    public void Map_ProductDtoToProduct_NullProductDto_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _mapper.Map((ProductDto) null!));
    }
}