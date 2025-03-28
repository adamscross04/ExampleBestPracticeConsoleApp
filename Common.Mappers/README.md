# Common.Mappers

## Overview

The `Common.Mappers` library provides a set of abstractions and base classes for object mapping. It is designed to facilitate the conversion of objects between different types using a clean and consistent interface.

## Purpose

The purpose of this library is to offer a reusable, standardized approach for mapping objects. It supports:

- **One-Way Mapping**: Converting an object from one type to another.
- **Two-Way Mapping**: Enabling bi-directional conversion between two types.

## Key Features

- **Abstract Base Classes**:
    - `OneWayMapperBase<TIn, TOut>`: Provides a template for one-way mapping, including support for mapping collections.
    - `TwoWayMapperBase<T1, T2>`: Offers a template for two-way mapping with methods for mapping both single objects and collections.
- **Interface-Driven Design**:
    - `IOneWayMapper<TIn, TOut>`: Defines the contract for one-way mappers.
    - `ITwoWayMapper<T1, T2>`: Specifies the requirements for two-way mappers.
- **Collection Mapping**: Uses LINQ to allow mapping of entire collections with minimal extra code.

## Structure

The library is organized into the following components:

- **Abstractions**:  
  Contains the interfaces (`IOneWayMapper` and `ITwoWayMapper`) that define the mapping contracts.

- **One-Way Mapping**:  
  Contains the `OneWayMapperBase` class which:
    - Implements a single abstract `Map` method to convert an object.
    - Provides an additional method to map collections.

- **Two-Way Mapping**:  
  Contains the `TwoWayMapperBase` class which:
    - Defines two abstract methods for mapping in both directions.
    - Includes methods for mapping collections from either direction.

## Abstractions

### One-Way Mapping

```csharp
using Common.Mappers.Abstractions;

namespace Common.Mappers;

/// <summary>
/// Abstract base class for one-way mapping between two types.
/// </summary>
/// <typeparam name="TIn">The input type.</typeparam>
/// <typeparam name="TOut">The output type.</typeparam>
public abstract class OneWayMapperBase<TIn, TOut> : IOneWayMapper<TIn, TOut>
{
    /// <summary>
    /// Maps an object of type TIn to an object of type TOut.
    /// </summary>
    /// <param name="obj">The object of type TIn to map.</param>
    /// <returns>The mapped object of type TOut.</returns>
    public abstract TOut Map(TIn obj);
    
    /// <summary>
    /// Maps a collection of objects of type TIn to a collection of objects of type TOut.
    /// </summary>
    /// <param name="obj">The collection of objects of type TIn to map.</param>
    /// <returns>The mapped collection of objects of type TOut.</returns>
    public IEnumerable<TOut> Map(IEnumerable<TIn> obj)
    {
        return obj.Select(Map);
    }
}
```

### Two-Way Mapping

```csharp
using Common.Mappers.Abstractions;

namespace Common.Mappers;

/// <summary>
/// Abstract base class for two-way mapping between two types.
/// </summary>
/// <typeparam name="T1">The first type.</typeparam>
/// <typeparam name="T2">The second type.</typeparam>
public abstract class TwoWayMapperBase<T1, T2> : ITwoWayMapper<T1, T2>
{
    /// <summary>
    /// Maps an object of type T2 to an object of type T1.
    /// </summary>
    /// <param name="obj">The object of type T2 to map.</param>
    /// <returns>The mapped object of type T1.</returns>
    public abstract T1 Map(T2 obj);

    /// <summary>
    /// Maps an object of type T1 to an object of type T2.
    /// </summary>
    /// <param name="obj">The object of type T1 to map.</param>
    /// <returns>The mapped object of type T2.</returns>
    public abstract T2 Map(T1 obj);

    /// <summary>
    /// Maps a collection of objects of type T2 to a collection of objects of type T1.
    /// </summary>
    /// <param name="obj">The collection of objects of type T2 to map.</param>
    /// <returns>The mapped collection of objects of type T1.</returns>
    public IEnumerable<T1> Map(IEnumerable<T2> obj)
    {
        return obj.Select(Map);
    }

    /// <summary>
    /// Maps a collection of objects of type T1 to a collection of objects of type T2.
    /// </summary>
    /// <param name="obj">The collection of objects of type T1 to map.</param>
    /// <returns>The mapped collection of objects of type T2.</returns>
    public IEnumerable<T2> Map(IEnumerable<T1> obj)
    {
        return obj.Select(Map);
    }
}
```
## Usage

To implement a custom mapper:

1. **Choose the appropriate base class:**
    - Inherit from `OneWayMapperBase` if you only need one-way mapping.
    - Inherit from `TwoWayMapperBase` if you require bi-directional mapping.

2. **Implement the abstract methods:**
    - Provide the logic for mapping between your specific types.

3. **Example of implementing a one-way mapper:**

```csharp
public class ProductMapper : OneWayMapperBase<ProductDto, Product>
{
    public override Product Map(ProductDto obj)
    {
        // Implement mapping logic from ProductDto to Product.
    }
}
```

4. **Example of implementing a two-way mapper:**

```csharp
public class ProductMapper : TwoWayMapperBase<ProductDto, Product>
{
    public override ProductDto Map(Product obj)
    {
        // Implement mapping logic from Product to ProductDto.
    }

    public override Product Map(ProductDto obj)
    {
        // Implement mapping logic from ProductDto to Product.
    }
}
```

5. **Integrate with your application:**
Use dependency injection to inject your mapper into the services or controllers where mapping is required.

## Conclusion
The Common.Mappers library offers a robust and reusable solution for object mapping. By leveraging abstract base classes and interfaces, it promotes a clean separation of concerns and simplifies the mapping of both individual objects and collections across your application.