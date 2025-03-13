using Common.Mappers.Abstractions;
using Data.Entities;
using Domain.Models;

namespace Data.Mappers.Abstractions;

/// <summary>
/// Interface for mapping between ProductEntity and Product objects.
/// </summary>
public interface IProductDataMapper : ITwoWayMapper<ProductEntity, Product>;