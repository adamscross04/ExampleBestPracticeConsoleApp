using Application.DTOs;
using Application.Mappers.Abstractions;
using Application.Requests;
using Common.Exceptions;
using Domain.Models;
using Domain.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Application.WebApi.Controllers;

[Route("api/products")]
[ApiController]
public class ProductController(IProductService productService, IProductDtoMapper productDtoMapper) : ControllerBase
{
    [HttpGet("filter")]
    public async Task<IActionResult> GetProducts()
    {
        try
        {
            IEnumerable<ProductDto> products = productDtoMapper.Map(await productService.GetProducts());
            return Ok(products);
        }
        catch(Exception e)
        { 
            // Log exception (ex) here as needed.
            Console.WriteLine(e.Message);
            return StatusCode(500, "An unexpected error occurred.");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        try
        {
            Product? domainProduct = await productService.GetProduct(id);
            
            if (domainProduct is null)
            {
                return NotFound($"Product with ID {id} not found.");
            }

            ProductDto product = productDtoMapper.Map(domainProduct);
            return Ok(product);
        }
        catch(Exception e)
        {
            // Log exception (ex) here as needed.
            return StatusCode(500, "An unexpected error occurred.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductCreateRequest productCreateRequest)
    {
        try
        {
            await productService.CreateProduct(productCreateRequest);
            return Created();
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Errors);
        }
        catch(Exception e)
        {
            // Log exception (ex) here as needed.
            return StatusCode(500, "An unexpected error occurred.");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] ProductDto productDto)
    {
        try
        {
            Product? product = await productService.UpdateProduct(id, productDtoMapper.Map(productDto));
            return Ok(product);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Errors);
        }
        catch(Exception e)
        {
            // Log exception (ex) here as needed.
            return StatusCode(500, "An unexpected error occurred.");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        try
        {
            await productService.DeleteProduct(id);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch(Exception e)
        {
            // Log exception (ex) here as needed.
            return StatusCode(500, "An unexpected error occurred.");
        }
    }
}
