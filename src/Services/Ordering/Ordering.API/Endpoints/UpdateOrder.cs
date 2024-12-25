﻿using Ordering.Application.Orders.Commands.UpdateOrder;

namespace Ordering.API.Endpoints;

// Accepts a UpdateOrderRequest
// Maps the request to the UpdateOrderCommand
// Sends the command to the corresponding handler
// Returns a success or error response based on the outcome.

public record UpdateOrderRequest(OrderDto Order);
public record UpdateOrderResponse(bool IsSuccess);

public class UpdateOrder : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/orders", async(UpdateOrderRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateOrderCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<UpdateOrderResponse>();

            return Results.Ok(response);
        })
        .WithName("UpdateOrder")
        .WithDescription("Update Order")
        .WithSummary("Update Order")
        .Produces<UpdateOrderResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest);
    }
}
