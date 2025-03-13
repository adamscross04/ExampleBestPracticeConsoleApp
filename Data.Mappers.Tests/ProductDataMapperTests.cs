using Data.Entities;
using Domain.Models;
using FluentAssertions;

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

        AssertProductAndProductEntityAreEquivalent(product, result);
    }

    /// <summary>
    /// Tests that a ProductEntity object is correctly mapped to a Product object.
    /// </summary>
    [Fact]
    public void Map_ProductEntityToProduct_MapsCorrectly()
    {
        var productEntity = new ProductEntity { Id = Guid.NewGuid(), Name = "Test Product", Description = "Test Description", Price = 9.99m };

        var result = _mapper.Map(productEntity);

        AssertProductAndProductEntityAreEquivalent(result, productEntity);
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

    /// <summary>
    /// Tests that a list of Product objects is correctly mapped to a list of ProductEntity objects.
    /// </summary>
    [Fact]
    public void Map_ProductsToProductEntities_MapsCorrectly()
    {
        var products = new List<Product>
        {
            new() { Id = Guid.NewGuid(), Name = "Product 1", Description = "Description 1", Price = 9.99m },
            new() { Id = Guid.NewGuid(), Name = "Product 2", Description = "Description 2", Price = 19.99m }
        };

        var result = _mapper.Map(products);

        AssertProductListsAreEquivalent(products, result);
    }

    /// <summary>
    /// Tests that a list of ProductEntity objects is correctly mapped to a list of Product objects.
    /// </summary>
    [Fact]
    public void Map_ProductEntitiesToProducts_MapsCorrectly()
    {
        var productEntities = new List<ProductEntity>
        {
            new() { Id = Guid.NewGuid(), Name = "Product 1", Description = "Description 1", Price = 9.99m },
            new() { Id = Guid.NewGuid(), Name = "Product 2", Description = "Description 2", Price = 19.99m }
        };

        var result = _mapper.Map(productEntities);

        AssertProductListsAreEquivalent(result, productEntities);
    }

    /// <summary>
    /// Tests that mapping a null list of Product objects throws an ArgumentNullException.
    /// </summary>
    [Fact]
    public void Map_ProductsToProductEntities_NullProducts_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _mapper.Map((IEnumerable<Product>)null!));
    }

    /// <summary>
    /// Tests that mapping a null list of ProductEntity objects throws an ArgumentNullException.
    /// </summary>
    [Fact]
    public void Map_ProductEntitiesToProducts_NullProductEntities_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _mapper.Map((IEnumerable<ProductEntity>)null!));
    }

    #region Helpers
    
    /// <summary>
    /// Asserts that the properties of a Product and ProductEntity are equivalent.
    /// </summary>
    /// <param name="product">The Product object.</param>
    /// <param name="productEntity">The ProductEntity object.</param>
    private void AssertProductAndProductEntityAreEquivalent(Product product, ProductEntity productEntity)
    {
        productEntity.Id.Should().Be(product.Id);
        productEntity.Name.Should().Be(product.Name);
        productEntity.Description.Should().Be(product.Description);
        productEntity.Price.Should().Be(product.Price);
    }

    /// <summary>
    /// Asserts that the properties of lists of Product and ProductEntity are equivalent.
    /// </summary>
    /// <param name="products">The list of Product objects.</param>
    /// <param name="productEntities">The list of ProductEntity objects.</param>
    private void AssertProductListsAreEquivalent(IEnumerable<Product> products, IEnumerable<ProductEntity> productEntities)
    {
        var productList = products.ToList();
        var productEntityList = productEntities.ToList();

        productEntityList.Count.Should().Be(productList.Count);
        for (int i = 0; i < productList.Count; i++)
        {
            AssertProductAndProductEntityAreEquivalent(productList[i], productEntityList[i]);
        }
    }
    
    #endregion
}