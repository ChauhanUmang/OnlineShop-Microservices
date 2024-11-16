﻿namespace Basket.API.Basket.GetBasket;

public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;
public record GetBasketResult(ShoppingCart cart);

public class GetBasketQueryHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        // TODO: get basket from the database
        // var basket = await _repository.GetBasket(query.UserName);

        return new GetBasketResult(new ShoppingCart("swn"));
    }
}