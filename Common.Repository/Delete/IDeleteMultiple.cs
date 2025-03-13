namespace Common.Repository.Delete;

/// <summary>
/// Interface for deleting multiple entities.
/// </summary>
/// <typeparam name="T">The type of the entities.</typeparam>
public interface IDeleteMultiple<in T>
{
    /// <summary>
    /// Deletes multiple entities.
    /// </summary>
    /// <param name="entities">The entities to delete.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task DeleteMultiple(IEnumerable<T> entities);
}