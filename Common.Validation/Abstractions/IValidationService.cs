using Common.Validation.Models;

namespace Common.Validation.Abstractions;

/// <summary>
/// Defines a contract for a validation service.
/// </summary>
/// <typeparam name="T">The type of the object to be validated.</typeparam>
public interface IValidationService<in T>
{
    /// <summary>
    /// Validates the specified object.
    /// </summary>
    /// <param name="obj">The object to validate.</param>
    /// <returns>A <see cref="ValidationResult"/> containing the validation errors.</returns>
    ValidationResult Validate(T obj);
}