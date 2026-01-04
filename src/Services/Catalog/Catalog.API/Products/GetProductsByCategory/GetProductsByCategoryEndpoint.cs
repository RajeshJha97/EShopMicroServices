using Catalog.API.Products.GetProducts;

namespace Catalog.API.Products.GetProductsByCategory;

public record GetProductByCategoryResponse(IEnumerable<Product>Product);
public class GetProductsByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}", async (string category,ISender sender) => {

            var response= await sender.Send(new GetProductByCategoryQuery(category));
            var result = response.Adapt<GetProductByCategoryResponse>();

            return Results.Ok(result);
        })
        .WithName("GetProductsByCategory")
        .Produces<GetProductsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products By Category")
        .WithDescription("Get Products By Category");
    }
}
