using MediatR;

namespace BuildingBlocks.CQRS;

// Interface for CommandHandler where we do not return any response. For response, we have used Unit.
public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit>
    where TCommand : ICommand<Unit>
{
}

// Interface for CommandHandler getting the Response object and this response object is not null
public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
    where TResponse : notnull
{
}
