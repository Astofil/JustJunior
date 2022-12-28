using Domain.Entities;

namespace Domain.Dtos;

public class GetProductDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public int ProductPrice { get; set; }
    public ProductPercent ProductPercent { get; set; }
    public int ProductDiapason { get; set; }

}


public class AddProductDto
{
    public int ProductId { get; set; }
    public ProductName ProductName { get; set; }
    public int ProductPrice { get; set; }
    public ProductPercent ProductPercent { get; set; }
    public int ProductDiapason { get; set; }
}