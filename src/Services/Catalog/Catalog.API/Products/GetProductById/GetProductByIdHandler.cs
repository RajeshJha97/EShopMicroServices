namespace Catalog.API.Products.GetProductById;

public record GetProductByIdQuery(Guid Id):IQuery<GetProductByIdResult>;
public record GetProductByIdResult(Product Product);

internal class GetProductByIdQueryHandler(IDocumentSession session,ILogger<GetProductByIdQueryHandler> logger) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetQueryById handler invoked with query {@Query}", query);

        var product = await session.LoadAsync<Product>(query.Id, cancellationToken) 
            ?? throw new ProductNotFoundException($"Product Not Found With ID: {query.Id}");

        return new GetProductByIdResult(product);
    }
}
