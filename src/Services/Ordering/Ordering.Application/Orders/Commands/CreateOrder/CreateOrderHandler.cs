using BuildingBlocks.CQRS;

namespace Ordering.Application.Orders.Commands.CreateOrder;

internal class CreateOrderHandler : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        // Create order entity from command object
        // save to database
        // return result

        throw new NotImplementedException();
    }
}
