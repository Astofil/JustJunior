using Domain.Entities;

namespace Domain.Dtos;

public class GetCustomerDto
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }

    //------------------------------------
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public double ProductPrice { get; set; }
    public ProductPercent ProductPercent { get; set; }
    public int ProductDiapason { get; set; }

}


public class AddCustomerDto
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }

    public int ProductId { get; set; }
}