using Data.Dapper.Extensions.Abstractions;
using Data.Entities;
using Data.Mappers.Abstractions;
using Data.Repositories.Abstractions;
using Domain.Models;

namespace Data.Repositories.Implementations;

public class ProductRepository(IDbConnectionWrapper dbConnectionWrapper, IProductEntityMapper productEntityMapper) : IProductRepository
{
    public async Task<Product?> ReadSingleById(Guid id)
    {
        const string query = "SELECT top(1) * FROM Products WHERE Id = @Id";
        ProductEntity? result = await dbConnectionWrapper.QuerySingleOrDefaultAsync<ProductEntity>(query, new { Id = id });
        return result == null ? null : productEntityMapper.Map(result);
    }

    public async Task<IEnumerable<Product>> ReadMultipleByIds(IEnumerable<Guid> ids)
    {
        const string query = "SELECT * FROM Products WHERE Id IN @Ids";
        IEnumerable<ProductEntity> results = await dbConnectionWrapper.QueryAsync<ProductEntity>(query, new { Ids = ids });
        return results.Select(productEntityMapper.Map);
    }

    public Task<Product> UpdateSingle(Product entity)
    {
        throw new NotImplementedException();
    }
}