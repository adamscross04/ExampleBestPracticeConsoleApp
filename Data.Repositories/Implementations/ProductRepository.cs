using Data.Dapper.Extensions.Abstractions;
using Data.Entities;
using Data.Mappers.Abstractions;
using Data.Repositories.Abstractions;
using Domain.Models;
using ZiggyCreatures.Caching.Fusion;

namespace Data.Repositories.Implementations;

public class ProductRepository(
    IDbConnectionWrapper dbConnectionWrapper, 
    IProductEntityMapper productEntityMapper, 
    IFusionCache cache
) : IProductRepository
{
    public async Task<Product?> ReadSingleById(Guid id, CancellationToken cancellationToken = default)
    {
        return await cache.GetOrSetAsync<Product?>(
            $"product-{id}",
            async ct => await ReadSingleByIdInternal(id, ct),
            TimeSpan.FromSeconds(30), 
            token: cancellationToken);
    }

    public async Task<IEnumerable<Product>> ReadMultipleByIds(IEnumerable<Guid> ids)
    {
        const string query = "SELECT * FROM Products WHERE Id IN @Ids";
        IEnumerable<ProductEntity> results = await dbConnectionWrapper.QueryAsync<ProductEntity>(query, new { Ids = ids });
        return results.Select(productEntityMapper.Map);
    }

    public async Task<IEnumerable<Product>> ReadMultipleByIds(params Guid[] ids)
    {
        return await ReadMultipleByIds(ids.ToList());
    }

    public Task<Product> UpdateSingle(Product entity)
    {
        throw new NotImplementedException();
    }
    
    #region internal methods
    
    private async Task<Product?> ReadSingleByIdInternal(Guid id, CancellationToken cancellationToken)
    {
        const string query = "SELECT * FROM Products WHERE Id = @Id LIMIT 1";
        ProductEntity? result = await dbConnectionWrapper.QuerySingleOrDefaultAsync<ProductEntity>(query, new { Id = id }, cancellationToken);
        return result == null ? null : productEntityMapper.Map(result);
    }
    
    #endregion

    public Task CreateSingle(Product entity)
    {
        const string query = "INSERT INTO Products (Id, Name, Description, Price) VALUES (@Id, @Name, @Description, @Price)";
        return dbConnectionWrapper.ExecuteAsync(query, entity);
    }
}