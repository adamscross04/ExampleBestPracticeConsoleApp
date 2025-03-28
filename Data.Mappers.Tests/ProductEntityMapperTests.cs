using Data.Entities;
using Data.Mappers.Implementations;
using Domain.Models;
using FluentAssertions;

namespace Data.Mappers.Tests;

/// <summary>
/// Unit tests for the ProductDataMapper class.
/// </summary>
public class ProductEntityMapperTests
{
    private readonly ProductEntityMapper _mapper = new();

    /// <summary>
    /// Tests that a Product object is correctly mapped to a ProductEntity object.
    /// </summary>
    [Fact]
    public void Map_ProductToProductEntity_MapsCorrectly()
    {
        // Arrange
        Product product = new() { Id = Guid.NewGuid(), Name = "Test Product", Description = "Test Description", Price = 9.99m };

        // Act
        ProductEntity result = _mapper.Map(product);

        // Assert
        AssertProductAndProductEntityAreEquivalent(product, result);
    }

    /// <summary>
    /// Tests that a ProductEntity object is correctly mapped to a Product object.
    /// </summary>
    [Fact]
    public void Map_ProductEntityToProduct_MapsCorrectly()
    {
        // Arrange
        ProductEntity productEntity = new() { Id = Guid.NewGuid(), Name = "Test Product", Description = "Test Description", Price = 9.99m };

        // Act
        Product result = _mapper.Map(productEntity);

        // Assert
        AssertProductAndProductEntityAreEquivalent(result, productEntity);
    }

    /// <summary>
    /// Tests that mapping a null Product object throws an ArgumentNullException.
    /// </summary>
    [Fact]
    public void Map_ProductToProductEntity_NullProduct_ThrowsArgumentNullException()
    {
        // Act
        Func<ProductEntity> action = () => _mapper.Map((Product)null!);

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>();
    }

    /// <summary>
    /// Tests that mapping a null ProductEntity object throws an ArgumentNullException.
    /// </summary>
    [Fact]
    public void Map_ProductEntityToProduct_NullProductEntity_ThrowsArgumentNullException()
    {
        // Act
        Func<Product> action = () => _mapper.Map((ProductEntity)null!);

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>();
    }

    /// <summary>
    /// Tests that a list of Product objects is correctly mapped to a list of ProductEntity objects.
    /// </summary>
    [Fact]
    public void Map_ProductsToProductEntities_MapsCorrectly()
    {
        // Arrange
        List<Product> products =
        [
            new() { Id = Guid.NewGuid(), Name = "Product 1", Description = "Description 1", Price = 9.99m },
            new() { Id = Guid.NewGuid(), Name = "Product 2", Description = "Description 2", Price = 19.99m }
        ];

        // Act
        IEnumerable<ProductEntity> result = _mapper.Map(products);

        // Assert
        AssertProductListsAreEquivalent(products, result);
    }

    /// <summary>
    /// Tests that a list of ProductEntity objects is correctly mapped to a list of Product objects.
    /// </summary>
    [Fact]
    public void Map_ProductEntitiesToProducts_MapsCorrectly()
    {
        // Arrange
        List<ProductEntity> productEntities =
        [
            new() { Id = Guid.NewGuid(), Name = "Product 1", Description = "Description 1", Price = 9.99m },
            new() { Id = Guid.NewGuid(), Name = "Product 2", Description = "Description 2", Price = 19.99m }
        ];

        // Act
        IEnumerable<Product> result = _mapper.Map(productEntities);

        // Assert
        AssertProductListsAreEquivalent(result, productEntities);
    }

    /// <summary>
    /// Tests that mapping a null list of Product objects throws an ArgumentNullException.
    /// </summary>
    [Fact]
    public void Map_ProductsToProductEntities_NullProducts_ThrowsArgumentNullException()
    {
        // Act
        Func<IEnumerable<ProductEntity>> action = () => _mapper.Map((IEnumerable<Product>)null!);

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>();
    }

    /// <summary>
    /// Tests that mapping a null list of ProductEntity objects throws an ArgumentNullException.
    /// </summary>
    [Fact]
    public void Map_ProductEntitiesToProducts_NullProductEntities_ThrowsArgumentNullException()
    {
        // Act
        Func<IEnumerable<Product>> action = () => _mapper.Map((IEnumerable<ProductEntity>)null!);

        // Assert
        action.Should().ThrowExactly<ArgumentNullException>();
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
        List<Product> productList = [.. products];
        List<ProductEntity> productEntityList = [.. productEntities];

        productEntityList.Count.Should().Be(productList.Count);
        for (int i = 0; i < productList.Count; i++)
        {
            AssertProductAndProductEntityAreEquivalent(productList[i], productEntityList[i]);
        }
    }

    #endregion
}