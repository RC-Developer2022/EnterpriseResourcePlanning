using EnterpriseResourcePlanning.Application.Interfaces;
using EnterpriseResourcePlanning.Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace EnterpriseResourcePlanning.Api.Endpoints;

public static class EndpointProducts
{
    public static void UseProducts(this WebApplication app) 
    {
        app.MapPost("/register/product", RegisterProduct).WithOpenApi().WithName("Register Product");
        app.MapGet("/register/products/{name}", GetProductsName).WithOpenApi().WithName("Get Products");
    }

    public static async Task<IResult> GetProductsName([FromServices] IProductsServices service, [FromHeader] string name) 
    {
        var product = await service.GetProductsByName(name);
        if (product == null) return Results.BadRequest();

        return Results.Ok(product);
    }

    public static async Task<IResult> RegisterProduct([FromServices]IProductsServices serivce, [FromBody]Products product) 
    {
        await serivce.AddAasync(product);

        return Results.Created($"O produto {product.ProductName} foi adicionado", product.ProductName);
    }
}
