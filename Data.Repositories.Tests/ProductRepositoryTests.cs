using Data.Dapper.Extensions.Abstractions;
using Data.Entities;
using Data.Mappers.Implementations;
using Data.Repositories.Implementations;
using Domain.Models;
using Moq;
using FluentAssertions;

namespace Data.Repositories.Tests;

public class ProductRepositoryTests
{
    private readonly Mock<IDbConnectionWrapper> _mockDbConnectionWrapper;
    private readonly Mock<ProductEntityMapper> _mockProductEntityMapper;
    private readonly ProductRepository _repository;

    public ProductRepositoryTests()
    {
        _mockDbConnectionWrapper = new Mock<IDbConnectionWrapper>();
        _mockProductEntityMapper = new Mock<ProductEntityMapper>();

        _mockProductEntityMapper
            .Setup(m => m.Map(It.IsAny<ProductEntity>()))
            .Returns((ProductEntity pe) => new Product
            {
                Id = pe.Id,
                Name = pe.Name,
                Description = pe.Description,
                Price = pe.Price
            });

        _repository = new ProductRepository(_mockDbConnectionWrapper.Object, _mockProductEntityMapper.Object);
    }

    [Fact]
    public async Task ReadSingleById_ReturnsProductEntity_WhenProductExists()
    {
        // Arrange
        Guid productId = Guid.NewGuid();
        ProductEntity expectedProduct = new()
        {
            Id = productId, 
            Description = "Test Description", 
            Name = "Test Product", 
            Price = 9.99m
        };
        _mockDbConnectionWrapper.Setup(db => db.QuerySingleOrDefaultAsync<ProductEntity>(
                It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(expectedProduct);

        // Act
        Product? result = await _repository.ReadSingleById(productId);

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
        Product? result = await _repository.ReadSingleById(productId);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task ReadMultipleByIds_ReturnsProductEntities_WhenProductsExist()
    {
        // Arrange
        List<Guid> productIds = [Guid.NewGuid(), Guid.NewGuid()];
        List<ProductEntity> expectedProducts =
        [
            new()
            {
                Id = productIds[0],                 
                Description = "Description 1", 
                Name = "Product 1", 
                Price = 9.99m
            },
            new()
            {
                Id = productIds[1], 
                Description = "Description 2", 
                Name = "Product 2", 
                Price = 19.99m
            }
        ];
        
        _mockDbConnectionWrapper.Setup(db => db.QueryAsync<ProductEntity>(
                It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync(expectedProducts);

        // Act
        List<Product> result = [.. await _repository.ReadMultipleByIds(productIds)];

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expectedProducts);
    }

    [Fact]
    public async Task ReadMultipleByIds_ReturnsEmpty_WhenNoProductsExist()
    {
        // Arrange
        List<Guid> productIds = [
            Guid.NewGuid(), 
            Guid.NewGuid()
        ];
        
        _mockDbConnectionWrapper.Setup(db => db.QueryAsync<ProductEntity>(
                It.IsAny<string>(), It.IsAny<object>()))
            .ReturnsAsync([]);

        // Act
        List<Product> result = [.. await _repository.ReadMultipleByIds(productIds)];

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }
}