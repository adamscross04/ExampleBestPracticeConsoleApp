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