using Application.Requests;
using Common.Factories;
using Domain.Models;

namespace Domain.Factories;

public interface IProductFactory: IFactory<ProductCreateRequest, Product>
{
}