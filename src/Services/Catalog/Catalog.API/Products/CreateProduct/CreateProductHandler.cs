using MediatR;

namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
    :IRequest<CreateProdcutResult>;
public record CreateProdcutResult(Guid Id);

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProdcutResult>
{
    public Task<CreateProdcutResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
