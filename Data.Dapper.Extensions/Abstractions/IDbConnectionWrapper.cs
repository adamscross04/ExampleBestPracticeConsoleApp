namespace Data.Dapper.Extensions.Abstractions;

public interface IDbConnectionWrapper
{
    Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null);
    Task<T?> QuerySingleOrDefaultAsync<T>(string sql, object param = null, CancellationToken cancellationToken = default);
    Task ExecuteAsync<T>(string sql, T entity);
}