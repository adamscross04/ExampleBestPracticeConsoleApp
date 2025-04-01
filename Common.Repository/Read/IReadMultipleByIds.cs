namespace Common.Repository.Read;

/// <summary>
/// Interface for reading multiple entities by their IDs.
/// </summary>
/// <typeparam name="T">The type of the entities.</typeparam>
public interface IReadMultipleByIds<T>
{
    /// <summary>
    /// Reads multiple entities by their IDs.
    /// </summary>
    /// <param name="ids">The IDs of the entities to read.</param>
    /// <returns>A task representing the asynchronous operation, with the entities as the result.</returns>
    Task<IEnumerable<T>> ReadMultipleByIds(IEnumerable<Guid> ids);

    /// <summary>
    /// Reads multiple entities by their IDs as params.
    /// </summary>
    /// <param name="ids">The IDs of the entities to read.</param>
    /// <returns>A task representing the asynchronous operation, with the entities as the result.</returns>
    Task<IEnumerable<T>> ReadMultipleByIds(params Guid[] ids);
}