using Application.DTOs;
using Application.Mappers.Abstractions;
using Common.Mappers;
using Domain.Models;

namespace Application.Mappers.Implementations;

public class UserDtoMapper: TwoWayMapperBase<UserDto, User>, IUserDtoMapper
{
    public override UserDto Map(User obj)
    {
        throw new NotImplementedException();
    }

    public override User Map(UserDto obj)
    {
        throw new NotImplementedException();
    }
}