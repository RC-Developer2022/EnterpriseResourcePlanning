using EnterpriseResourcePlanning.Application.Interfaces;
using EnterpriseResourcePlanning.Domain.Entities;
using EnterpriseResourcePlanning.Infrastructure.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EnterpriseResourcePlanning.Application.Services;

public class ProductsServices(
    IRepositoryBase<Products> repository,
    IProductsPersistence persistence,
    IUnitOfWork unitOfWork
    ) : IProductsServices
{
    

    public Task<IEnumerable<Products>> GetAllProducts()
    {
        try
        {
            var products = persistence.GetAllProducts();
            return products;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<Products> GetProductsByCode(string code)
    {
        try
        {
            var product = await persistence.GetProductsByCode(code);
            return product;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<Products>> GetProductsByName(string name)
    {
        try
        {
            var products = await persistence.GetProductsByName(name);
            return products;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<Products> AddAasync(Products product)
    {
        try
        {
            unitOfWork.BeginTransaction();
            await repository.AddAasync( product );
            var result = await unitOfWork.CommitAsync();

            if (!result) throw new Exception("Unable to save product");

            return product;
        }
        catch (Exception ex)
        {
            await unitOfWork.RollbackAsync();
            throw new Exception(ex.Message);
        }
        finally
        {
            unitOfWork.Dispose();
        }
    }

    public async Task<Products> UpdateAsync(Products product)
    {
        try
        {
            unitOfWork.BeginTransaction();
            _ = repository.Update(product);
            var result =  await unitOfWork.CommitAsync();

            if (!result) throw new Exception("Unable to save product");

            return product;
        }
        catch (Exception ex)
        {
            await unitOfWork.RollbackAsync();
            throw new Exception(ex.Message);
        }
        finally
        {
            unitOfWork.Dispose();
        }
    }

    public async Task<Products> DeleteAsync(Products product)
    {
        try
        {
            unitOfWork.BeginTransaction();
            _ = repository.Delete(product);
            var result = await unitOfWork.CommitAsync();

            if (!result) throw new Exception("Unable to save product");

            return product;
        }
        catch (Exception ex)
        {
            await unitOfWork.RollbackAsync();
            throw new Exception(ex.Message);
        }
        finally
        {
            unitOfWork.Dispose();
        }
    }
}
