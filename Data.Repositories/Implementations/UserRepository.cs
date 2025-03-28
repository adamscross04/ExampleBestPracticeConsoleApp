using Data.Dapper.Extensions.Abstractions;
using Data.Entities;
using Data.Mappers.Abstractions;
using Data.Repositories.Abstractions;
using Domain.Models;

namespace Data.Repositories.Implementations;

public class UserRepository(IDbConnectionWrapper dbConnectionWrapper, IUserEntityMapper userEntityMapper) : IUserRepository
{
    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        const string query = "SELECT top(1) * FROM users WHERE username = @username";
        var result = await dbConnectionWrapper.QuerySingleOrDefaultAsync<UserEntity>(query, new { username});
        return result == null ? null : userEntityMapper.Map(result);
    }
}