using Domain.Models;
using Domain.Validation.Implementations;
using FluentAssertions;

namespace Domain.Validation.Tests;

public class UserValidationServiceTests
{
    [Fact]
    public void Validate_ReturnsNoErrors_WhenUserIsValid()
    {
        // Arrange
        var user = new User
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            PhoneNumber = "1234567890",
            Address = "123 Main St"
        };
        
        UserValidationService service = new();

        // Act
        var result = service.Validate(user);

        // Assert
        result.Errors.Should().BeEmpty();
    }

    [Fact]
    public void Validate_ReturnsError_WhenFirstNameIsMissing()
    {
        // Arrange
        var user = new User
        {
            LastName = "Doe",
            Email = "john.doe@example.com",
            PhoneNumber = "1234567890",
            Address = "123 Main St"
        };
        
        UserValidationService service = new();


        // Act
        var result = service.Validate(user);

        // Assert
        result.Errors.Should().Contain("First name is required.");
    }

    [Fact]
    public void Validate_ReturnsError_WhenLastNameIsMissing()
    {
        // Arrange
        var user = new User
        {
            FirstName = "John",
            Email = "john.doe@example.com",
            PhoneNumber = "1234567890",
            Address = "123 Main St"
        };
        
        UserValidationService service = new();

        // Act
        var result = service.Validate(user);

        // Assert
        result.Errors.Should().Contain("Last name is required.");
    }

    [Fact]
    public void Validate_ReturnsError_WhenEmailIsMissing()
    {
        // Arrange
        var user = new User
        {
            FirstName = "John",
            LastName = "Doe",
            PhoneNumber = "1234567890",
            Address = "123 Main St"
        };

        UserValidationService service = new();
        
        // Act
        var result = service.Validate(user);

        // Assert
        result.Errors.Should().Contain("Email is required.");
    }

    [Fact]
    public void Validate_ReturnsError_WhenPhoneNumberIsMissing()
    {
        // Arrange
        var user = new User
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            Address = "123 Main St"
        };
        
        UserValidationService service = new();

        // Act
        var result = service.Validate(user);

        // Assert
        result.Errors.Should().Contain("Phone number is required.");
    }

    [Fact]
    public void Validate_ReturnsError_WhenAddressIsMissing()
    {
        // Arrange
        var user = new User
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            PhoneNumber = "1234567890"
        };
        
        UserValidationService service = new();

        // Act
        var result = service.Validate(user);

        // Assert
        result.Errors.Should().Contain("Address is required.");
    }
}