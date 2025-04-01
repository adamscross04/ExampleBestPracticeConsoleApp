using System.Data;
using System.Diagnostics.CodeAnalysis;
using Dapper;
using Data.Dapper.Extensions.Abstractions;

namespace Data.Dapper.Extensions;

[ExcludeFromCodeCoverage]
public class DbConnectionWrapper(IDbConnection dbConnection) : IDbConnectionWrapper
{
    public Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null)
    {
        return dbConnection.QueryAsync<T>(sql, param);
    }

    public Task<T?> QuerySingleOrDefaultAsync<T>(string sql, object param = null, CancellationToken token = default)
    {
        return dbConnection.QuerySingleOrDefaultAsync<T>(new CommandDefinition(sql, param, cancellationToken: token));
    }

    public Task ExecuteAsync<T>(string sql, T entity)
    {
        return dbConnection.ExecuteAsync(sql, entity);
    }
}