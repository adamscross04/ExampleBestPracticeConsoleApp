namespace Common.Repository.Read;

/// <summary>
/// Interface for reading a single entity by its ID.
/// </summary>
/// <typeparam name="T">The type of the entity.</typeparam>
public interface IReadSingleById<T>
{
    /// <summary>
    /// Reads a single entity by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity to read.</param>
    /// <returns>A task representing the asynchronous operation, with the entity as the result.</returns>
    Task<T?> ReadSingleById(Guid id);
}