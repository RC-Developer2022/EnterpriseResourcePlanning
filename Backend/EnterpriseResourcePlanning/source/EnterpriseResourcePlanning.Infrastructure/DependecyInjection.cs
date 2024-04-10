using EnterpriseResourcePlanning.Infrastructure.Context;
using EnterpriseResourcePlanning.Infrastructure.Interfaces;
using EnterpriseResourcePlanning.Infrastructure.Services;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EnterpriseResourcePlanning.Infrastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration) 
    {
        service.AddDbContext<ErpDbContext>(opitons => opitons.UseNpgsql(configuration.GetConnectionString("default")));
        service.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        service.AddScoped<IUnitOfWork, UnitOfWork>();
        service.AddScoped<IProductsPersistence, ProductsPersistence>();

        return service;
    }
}
