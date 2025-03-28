# Application.Validation

## Overview

The `Application.Validation` project is designed to handle all validation logic for the application layer. This project follows the principle of separation of concerns, ensuring that validation logic is kept separate from other parts of the application layer, such as business logic and data access.

## Purpose

The sole purpose of the `Application.Validation` project is to contain validation services. These services are responsible for validating data transfer objects (DTOs) and ensuring that the data meets the required criteria before it is processed by other parts of the application layer.

## Key Features

- **Separation of Concerns**: By isolating validation logic in its own project, we ensure that the application layer remains modular and maintainable. This separation allows for easier testing and modification of validation rules without affecting other parts of the application layer.
- **Reusable Validation Services**: Validation services can be reused across different parts of the application layer, promoting code reuse and reducing duplication.
- **Custom Validation Logic**: Implement custom validation logic specific to the application's requirements.
- **Common.Validation Library**: Makes use of the `Common.Validation` library for abstracting away key functionality, providing shared functionality, and ensuring commonality across the validators.

## Structure

The `Application.Validation` project typically contains the following components:

- **Validation Services**: Classes that implement validation logic for specific DTOs.
- **Interfaces**: Interfaces that define the contract for validation services.
- **Base Classes**: Base classes that provide common validation functionality.

## Example

Here is an example of a validation service in the `Application.Validation` project:

```csharp
using Application.DTOs;
using Common.Validation;

namespace Application.Validation;

public class ProductValidationService : ValidationServiceBase<ProductDto>, IProductValidationService
{
    protected override IEnumerable<string> DoValidate(ProductDto obj)
    {
        if (obj.Id != Guid.Empty)
        {
            yield return "Id should not be set.";
        }

        if (obj.Price == 0)
        {
            yield return "Price should be greater than 0.";
        }
    }
}

public interface IProductValidationService : IValidationService<ProductDto>;
```

## Usage

To use a validation service, inject it into the relevant service or controller and call the `Validate` method with the DTO to be validated. Handle any validation errors as needed.

## Conclusion

The `Application.Validation` project is a crucial part of the application layer architecture, ensuring that validation logic is cleanly separated and easily maintainable. By adhering to the principle of separation of concerns, we create a more modular and testable application layer.