# Common.Validation

## Overview

The `Common.Validation` library provides essential components for implementing validation logic consistently throughout your application. It includes a base class for creating custom validation services, a model for capturing validation results, and a custom exception for handling validation failures.

## Available Functionality

### ValidationServiceBase<T>
- **Custom Validation Service**:  
  Extend this base class to create custom validation logic for any object type.
- **Standardized Validation**:  
  Use the provided `Validate` method to execute your validation logic and receive a unified `ValidationResult`.
- **Helper Methods**:  
  Built-in methods for common validation checks:
    - **Empty Checks**: `IsEmpty` and `IsNotEmpty` for strings and GUIDs.
    - **Numeric Checks**: `IsZero`, `IsNotZero`, `IsNegative`, and `IsPositive` for decimal values.
    - **String Length Checks**: `IsShorterThan`, `IsLongerThan`, `IsShorterThanOrEqual`, and `IsLongerThanOrEqual`.

### ValidationResult Model
- **Error Collection**:  
  Holds a collection of error messages resulting from a validation operation.
- **Validity Indicator**:  
  An `IsValid` property that quickly indicates whether the object passed all validation checks.

### ValidationException
- **Custom Exception Handling**:  
  A specialized exception that can be thrown when validation fails, carrying detailed error information.

## Usage

1. **Create a Custom Validation Service**:  
   Inherit from `ValidationServiceBase<T>` for the type you want to validate, and override the `DoValidate` method with your custom validation logic.

2. **Validate Objects**:  
   Use the `Validate` method to perform the validation. This method returns a `ValidationResult` containing any errors.

3. **Handle Validation Failures**:  
   Optionally, throw a `ValidationException` with the provided error details when validation errors occur. This exception can be caught and handled as needed, and contains the list of validation errors for returning to the user.

### Example

```csharp
public class ProductValidationService : ValidationServiceBase<Product>, IProductValidationService
{
    protected override IEnumerable<string> DoValidate(Product product)
    {
        if (IsEmpty(product.Name))
        {
            yield return "Product name cannot be empty.";
        }
            
        if (IsZero(product.Price))
        {
            yield return "Product price must be greater than zero.";
        }
    }
}
```

### Example Usage

```csharp
public Task<object?> CreateProduct(ProductDto productDto)
{
    ValidationResult validationResult = productValidationService.Validate(productDto);
    
    if (!validationResult.IsValid)
    {
        throw new ValidationException()
        {
            Errors = validationResult.Errors
        };
    }
    
    return Task.FromResult<object?>(null);
}
```

## Conclusion
The Common.Validation library offers a robust framework to implement and manage validation logic. By standardizing how validations are written and handled, it promotes code reuse, consistency, and clarity across your application.