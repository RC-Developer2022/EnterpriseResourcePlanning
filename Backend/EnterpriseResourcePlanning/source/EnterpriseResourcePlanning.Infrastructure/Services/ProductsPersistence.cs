using EnterpriseResourcePlanning.Domain.Entities;
using EnterpriseResourcePlanning.Domain.Struct;
using EnterpriseResourcePlanning.Infrastructure.Context;
using EnterpriseResourcePlanning.Infrastructure.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace EnterpriseResourcePlanning.Infrastructure.Services;

public class ProductsPersistence(ErpDbContext context) : IProductsPersistence
{
    
    public async Task<IEnumerable<Products>> GetAllProducts()
    {
        return await context.Products.ToListAsync();
    }

    public async Task<Products> GetProductByCode(string code)
    {
        return await context.Products.Where(p => p.ProductCode.Equals(code)).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Products>> GetProductsByName(string name)
    {
        return await context.Products.Where(p => p.ProductName.Contains(name)).ToListAsync();
    }

    public async Task<Products> GetProductById(CustomerId id)
    {
        return await context.Products.Where(p => p.Id.Equals(id)).FirstOrDefaultAsync();
    }
}
