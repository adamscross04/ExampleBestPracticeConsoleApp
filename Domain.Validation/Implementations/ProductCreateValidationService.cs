using Application.Requests;
using Common.Validation.Implementations;
using Domain.Validation.Abstractions;

namespace Domain.Validation.Implementations;

public class ProductCreateValidationService :
    ValidationServiceBase<ProductCreateRequest>,
    IProductCreateValidationService
{
    protected override IEnumerable<string> DoValidate(ProductCreateRequest product)
    {
        if (IsZeroOrNegative(product.Price))
        {
            Console.WriteLine("Validation: Price is zero");
            yield return "Price should be greater than 0.";
        }

        if (string.IsNullOrWhiteSpace(product.Name))
        {
            Console.WriteLine("Validation: Name is empty");
            yield return "Name should not be empty.";
        }

        if (string.IsNullOrWhiteSpace(product.Description))
        {
            Console.WriteLine("Validation: Description is empty");
            yield return "Description should not be empty.";
        }
    }
}