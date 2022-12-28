using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class ProductController
{
    private readonly ProductService _productService;
    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("GetProduct")]
    public async Task<Response<List<GetProductDto>>> GetProduct()
    {
        return await _productService.GetProduct();
    }

    [HttpPost("AddProduct")]
    public async Task<Response<AddProductDto>> AddProduct(AddProductDto product)
    {
        return await _productService.AddProduct(product);
    }

    [HttpPut("UpdateProduct")]
    public async Task<Response<AddProductDto>> UpdateProduct(AddProductDto product)
    {
        return await _productService.UpdateProduct(product);
    }

    [HttpDelete("DeleteProduct")]
    public async Task<Response<string>> DeleteProduct(int id)
    {
        return await _productService.DeleteProduct(id);
    }
}