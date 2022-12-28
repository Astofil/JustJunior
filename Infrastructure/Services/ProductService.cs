using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Infrastructure.Services;

public class ProductService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public ProductService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetProductDto>>> GetProduct()
    {
        var list = _mapper.Map<List<GetProductDto>>(_context.Products);
        // var list = _context.Products.Select(t => new GetProductDto
        // {
        //     ProductId = t.ProductId,
        //     ProductName = t.ProductName.ToString(),
        // }).ToList();
        return new Response<List<GetProductDto>>(list);
    }

    public async Task<Response<AddProductDto>> AddProduct(AddProductDto product)
    {
        var newProduct = _mapper.Map<Product>(product);
        _context.Add(newProduct);
        await _context.SaveChangesAsync();
        return new Response<AddProductDto>(product);
    }

    public async Task<Response<AddProductDto>> UpdateProduct(AddProductDto product)
    {
        var find = await _context.Products.FindAsync(product.ProductId);
        find.ProductId = product.ProductId;
        find.ProductName = product.ProductName;
        find.ProductPrice = product.ProductPrice;
        find.ProductPercent = product.ProductPercent;
        await _context.SaveChangesAsync();
        return new Response<AddProductDto>(product);
    }

    public async Task<Response<string>> DeleteProduct(int id)
    {
        var find = await _context.Products.FindAsync(id);
        _context.Products.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Product successfully deleted");

    }
}