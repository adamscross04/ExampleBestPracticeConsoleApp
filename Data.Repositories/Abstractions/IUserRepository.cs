using Domain.Models;

namespace Data.Repositories.Abstractions;

public interface IUserRepository
{
    Task<User?> GetUserByUsernameAsync(string username);
}