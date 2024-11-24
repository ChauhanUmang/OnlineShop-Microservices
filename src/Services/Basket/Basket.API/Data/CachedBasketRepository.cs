namespace Basket.API.Data;

//Basically, we will implement two patterns here: Proxy and Decorator.
// Proxy Pattern: CachedBasketRepository acts a proxy and forwards the requests to the underlying BasketRepository

public class CachedBasketRepository (IBasketRepository repository)
    : IBasketRepository
{
    public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
    {
        return await repository.GetBasket(userName, cancellationToken);
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
    {
        return await repository.StoreBasket(basket, cancellationToken);
    }

    public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
    {
        return await repository.DeleteBasket(userName, cancellationToken);
    }
}
