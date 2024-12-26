using BuildingBlocks.Messaging.Events;
using MassTransit;
using Ordering.Application.Orders.Commands.CreateOrder;

namespace Ordering.Application.Orders.EventHandlers.Integration;

public class BasketCheckoutEventHandler(ISender sender, ILogger<BasketCheckoutEventHandler> logger) 
    : IConsumer<BasketCheckoutEvent>
{
    public async Task Consume(ConsumeContext<BasketCheckoutEvent> context)
    {
        // TODO: Create new order adn start order fulfilment process
        logger.LogInformation($"Integration Event Handled:{context.Message.GetType().Name}");

        var command = MapToCreateOrderCommand(context.Message);
        await sender.Send(command);
    }

    private CreateOrderCommand MapToCreateOrderCommand(BasketCheckoutEvent message)
    {
        // Create full order with the incoming data
        var addressDto = new AddressDto(
            message.FirstName,
            message.LastName,
            message.EmailAddress,
            message.AddressLine,
            message.Country,
            message.State,
            message.ZipCode
            );

        var paymentDto = new PaymentDto(
            message.CardName,
            message.CardNumber,
            message.Expiration,
            message.CVV,
            message.PaymentMethod
            );

        var orderId = Guid.NewGuid();

        var orderDto = new OrderDto(
            Id: orderId,
            CustomerId: message.CustomerId,
            OrderName: message.UserName,
            ShippingAddress: addressDto,
            BillingAddress: addressDto,
            Payment: paymentDto,
            Status: Ordering.Domain.Enums.OrderStatus.Pending,
            OrderItems:
            [
                new OrderItemDto(orderId, new Guid("ac55536d-7e23-4826-a53d-8b8e7f29d5f9"), 2, 500),
                new OrderItemDto(orderId, new Guid("f23a2cad-a23c-418b-8908-9a6b5228967b"), 1, 400)
            ]);

        return new CreateOrderCommand(orderDto);
    }
}
