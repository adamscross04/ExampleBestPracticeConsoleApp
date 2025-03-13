using System.Threading.Tasks;

namespace Common.Repository.Update;

/// <summary>
/// Interface for updating a single entity.
/// </summary>
/// <typeparam name="T">The type of the entity.</typeparam>
public interface IUpdateSingle<in T>
{
    /// <summary>
    /// Updates a single entity.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task UpdateSingle(T entity);
}