using Microsoft.EntityFrameworkCore.Storage;

namespace EnterpriseResourcePlanning.Infrastructure.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IDbContextTransaction BeginTransaction();
    Task<bool> CommitAsync();
    Task RollbackAsync();
}
