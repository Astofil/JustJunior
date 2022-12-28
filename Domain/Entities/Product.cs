namespace Domain.Entities;

public class Product
{
    public int ProductId { get; set; }
    public ProductName ProductName { get; set; }
    public int ProductPrice { get; set; }
    public ProductPercent ProductPercent { get; set; }
    public int ProductDiapason { get; set; }

    //--------------Navigation props-------------------
    public virtual List<Customer> Customer { get; set; }
}

public enum ProductPercent
{
    m3 = 3,
    m4 = 4,
    m5 = 5,
}

public enum ProductName{
    SmartPhone = 1,
    Computer,
    Television
}

public enum ProductDiapason
{
    forSixMonths = 6,
    forNineMonths = 9,
    forTwelveMonth = 12,
    forEighteenMonth = 18,
    forTwentyFourMonth = 24,
}