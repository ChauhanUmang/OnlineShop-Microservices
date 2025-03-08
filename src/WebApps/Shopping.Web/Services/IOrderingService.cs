namespace Shopping.Web.Services;

public interface IOrderingService
{
    [Get("/ordering-service/orders?pageIndex={pageIndex}&pageSize={pageSize}")]
    Task<GetOrdersResponse> GetOrders(int? pageIndex = 1, int? pageSize = 10);

    [Get("/ordering-service/orders/{ordername}")]
    Task<GetOrdersByNameResponse> GetOrdersByName(string ordername);

    [Get("/ordering-service/orders/customer/{customerid}")]
    Task<GetOrdersByCustomerResponse> GetOrdersByCustomer(Guid customerid);
}
