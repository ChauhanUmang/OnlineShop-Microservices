using Ordering.Application.Orders.Commands.DeleteOrder;

namespace Ordering.API.Endpoints;

// Accepts the OrderID as a parameter
// Construct a DeleteOrderCommand object
// Send the command to the corresponding handler.
// Returns a success or not found response.

//public record DeleteOrderRequest(Guid OrderId);
public record DeleteOrderResponse(bool IsSuccess);

public class DeleteOrder : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/orders/{id}", async(Guid id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteOrderCommand(id));
            var response = result.Adapt<DeleteOrderResponse>();
            return Results.Ok(response);
        })
        .WithName("DeleteOrder")
        .WithDescription("Delete Order")
        .WithSummary("Delete Order")
        .Produces<DeleteOrderResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
