using System.Data;
using Dapper;
using Data.Dapper.Extensions.Abstractions;

namespace Data.Dapper.Extensions;

public class DbConnectionWrapper(IDbConnection dbConnection) : IDbConnectionWrapper
{
    public Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null)
    {
        return dbConnection.QueryAsync<T>(sql, param);
    }

    public Task<T?> QuerySingleOrDefaultAsync<T>(string sql, object param = null)
    {
        return dbConnection.QuerySingleOrDefaultAsync<T>(sql, param);
    }
}