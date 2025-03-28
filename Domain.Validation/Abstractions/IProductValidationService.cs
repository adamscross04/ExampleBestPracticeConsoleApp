using Common.Validation.Abstractions;
using Domain.Models;

namespace Domain.Validation.Abstractions;

/// <summary>
/// Defines a contract for a product validation service.
/// </summary>
public interface IProductValidationService : IValidationService<Product>;