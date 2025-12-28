using BuildingBlocks.CQRS;
using Catalog.API.Models;
using Marten;
using MediatR;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    :ICommand<CreateProdcutResult>;
public record CreateProdcutResult(Guid Id);

internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProdcutResult>
{
    public async Task<CreateProdcutResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //Create Product Entity From Command object
        var product = new Product()
        {
            Name=command.Name,
            Category=command.Category,
            Description=command.Description,
            ImageFile=command.ImageFile,
            Price=command.Price
        };

        //Save entity to Database
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        //Return CreateProdcutResult
        return new CreateProdcutResult(product.Id);
    }
}
