using Common.Validation.Models;
using Domain.Models;
using Domain.Validation.Implementations;
using FluentAssertions;

namespace Domain.Validation.Tests;

public class ProductValidationServiceTests
{
    [Fact]
    public void Validate_ReturnsError_WhenIdIsNotEmpty()
    {
        // Arrange
        Product product = new() { Id = Guid.NewGuid(), Price = 10m };
        ProductValidationService service = new();

        // Act
        ValidationResult result = service.Validate(product);

        // Assert
        result.Errors.Should().Contain("Id should not be set.");
    }

    [Fact]
    public void Validate_ReturnsError_WhenPriceIsZero()
    {
        // Arrange
        Product product = new() { Id = Guid.Empty, Price = 0m };
        ProductValidationService service = new();

        // Act
        ValidationResult result = service.Validate(product);

        // Assert
        result.Errors.Should().Contain("Price should be greater than 0.");
    }

    [Fact]
    public void Validate_ReturnsNoErrors_WhenIdIsEmptyAndPriceIsGreaterThanZero()
    {
        // Arrange
        Product product = new() { Id = Guid.Empty, Price = 10m };
        ProductValidationService service = new();

        // Act
        ValidationResult result = service.Validate(product);

        // Assert
        result.Errors.Should().BeEmpty();
    }
}