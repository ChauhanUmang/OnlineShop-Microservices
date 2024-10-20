using MediatR;

namespace BuildingBlocks.CQRS;

// Here we have only one interface. As QueryHandler should always return some result.
public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    where TResponse : notnull
{
}
