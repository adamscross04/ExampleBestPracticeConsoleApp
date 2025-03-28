using Common.Exceptions;
using Common.Validation.Models;
using Data.Repositories;
using Data.Repositories.Abstractions;
using Domain.Models;
using Domain.Services.Abstractions;
using Domain.Validation.Abstractions;

namespace Domain.Services.Implementations;

public class ProductService(IProductValidationService productValidationService, IProductRepository productRepository) : IProductService
{
    public Task<IEnumerable<Product>> GetProducts()
    {
        throw new NotImplementedException();
    }

    public async Task<Product> GetProduct(Guid id)
    {
        Product? product = await productRepository.ReadSingleById(id);
        if (product == null)
        {
            throw new NotFoundException($"Product with ID {id} not found.");
        }
        return product;
    }

    public async Task<Product> CreateProduct(Product product)
    {
        HandleValidation(product);

        Product updatedProduct = await productRepository.UpdateSingle(product);

        return updatedProduct;
    }

    

    public async Task<Product> UpdateProduct(Guid id, Product product)
    {
        // Retrieve the existing product
        Product existingProduct = await productRepository.ReadSingleById(id) ?? throw new NotFoundException($"Product with ID {id} not found.");

        // Apply updates (this might involve copying over properties)
        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        // ... update other properties as needed

        HandleValidation(existingProduct);

        // Persist the changes
        Product updatedProduct = await productRepository.UpdateSingle(product);

        return updatedProduct;
    }

    public Task DeleteProduct(Guid id)
    {
        throw new NotImplementedException();
    }
    
    #region Helpers
    private void HandleValidation(Product product)
    {
        ValidationResult validationResult = productValidationService.Validate(product);

        if (!validationResult.IsValid)
        {
            throw new ValidationException()
            {
                Errors = validationResult.Errors
            };
        }
    }
    #endregion
}