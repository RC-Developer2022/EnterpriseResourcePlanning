using EnterpriseResourcePlanning.Domain.Abstractions;
using EnterpriseResourcePlanning.Infrastructure.Context;
using EnterpriseResourcePlanning.Infrastructure.Interfaces;

namespace EnterpriseResourcePlanning.Infrastructure.Services;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
{
    private readonly ErpDbContext _context;
    public RepositoryBase(ErpDbContext context)
    {
        _context = context;
    }
    public async Task AddAasync(TEntity entity)
    {
        await _context.AddAsync(entity);
    }
    public Task Update(TEntity entity)
    {
        _context.Update(entity);
        return Task.CompletedTask;
    }

    public Task Delete(TEntity entity)
    {
        _context.Remove(entity);
        return Task.CompletedTask;
    }
}
