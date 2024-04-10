using EnterpriseResourcePlanning.Application.Interfaces;
using EnterpriseResourcePlanning.Domain.Entities;
using EnterpriseResourcePlanning.Domain.Struct;

using Microsoft.AspNetCore.Mvc;

namespace EnterpriseResourcePlanning.Api.Endpoints;

public static class EndpointProducts
{
    public static void UseProducts(this WebApplication app) 
    {
        app.MapGet("/register/products", GetAllProducts).WithOpenApi().WithName("Get all products");
        app.MapGet("/register/products/{name}", GetProductsName).WithOpenApi().WithName("Get Products by name");
        app.MapGet("/register/product/{code}", GetProductCode).WithOpenApi().WithName("Get Products by code");
        app.MapPost("/register/product", RegisterProduct).WithOpenApi().WithName("Register Product");
        app.MapPut("/register/products", UpdateProduct).WithOpenApi().WithName("Update Product");
        app.MapDelete("/register/products/delete/{id}", DeleteProduct).WithOpenApi().WithName("Delete Product");
    }

    public static async Task<IResult> GetAllProducts([FromServices] IProductsServices service) 
    {
        var products = await service.GetAllProducts();
        return Results.Ok(products);
    }

    public static async Task<IResult> GetProductsName([FromServices] IProductsServices service, [FromHeader] string name) 
    {
        var product = await service.GetProductsByName(name);
        if (product == null) return Results.BadRequest();

        return Results.Ok(product);
    }

    public static async Task<IResult> GetProductCode([FromServices] IProductsServices service, [FromHeader] string code) 
    {
        var product = await service.GetProductsByCode(code);
        return Results.Ok(product);
    }

    public static async Task<IResult> RegisterProduct([FromServices]IProductsServices serivce, [FromBody]Products product) 
    {
        await serivce.AddAasync(product);

        return Results.Created($"The product:{product.ProductName} was successfully added!", product.ProductName);
    }

    public static async Task<IResult> UpdateProduct([FromServices] IProductsServices service, [FromBody]Products product) 
    {
        await service.UpdateAsync(product);

        return Results.Ok($"The product:{product.ProductName} has beem updated successfully!");
    }

    public static async Task<IResult> DeleteProduct([FromServices] IProductsServices service, [FromHeader] string id) 
    {
        if(CustomerId.TryParse(id, out var customerId)) 
        {
            var product = await service.GetProductById(customerId);
            await service.DeleteAsync(product);
            if (await service.GetProductById(customerId) != null) return Results.Problem("Unable to delete");

            return Results.Ok("Product deleted successfully");
        }
        return Results.BadRequest();
    }
}
