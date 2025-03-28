using Application.DTOs;
using Common.Mappers.Abstractions;
using Domain.Models;

namespace Application.Mappers.Abstractions;

public interface IUserDtoMapper: ITwoWayMapper<UserDto, User>;