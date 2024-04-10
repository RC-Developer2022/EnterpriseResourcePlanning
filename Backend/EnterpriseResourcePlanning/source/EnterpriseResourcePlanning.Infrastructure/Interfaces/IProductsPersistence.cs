using EnterpriseResourcePlanning.Domain.Entities;

namespace EnterpriseResourcePlanning.Infrastructure.Interfaces;

public interface IProductsPersistence
{
    Task<IEnumerable<Products>> GetAllProducts();
    Task<Products> GetProductsByCode(string code);
    Task<IEnumerable<Products>> GetProductsByName(string name);
}
