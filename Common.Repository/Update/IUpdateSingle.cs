namespace Common.Repository.Update;

/// <summary>
/// Interface for updating a single entity.
/// </summary>
/// <typeparam name="T">The type of the entity.</typeparam>
public interface IUpdateSingle<T>
{
    /// <summary>
    /// Updates a single entity.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task<T> UpdateSingle(T entity);
}