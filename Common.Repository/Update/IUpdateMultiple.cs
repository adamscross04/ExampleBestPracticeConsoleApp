namespace Common.Repository.Update;

/// <summary>
/// Interface for updating multiple entities.
/// </summary>
/// <typeparam name="T">The type of the entities.</typeparam>
public interface IUpdateMultiple<in T>
{
    /// <summary>
    /// Updates multiple entities.
    /// </summary>
    /// <param name="entities">The entities to update.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task UpdateMultiple(IEnumerable<T> entities);
}