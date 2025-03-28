using Common.Validation.Abstractions;
using Domain.Models;

namespace Domain.Validation.Abstractions;

public interface IUserValidationService : IValidationService<User>;