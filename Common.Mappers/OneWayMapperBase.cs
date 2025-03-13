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