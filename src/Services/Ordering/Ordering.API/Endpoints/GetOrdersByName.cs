using Ordering.Application.Orders.Queries.GetOrdersByName;

namespace Ordering.API.Endpoints;

// Accepts a name parameter
// Constructs a GetOrdersByNameQuery object
// Retrieves and returns matching orders.

//public record GetOrdersByNameRequest(string Name);
public record GetOrdersByNameResponse(IEnumerable<OrderDto> Orders);

public class GetOrdersByName : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/orders/{ordername}", async (string ordername, ISender sender) =>
        {
            var result = await sender.Send(new GetOrdersByNameQuery(ordername));
            var response = result.Adapt<GetOrdersByNameResponse>();
            return Results.Ok(response);
        })
        .WithName("GetOrdersByName")
        .WithDescription("Get Orders By Name")
        .WithSummary("Get Orders By Name")
        .Produces<GetOrdersByNameResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
