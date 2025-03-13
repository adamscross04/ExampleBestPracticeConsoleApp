using Data.Dapper.Extensions.Abstractions;
using Data.Entities;
using Moq;
using FluentAssertions;

namespace Data.Repositories.Tests;

public class ProductRepositoryTests
{
    private readonly Mock<IDbConnectionWrapper> _mockDbConnectionWrapper;
    private readonly ProductRepository _repository;

    public ProductRepositoryTests()
    {
        _mockDbConnectionWrapper = new Mock<IDbConnectionWrapper>();
        _repository = new ProductRepository(_mockDbConnectionWrapper.Object);
    }

    [Fact]
    public async Task ReadSingleById_ReturnsProductEntity_WhenProductExists()
    {
        // Arrange
        Guid productId = Guid.NewGuid();
        ProductEntity expectedProduct = new ProductEntity { Id = productId, Name = "Test Product", Description = "Test Description", Price = 9.99m };
        _mockDbConnectionWrapper.Setup(db => db.QuerySingleOrDefaultAsync<ProductEntity>(
                It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(expectedProduct);

        // Act
        ProductEntity? result = await _repository.ReadSingleById(productId);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expectedProduct);
    }

    [Fact]
    public async Task ReadSingleById_ReturnsNull_WhenProductDoesNotExist()
    {
        // Arrange
        Guid productId = Guid.NewGuid();
        _mockDbConnectionWrapper.Setup(db => db.QuerySingleOrDefaultAsync<ProductEntity>(
                It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync((ProductEntity)null!);

        // Act
        ProductEntity? result = await _repository.ReadSingleById(productId);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task ReadMultipleByIds_ReturnsProductEntities_WhenProductsExist()
    {
        // Arrange
        List<Guid> productIds = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };
        List<ProductEntity> expectedProducts = new List<ProductEntity>
        {
            new() { Id = productIds[0], Name = "Product 1", Description = "Description 1", Price = 9.99m },
            new() { Id = productIds[1], Name = "Product 2", Description = "Description 2", Price = 19.99m }
        };
        _mockDbConnectionWrapper.Setup(db => db.QueryAsync<ProductEntity>(
                It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(expectedProducts);

        // Act
        IEnumerable<ProductEntity> result = (await _repository.ReadMultipleByIds(productIds)).ToList();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expectedProducts);
    }

    [Fact]
    public async Task ReadMultipleByIds_ReturnsEmpty_WhenNoProductsExist()
    {
        // Arrange
        List<Guid> productIds = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };
        _mockDbConnectionWrapper.Setup(db => db.QueryAsync<ProductEntity>(
                It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(Enumerable.Empty<ProductEntity>());

        // Act
        IEnumerable<ProductEntity> result = (await _repository.ReadMultipleByIds(productIds)).ToList();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }
}