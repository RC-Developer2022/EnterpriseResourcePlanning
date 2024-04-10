using EnterpriseResourcePlanning.Domain.Abstractions;

namespace EnterpriseResourcePlanning.Domain.Entities;

public sealed class Products : Entity
{
    public string ProductName { get;  set; }
    public string ProductCode { get;  set; }
    public decimal Price { get;  set; }

    public Products(){}
    public Products(string productName, string productCode, decimal price)
    {
        ProductName = productName;
        ProductCode = productCode;
        Price = price;
    }
}
