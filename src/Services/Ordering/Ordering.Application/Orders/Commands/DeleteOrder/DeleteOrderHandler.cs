
namespace Ordering.Application.Orders.Commands.DeleteOrder;

internal class DeleteOrderHandler (IApplicationDbContext dbContext)
    : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
{
    public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        // Get Order by the orderID provided in command object
        var orderId = OrderId.Of(command.OrderId);
        var order = await dbContext.Orders.FindAsync([orderId], cancellationToken);

        if(order is null)
        {
            throw new OrderNotFoundException(command.OrderId);
        }

        // delete order from the database
        dbContext.Orders.Remove(order);
        // save the database
        await dbContext.SaveChangesAsync(cancellationToken);
        // return result
        return new DeleteOrderResult(true);
    }
}
