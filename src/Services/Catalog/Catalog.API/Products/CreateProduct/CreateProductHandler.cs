namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) 
    : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

// Injected IDocumentSession directly in the CommandHandler class using Primary Constructor feature
// Because IDocumentSession is already an abstraction of database operations.So, we don't need any additional
// abstractions or unnecessary code like repository pattern.
internal class CreateProductCommandHandler(IDocumentSession session) 
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // Create Product entity from the command object
        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };
        // Save the entity in the database
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        // Return the result i.e.CreateProductResult
        return new CreateProductResult(product.Id);
    }
}
