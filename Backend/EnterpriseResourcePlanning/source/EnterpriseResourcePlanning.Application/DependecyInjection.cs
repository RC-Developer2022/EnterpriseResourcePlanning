using EnterpriseResourcePlanning.Application.Interfaces;
using EnterpriseResourcePlanning.Application.Services;

using Microsoft.Extensions.DependencyInjection;

namespace EnterpriseResourcePlanning.Application;

public static class DependecyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service) 
    {
        service.AddScoped<IProductsServices, ProductsServices>();
        return service;
    }
}
