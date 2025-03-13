namespace Common.Repository.Create;

/// <summary>
/// Interface for creating multiple entities.
/// </summary>
/// <typeparam name="T">The type of the entities.</typeparam>
public interface ICreateMultiple<in T>
{
    /// <summary>
    /// Creates multiple entities.
    /// </summary>
    /// <param name="entities">The entities to create.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task CreateMultiple(IEnumerable<T> entities);
}