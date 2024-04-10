using EnterpriseResourcePlanning.Domain.Abstractions;

namespace EnterpriseResourcePlanning.Infrastructure.Interfaces;

public interface IRepositoryBase<TEntity> where TEntity : Entity
{
    Task AddAasync(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(TEntity entity);
}
