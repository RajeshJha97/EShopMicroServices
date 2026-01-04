namespace Catalog.API.Products.GetProductsByCategory;

public record GetProductByCategoryQuery(string Category):IQuery<GetProductByCategoryResult>;
public record GetProductByCategoryResult(IEnumerable<Product>Product);

internal class GetProductsByCategoryQueryHandler(IDocumentSession session,ILogger<GetProductsByCategoryQueryHandler> logger) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductByCategory Query Handler Invoked {@Query}", query);

        var products = await session.Query<Product>()
            .Where(p=>p.Category.Contains(query.Category))
            .ToListAsync(cancellationToken)??throw new ProductNotFoundException($"Product Not Found With Categroy: {query.Category}");

        if(products.Count==0)
        {
            throw new ProductNotFoundException($"Product Not Found With Categroy: {query.Category}");
        }

        return new GetProductByCategoryResult(products);

    }
}
