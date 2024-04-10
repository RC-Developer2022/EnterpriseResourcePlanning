using EnterpriseResourcePlanning.Infrastructure.Context;
using EnterpriseResourcePlanning.Infrastructure.Interfaces;

using Microsoft.EntityFrameworkCore.Storage;

namespace EnterpriseResourcePlanning.Infrastructure.Services;

public class UnitOfWork : IUnitOfWork
{
    private readonly ErpDbContext _context;
    private IDbContextTransaction _transaction;
    public UnitOfWork(ErpDbContext context)
    {
        _context = context;
    }

    public IDbContextTransaction BeginTransaction()
    {
        _transaction = _context.Database.BeginTransaction();
        return _transaction;
    }

    public async Task<bool> CommitAsync()
    {
        try
        {
            await _transaction.CommitAsync();
            
            return await _context.SaveChangesAsync() > 0;
        }
        catch (Exception ex)
        {
            _transaction?.Dispose();
            return false;
        }
        finally
        {
            _transaction = null;
        }
    }

    public Task RollbackAsync()
    {
        _transaction?.Rollback();
        _transaction?.Dispose();
        _transaction = null;
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
