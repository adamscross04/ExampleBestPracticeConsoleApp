using Application.DTOs;
using Common.Mappers.Abstractions;
using Domain.Models;

namespace Application.Mappers.Abstractions;

public interface IProductDtoMapper: ITwoWayMapper<ProductDto, Product>;