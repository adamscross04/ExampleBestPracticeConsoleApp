using Common.Mappers.Abstractions;
using Data.Entities;
using Domain.Models;

namespace Data.Mappers.Abstractions;

public interface IUserEntityMapper: ITwoWayMapper<UserEntity, User>;