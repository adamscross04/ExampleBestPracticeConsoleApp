using Application.Requests;
using Common.Validation.Models;
using Domain.Validation.Implementations;
using FluentAssertions;

namespace Domain.Validation.Tests;

public class ProductCreateValidationServiceTests
{
    [Fact]
    public void Validate_ReturnsError_WhenPriceIsZero()
    {
        ProductCreateValidationService service = new();
        ProductCreateRequest request = new() { Price = 0, Name = "Test Product", Description = "Test Description" };

        ValidationResult result = service.Validate(request);

        result.Errors.Count().Should().Be(1);
        result.Errors.Should().Contain("Price should be greater than 0.");
    }

    [Fact]
    public void Validate_ReturnsError_WhenNameIsEmpty()
    {
        ProductCreateValidationService service = new();
        ProductCreateRequest request = new() { Price = 10, Name = "", Description = "Test Description" };

        ValidationResult result = service.Validate(request);

        result.Errors.Count().Should().Be(1);
        result.Errors.Should().Contain("Name should not be empty.");
    }

    [Fact]
    public void Validate_ReturnsError_WhenDescriptionIsEmpty()
    {
        ProductCreateValidationService service = new();
        ProductCreateRequest request = new() { Price = 10, Name = "Test Product", Description = "" };

        ValidationResult result = service.Validate(request);

        result.Errors.Count().Should().Be(1);
        result.Errors.Should().Contain("Description should not be empty.");
    }

    [Fact]
    public void Validate_ReturnsNoErrors_WhenAllFieldsAreValid()
    {
        ProductCreateValidationService service = new();
        ProductCreateRequest request = new() { Price = 10, Name = "Test Product", Description = "Test Description" };

        ValidationResult result = service.Validate(request);

        result.Errors.Count().Should().Be(0);
    }

    [Theory]
    [InlineData("   ")]
    [InlineData("\t")]
    [InlineData("\n")]
    public void Validate_ReturnsError_WhenNameIsWhitespace(string name)
    {
        // Arrange
        ProductCreateValidationService service = new();
        ProductCreateRequest request = new()
        {
            Price = 10,
            Name = name,
            Description = "Valid Description"
        };

        // Act
        ValidationResult result = service.Validate(request);

        // Assert
        result.Errors.Should().Contain("Name should not be empty.");
    }

    [Theory]
    [InlineData("   ")]
    [InlineData("\t")]
    [InlineData("\n")]
    public void Validate_ReturnsError_WhenDescriptionIsWhitespace(string description)
    {
        // Arrange
        ProductCreateValidationService service = new();
        ProductCreateRequest request = new()
        {
            Price = 10,
            Name = "Valid Name",
            Description = description
        };

        // Act
        ValidationResult result = service.Validate(request);

        // Assert
        result.Errors.Should().Contain("Description should not be empty.");
    }

    [Fact]
    public void Validate_ReturnsError_WhenNameIsNull()
    {
        // Arrange
        ProductCreateValidationService service = new();
        ProductCreateRequest request = new()
        {
            Price = 10,
            Name = null!, // null name
            Description = "Valid Description"
        };

        // Act
        ValidationResult result = service.Validate(request);

        // Assert
        result.Errors.Should().Contain("Name should not be empty.");
    }

    [Fact]
    public void Validate_ReturnsError_WhenDescriptionIsNull()
    {
        // Arrange
        ProductCreateValidationService service = new();
        ProductCreateRequest request = new()
        {
            Price = 10,
            Name = "Valid Name",
            Description = null! // null description
        };

        // Act
        ValidationResult result = service.Validate(request);

        // Assert
        result.Errors.Should().Contain("Description should not be empty.");
    }
    
    [Fact]
    public void Validate_ReturnsError_WhenPriceIsNegative()
    {
        // Arrange
        var service = new ProductCreateValidationService();
        var request = new ProductCreateRequest 
        { 
            Price = -5,  // negative price
            Name = "Valid Name", 
            Description = "Valid Description" 
        };

        // Act
        var result = service.Validate(request);

        // Assert
        // This assumes you update your validation logic to flag negative prices.
        result.Errors.Should().Contain("Price should be greater than 0.");
    }
}