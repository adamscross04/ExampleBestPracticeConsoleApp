using Common.Mappers;
using Data.Entities;
using Data.Mappers.Abstractions;
using Domain.Models;

namespace Data.Mappers.Implementations;

public class UserEntityMapper: TwoWayMapperBase<UserEntity, User>, IUserEntityMapper
{
    public override UserEntity Map(User obj)
    {
        throw new NotImplementedException();
    }

    public override User Map(UserEntity obj)
    {
        throw new NotImplementedException();
    }
}