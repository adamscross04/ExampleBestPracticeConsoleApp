
using Domain.Models;

namespace Domain.Services.Abstractions;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProducts();
    Task<Product?> GetProduct(Guid id);
    Task<Product> CreateProduct(Product product);
    Task<Product> UpdateProduct(Guid id, Product product);
    Task DeleteProduct(Guid id);
}