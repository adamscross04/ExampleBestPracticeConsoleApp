using Common.Validation.Implementations;
using Domain.Models;
using Domain.Validation.Abstractions;

namespace Domain.Validation.Implementations;

public class UserValidationService : ValidationServiceBase<User>, IUserValidationService
{
    protected override IEnumerable<string> DoValidate(User user)
    {
        if (string.IsNullOrWhiteSpace(user.FirstName))
        {
            yield return "First name is required.";
        }

        if (string.IsNullOrWhiteSpace(user.LastName))
        {
            yield return "Last name is required.";
        }

        if (string.IsNullOrWhiteSpace(user.Email))
        {
            yield return "Email is required.";
        }

        if (string.IsNullOrWhiteSpace(user.PhoneNumber))
        {
            yield return "Phone number is required.";
        }

        if (string.IsNullOrWhiteSpace(user.Address))
        {
            yield return "Address is required.";
        }
    }
}