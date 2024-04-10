using EnterpriseResourcePlanning.Domain.Entities;
using EnterpriseResourcePlanning.Domain.Struct;

namespace EnterpriseResourcePlanning.Infrastructure.Interfaces;

public interface IProductsPersistence
{
    Task<IEnumerable<Products>> GetAllProducts();
    Task<Products> GetProductByCode(string code);
    Task<IEnumerable<Products>> GetProductsByName(string name);
    Task<Products> GetProductById(CustomerId id);
}
