using Application.DTOs;
using Application.Mappers.Abstractions;
using Common.Exceptions;
using Domain.Models;
using Domain.Services.Abstractions;
using Microsoft.AspNetCore.SignalR;

namespace Application.SignalR.Hubs;

public class ProductHub(IProductService productService, IProductDtoMapper productDtoMapper) : Hub
{
    public async Task FilterProducts()
    {
        await Clients.All.SendAsync("GetProducts");
    }

    public async Task GetProduct(int id)
    {
        await Clients.All.SendAsync("GetProduct", id);
    }

    public async Task CreateProduct(ProductDto productDto)
    {
        try
        {
            Product product = await productService.CreateProduct(productDtoMapper.Map(productDto));
        }
        catch (ValidationException e)
        {
        }
    }

    public async Task UpdateProduct(int id, object product)
    {
        await Clients.All.SendAsync("UpdateProduct", id, product);
    }

    public async Task DeleteProduct(int id)
    {
        await Clients.All.SendAsync("DeleteProduct", id);
    }
    
}