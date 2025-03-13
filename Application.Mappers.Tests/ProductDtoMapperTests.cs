using Application.DTOs;
using Domain.Models;
using FluentAssertions;

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

        AssertProductAndProductDtoAreEquivalent(product, result);
    }

    /// <summary>
    /// Tests that a ProductDto object is correctly mapped to a Product object.
    /// </summary>
    [Fact]
    public void Map_ProductDtoToProduct_MapsCorrectly()
    {
        var productDto = new ProductDto { Id = Guid.NewGuid(), Name = "Test Product", Price = 9.99m };

        var result = _mapper.Map(productDto);

        AssertProductAndProductDtoAreEquivalent(result, productDto);
    }

    /// <summary>
    /// Tests that mapping a null Product object throws an ArgumentNullException.
    /// </summary>
    [Fact]
    public void Map_ProductToProductDto_NullProduct_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _mapper.Map((Product)null!));
    }

    /// <summary>
    /// Tests that mapping a null ProductDto object throws an ArgumentNullException.
    /// </summary>
    [Fact]
    public void Map_ProductDtoToProduct_NullProductDto_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _mapper.Map((ProductDto)null!));
    }

    /// <summary>
    /// Tests that a list of Product objects is correctly mapped to a list of ProductDto objects.
    /// </summary>
    [Fact]
    public void Map_ProductsToProductDtos_MapsCorrectly()
    {
        var products = new List<Product>
        {
            new() { Id = Guid.NewGuid(), Name = "Product 1", Price = 9.99m },
            new() { Id = Guid.NewGuid(), Name = "Product 2", Price = 19.99m }
        };

        var result = _mapper.Map(products);

        AssertProductListsAreEquivalent(products, result);
    }

    /// <summary>
    /// Tests that a list of ProductDto objects is correctly mapped to a list of Product objects.
    /// </summary>
    [Fact]
    public void Map_ProductDtosToProducts_MapsCorrectly()
    {
        var productDtos = new List<ProductDto>
        {
            new() { Id = Guid.NewGuid(), Name = "Product 1", Price = 9.99m },
            new() { Id = Guid.NewGuid(), Name = "Product 2", Price = 19.99m }
        };

        var result = _mapper.Map(productDtos);

        AssertProductListsAreEquivalent(result, productDtos);
    }

    /// <summary>
    /// Tests that mapping a null list of Product objects throws an ArgumentNullException.
    /// </summary>
    [Fact]
    public void Map_ProductsToProductDtos_NullProducts_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _mapper.Map((IEnumerable<Product>)null!));
    }

    /// <summary>
    /// Tests that mapping a null list of ProductDto objects throws an ArgumentNullException.
    /// </summary>
    [Fact]
    public void Map_ProductDtosToProducts_NullProductDtos_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _mapper.Map((IEnumerable<ProductDto>)null!));
    }

    #region Helpers

    /// <summary>
    /// Asserts that the properties of a Product and ProductDto are equivalent.
    /// </summary>
    /// <param name="product">The Product object.</param>
    /// <param name="productDto">The ProductDto object.</param>
    private void AssertProductAndProductDtoAreEquivalent(Product product, ProductDto productDto)
    {
        productDto.Id.Should().Be(product.Id);
        productDto.Name.Should().Be(product.Name);
        productDto.Price.Should().Be(product.Price);
    }

    /// <summary>
    /// Asserts that the properties of lists of Product and ProductDto are equivalent.
    /// </summary>
    /// <param name="products">The list of Product objects.</param>
    /// <param name="productDtos">The list of ProductDto objects.</param>
    private void AssertProductListsAreEquivalent(IEnumerable<Product> products, IEnumerable<ProductDto> productDtos)
    {
        var productList = products.ToList();
        var productDtoList = productDtos.ToList();

        productDtoList.Count.Should().Be(productList.Count);
        for (int i = 0; i < productList.Count; i++)
        {
            AssertProductAndProductDtoAreEquivalent(productList[i], productDtoList[i]);
        }
    }

    #endregion
}