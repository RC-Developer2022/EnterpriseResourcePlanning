using EnterpriseResourcePlanning.Domain.Abstractions;
using EnterpriseResourcePlanning.Domain.Entities;
using EnterpriseResourcePlanning.Domain.Struct;
using EnterpriseResourcePlanning.Infrastructure.Interfaces;

namespace EnterpriseResourcePlanning.Application.Interfaces;

public interface IProductsServices 
{
    Task<IEnumerable<Products>> GetAllProducts();
    Task<Products> GetProductsByCode(string code);
    Task<IEnumerable<Products>> GetProductsByName(string name);
    Task<Products> GetProductById(CustomerId id);
    Task<Products> AddAasync(Products product);
    Task<Products> UpdateAsync(Products product);
    Task<Products> DeleteAsync(Products product);
}
