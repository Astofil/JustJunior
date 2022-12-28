namespace Domain.Entities;

public class Customer
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }

    //--------Navigation props-----------
    public int ProductId { get; set; }
    public Product Product { get; set; }
}
