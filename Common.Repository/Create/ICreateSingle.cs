namespace Common.Repository.Create;

/// <summary>
/// Interface for creating a single entity.
/// </summary>
/// <typeparam name="T">The type of the entity.</typeparam>
public interface ICreateSingle<in T>
{
    /// <summary>
    /// Creates a single entity.
    /// </summary>
    /// <param name="entity">The entity to create.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task CreateSingle(T entity);
}