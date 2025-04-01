
using Application.Requests;
using Domain.Models;

namespace Domain.Services.Abstractions;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProducts();
    Task<Product?> GetProduct(Guid id);
    Task CreateProduct(ProductCreateRequest productCreateRequest);
    Task<Product> UpdateProduct(Guid id, Product product);
    Task DeleteProduct(Guid id);
}