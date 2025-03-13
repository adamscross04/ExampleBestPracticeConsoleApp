using System.Data;
using Dapper;
using Common.Repository.Read;
using Data.Dapper.Extensions.Abstractions;
using Data.Entities;

namespace Data.Repositories;

public class ProductRepository(IDbConnectionWrapper dbConnectionWrapper) :
    IReadSingleById<ProductEntity>,
    IReadMultipleByIds<ProductEntity>
{
    public async Task<ProductEntity?> ReadSingleById(Guid id)
    {
        const string query = "SELECT * FROM Products WHERE Id = @Id";
        return await dbConnectionWrapper.QuerySingleOrDefaultAsync<ProductEntity>(query, new { Id = id });
    }

    public async Task<IEnumerable<ProductEntity>> ReadMultipleByIds(IEnumerable<Guid> ids)
    {
        const string query = "SELECT * FROM Products WHERE Id IN @Ids";
        return await dbConnectionWrapper.QueryAsync<ProductEntity>(query, new { Ids = ids });
    }
}