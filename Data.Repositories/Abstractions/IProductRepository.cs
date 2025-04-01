using Common.Repository.Create;
using Common.Repository.Read;
using Common.Repository.Update;
using Domain.Models;

namespace Data.Repositories.Abstractions;

public interface IProductRepository: 
    IReadSingleById<Product>,
    IReadMultipleByIds<Product>,
    IUpdateSingle<Product>,
    ICreateSingle<Product>;