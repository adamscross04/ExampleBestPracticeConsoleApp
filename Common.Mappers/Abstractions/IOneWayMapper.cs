namespace Common.Mappers.Abstractions;

/// <summary>
///     Interface for mapping an object of type TIn to an object of type TOut.
/// </summary>
/// <typeparam name="TIn">The input type to be mapped from.</typeparam>
/// <typeparam name="TOut">The output type to be mapped to.</typeparam>
public interface IOneWayMapper<in TIn, out TOut>
{
    /// <summary>
    /// Maps an object of type TIn to an object of type TOut
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    TOut Map(TIn obj);
}