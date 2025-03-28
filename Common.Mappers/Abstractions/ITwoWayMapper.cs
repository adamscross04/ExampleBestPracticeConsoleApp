namespace Common.Mappers.Abstractions;

/// <summary>
///     Interface for mapping objects between two types T1 and T2.
/// </summary>
/// <typeparam name="T1">The first type to be mapped.</typeparam>
/// <typeparam name="T2">The second type to be mapped.</typeparam>
public interface ITwoWayMapper<T1, T2>
{
    /// <summary>
    ///     Maps an object of type T2 to an object of type T1.
    /// </summary>
    /// <param name="obj">The object of type T2 to be mapped.</param>
    /// <returns>The mapped object of type T1.</returns>
    T1 Map(T2 obj);

    /// <summary>
    ///     Maps an object of type T1 to an object of type T2.
    /// </summary>
    /// <param name="obj">The object of type T1 to be mapped.</param>
    /// <returns>The mapped object of type T2.</returns>
    T2 Map(T1 obj);

    /// <summary>
    ///     Maps a collection of objects of type T2 to a collection of objects of type T1.
    /// </summary>
    /// <param name="objs">The collection of objects of type T2 to be mapped.</param>
    /// <returns>The mapped collection of objects of type T1.</returns>
    IEnumerable<T1> Map(IEnumerable<T2> objs);

    /// <summary>
    ///     Maps a collection of objects of type T1 to a collection of objects of type T2.
    /// </summary>
    /// <param name="objs">The collection of objects of type T1 to be mapped.</param>
    /// <returns>The mapped collection of objects of type T2.</returns>
    IEnumerable<T2> Map(IEnumerable<T1> objs);
}