using Common.Validation.Implementations;
using Domain.Models;
using Domain.Validation.Abstractions;

namespace Domain.Validation.Implementations;

public class ProductValidationService : 
    ValidationServiceBase<Product>, 
    IProductValidationService
{
    protected override IEnumerable<string> DoValidate(Product product)
    {
        if (IsNotEmpty(product.Id))
        {
            Console.WriteLine("Validation: Id is not empty");
            yield return "Id should not be set.";
        }

        if (IsZero(product.Price))
        {
            Console.WriteLine("Validation: Price is zero");
            yield return "Price should be greater than 0.";
        }
    }
}