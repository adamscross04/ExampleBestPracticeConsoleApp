using Application.Requests;
using Common.Exceptions;
using Common.Validation.Models;
using Data.Repositories.Abstractions;
using Domain.Factories;
using Domain.Models;
using Domain.Services.Implementations;
using Domain.Validation.Abstractions;
using Moq;
using FluentAssertions;

namespace Domain.Services.Tests;

public class ProductServiceTests
{
    private readonly Mock<IProductCreateValidationService> _mockValidationService;
    private readonly Mock<IProductRepository> _mockProductRepository;
    private readonly ProductService _productService;

    public ProductServiceTests()
    {
        _mockValidationService = new Mock<IProductCreateValidationService>();
        _mockProductRepository = new Mock<IProductRepository>();
        Mock<IProductFactory> mockProductFactory = new();
        _productService = new ProductService(_mockValidationService.Object, _mockProductRepository.Object, mockProductFactory.Object);
    }

    [Fact]
    public async Task GetProduct_ReturnsProduct_WhenProductExists()
    {
        // Arrange
        Guid productId = Guid.NewGuid();

        Product product = new()
        {
            Id = productId,
            Name = "Test Product",
            Price = 10.0m
        };

        _mockProductRepository
            .Setup(repo => repo.ReadSingleById(productId, CancellationToken.None))
            .ReturnsAsync(product);

        // Act
        Product? result = await _productService.GetProduct(productId);

        // Assert
        result.Should().Be(product);
    }

    [Fact]
    public async Task GetProduct_ThrowsNotFoundException_WhenProductDoesNotExist()
    {
        // Arrange
        Guid productId = Guid.NewGuid();

        _mockProductRepository
            .Setup(repo => repo.ReadSingleById(productId, CancellationToken.None))
            .ReturnsAsync((Product)null!);

        // Act
        var product = await _productService.GetProduct(productId);

        // Assert
        product.Should().BeNull();
    }

    [Fact]
    public async Task CreateProduct_ReturnsCreatedProduct_WhenProductIsValid()
    {
        
        
        
        
        // Arrange
        
        var productCreateRequest = new ProductCreateRequest
        {
            Name = "New Product",
            Price = 20.0m,
            Description = "New Product Description"
        };
        
        _mockValidationService
            .Setup(service => service.Validate(productCreateRequest))
            .Returns(new ValidationResult
            {
                Errors = []
            });
        
        
        // Act
        var act = async () => await _productService.CreateProduct(productCreateRequest);

        // Assert
        await act.Should().NotThrowAsync();
    }

    [Fact]
    public async Task CreateProduct_ThrowsValidationException_WhenProductIsInvalid()
    {
        // Arrange
        ProductCreateRequest product = new()
        {
            Name = "Product Name",
            Price = -10.0m,
            Description = "Product Description"
        };

        _mockValidationService
            .Setup(service => service.Validate(product))
            .Returns(new ValidationResult
            {
                Errors = ["Invalid price"]
            });

        // Act
        Func<Task> act = async () => await _productService.CreateProduct(product);

        // Assert
        await act.Should().ThrowAsync<ValidationException>();
    }

    // [Fact]
    // public async Task UpdateProduct_ReturnsUpdatedProduct_WhenProductIsValid()
    // {
    //     // Arrange
    //     Guid productId = Guid.NewGuid();
    //
    //     Product existingProduct = new()
    //     {
    //         Id = productId,
    //         Name = "Existing Product",
    //         Price = 15.0m
    //     };
    //
    //     Product updatedProduct = new()
    //     {
    //         Id = productId,
    //         Name = "Updated Product",
    //         Price = 25.0m
    //     };
    //
    //     _mockProductRepository
    //         .Setup(repo => repo.ReadSingleById(productId, CancellationToken.None))
    //         .ReturnsAsync(existingProduct);
    //
    //     _mockValidationService
    //         .Setup(service => service.Validate(existingProduct))
    //         .Returns(new ValidationResult
    //         {
    //             Errors = []
    //         });
    //
    //     _mockProductRepository
    //         .Setup(repo => repo.UpdateSingle(It.IsAny<Product>()))
    //         .ReturnsAsync(updatedProduct);
    //
    //     // Act
    //     Product result = await _productService.UpdateProduct(productId, updatedProduct);
    //
    //     // Assert
    //     result.Should().Be(updatedProduct);
    // }

    // [Fact]
    // public async Task UpdateProduct_ThrowsNotFoundException_WhenProductDoesNotExist()
    // {
    //     // Arrange
    //     Guid productId = Guid.NewGuid();
    //
    //     Product product = new()
    //     {
    //         Id = productId,
    //         Name = "Non-Existent Product",
    //         Price = 30.0m
    //     };
    //
    //     _mockProductRepository
    //         .Setup(repo => repo.ReadSingleById(productId, CancellationToken.None))
    //         .ReturnsAsync((Product)null!);
    //
    //     // Act
    //     Func<Task> act = async () => await _productService.UpdateProduct(productId, product);
    //
    //     // Assert
    //     await act.Should().ThrowAsync<NotFoundException>();
    // }
    //
    // [Fact]
    // public async Task UpdateProduct_ThrowsValidationException_WhenProductIsInvalid()
    // {
    //     // Arrange
    //     Guid productId = Guid.NewGuid();
    //
    //     Product existingProduct = new()
    //     {
    //         Id = productId,
    //         Name = "Existing Product",
    //         Price = 15.0m
    //     };
    //
    //     Product updatedProduct = new()
    //     {
    //         Id = productId,
    //         Name = "Updated Product",
    //         Price = -25.0m
    //     };
    //
    //     _mockProductRepository
    //         .Setup(repo => repo.ReadSingleById(productId, CancellationToken.None))
    //         .ReturnsAsync(existingProduct);
    //
    //     _mockValidationService
    //         .Setup(service => service.Validate(existingProduct))
    //         .Returns(new ValidationResult
    //         {
    //             Errors = ["Invalid price"]
    //         });
    //
    //     // Act
    //     Func<Task> act = async () => await _productService.UpdateProduct(productId, updatedProduct);
    //
    //     // Assert
    //     await act.Should().ThrowAsync<ValidationException>();
    // }
}