using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Domain.Entities;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CustomerController
{
    private readonly CustomerService _customerService;
    public CustomerController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("GetCustomer")]
    public async Task<Response<List<GetCustomerDto>>> GetCustomer()
    {
        return await _customerService.GetCustomer();
    }

    [HttpGet("GetCustomerCreditById")]
    public async Task<Response<List<GetCustomerDto>>> GetCustomerCreditById(int id, ProductPercent productPercent, int productDiapason, int productPrice, ProductName productName)
    {
        return await _customerService.GetCustomerCreditById(id,productPercent,productDiapason,productPrice, productName);
    }

    [HttpPost("AddCustomer")]
    public async Task<Response<AddCustomerDto>> AddCustomer(AddCustomerDto customer)
    {
        return await _customerService.AddCustomer(customer);
    }

    [HttpPut("UpdateCurtomer")]
    public async Task<Response<AddCustomerDto>> UpdateCurtomer(AddCustomerDto customer)
    {
        return await _customerService.UpdateCustomer(customer);
    }

    [HttpDelete("DeleteCustomer")]
    public async Task<Response<string>> DeleteCustomer(int id)
    {
        return await _customerService.DeleteCustomer(id);
    }
}