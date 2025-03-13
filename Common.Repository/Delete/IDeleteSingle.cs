namespace Common.Repository.Delete;

/// <summary>
/// Interface for deleting a single entity.
/// </summary>
/// <typeparam name="T">The type of the entity.</typeparam>
public interface IDeleteSingle<in T>
{
    /// <summary>
    /// Deletes a single entity.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task DeleteSingle(T entity);
}