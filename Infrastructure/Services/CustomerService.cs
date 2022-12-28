using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Infrastructure.Mapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Infrastructure.Services;

public class CustomerService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public CustomerService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetCustomerDto>>> GetCustomer()
    {
        // var list = _mapper.Map<List<GetCustomerDto>>(_context.Customers);
        var list = (
            from c in _context.Customers
            join j in _context.Products on c.ProductId equals j.ProductId
            select new GetCustomerDto
            {
                CustomerId = c.CustomerId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                PhoneNumber = c.PhoneNumber,
                ProductId = j.ProductId,
                ProductName = j.ProductName.ToString(),
                ProductPrice = j.ProductPrice,
                ProductPercent = j.ProductPercent
            }
        ).ToList();
        return new Response<List<GetCustomerDto>>(list);
    }

    public async Task<Response<AddCustomerDto>> AddCustomer(AddCustomerDto customer)
    {
        var newCustomer = _mapper.Map<Customer>(customer);
        _context.Add(newCustomer);
        await _context.SaveChangesAsync();
        return new Response<AddCustomerDto>(customer);
    }

    public double InstallmentAmount(ProductName productName, int Diapason, double productPrice)
    {
        if( productName == ProductName.SmartPhone )
        {
            if( Diapason == 3 || Diapason == 6 || Diapason == 9 )
            {
                return productPrice;
            }
            else //   ((100 ) * productPrice)/100
            {
                if ( Diapason == 12 ) return (((100 + (int)(ProductPercent.m3)) * (productPrice))/100);
                else
                {
                    if( Diapason == 18 ) return (((100 + 2*(int)(ProductPercent.m3)) * (productPrice))/100);
                    else
                    {
                        if( Diapason == 24 ) return (((100 + 3*(int)(ProductPercent.m3)) * (productPrice))/100);
                    }
                }
            }
        }
        else
        {
            if( productName == ProductName.Computer )
            {
                if( Diapason == 3 || Diapason == 6 || Diapason == 9 || Diapason == 12 )
                {
                    return productPrice;
                }
                else
                {
                    if ( Diapason == 18 ) return (((100 + (int)(ProductPercent.m4)) * (productPrice))/100);
                    else
                    {
                        if( Diapason == 24 ) return (((100 + 2*(int)(ProductPercent.m4)) * (productPrice))/100);
                    }
                }
            }
            else
            {
                if( productName == ProductName.Television)
                {
                    if( Diapason == 3 || Diapason == 6 || Diapason == 9 || Diapason == 12 || Diapason == 18 )
                    {
                        return productPrice;
                    }
                    else
                    {
                        if ( Diapason == 24 ) return (((100 + (int)(ProductPercent.m5)) * (productPrice))/100);
                    }
                }
            }
        }
        return 0;
    }

    public async Task<Response<AddCustomerDto>> UpdateCustomer(AddCustomerDto customer)
    {
        var find = await _context.Customers.FindAsync(customer.CustomerId);
        find.CustomerId = customer.CustomerId;
        find.FirstName = customer.FirstName;
        find.LastName = customer.LastName;
        find.PhoneNumber = customer.PhoneNumber;
        find.ProductId = customer.ProductId;
        await _context.SaveChangesAsync();
        return new Response<AddCustomerDto>(customer);
    }

    public async Task<Response<string>> DeleteCustomer(int id)
    {
        var find = await _context.Customers.FindAsync(id);
        _context.Customers.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Customer successfully deleted");

    }

    public async Task<Response<List<GetCustomerDto>>> GetCustomerCreditById(int id, ProductPercent productPercent, int productDiapason, int productPrice, ProductName productName)
    {
        // InstallmentAmount( ProductName.SmartPhone, 12, 3500);
        // var find = await _context.Customers.FindAsync(id);
        var list = await (
            from c in _context.Customers
            join p in _context.Products on c.ProductId equals p.ProductId
            where c.CustomerId == id
            select new GetCustomerDto
            {
                CustomerId = c.CustomerId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                PhoneNumber = c.PhoneNumber,
                ProductId = p.ProductId,
                ProductName = p.ProductName.ToString(),
                ProductPrice = InstallmentAmount(productName,productDiapason,productPrice),
                ProductPercent = p.ProductPercent,
                ProductDiapason = productDiapason
            }
        ).ToListAsync();
        return new Response<List<GetCustomerDto>>(list);
    }
}
