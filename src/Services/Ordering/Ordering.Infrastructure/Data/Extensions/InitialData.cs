namespace Ordering.Infrastructure.Data.Extensions;

public class InitialData
{
    public static IEnumerable<Customer> Customers =>
        new List<Customer>
        {
            Customer.Create(CustomerId.Of(new Guid("722576ef-ac00-4a8e-808c-c145ef2d8ad0")), "testName1", "test1@gmail.com"),
            Customer.Create(CustomerId.Of(new Guid("257533ac-afa1-476a-bb2c-d9ca637c550c")), "testName2", "test2@gmail.com" )
        };

    public static IEnumerable<Product> Products =>
        new List<Product>
        {
            Product.Create(ProductId.Of(new Guid("ac55536d-7e23-4826-a53d-8b8e7f29d5f9")), "IPhone X", 500),
            Product.Create(ProductId.Of(new Guid("d5a6eb52-0196-4b4c-b670-dad1bab6a259")), "Huawei Plus", 650),
            Product.Create(ProductId.Of(new Guid("f23a2cad-a23c-418b-8908-9a6b5228967b")), "Samsung 10", 400),
            Product.Create(ProductId.Of(new Guid("ff34bc79-2c99-4d08-809e-2259eb528b1b")), "Xiaomi Mi", 450)
        };

    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            var address1 = Address.Of("testName1", "testLName1", "test1@gmail.com", "testAL1", "testCountry1", "testState1", "123456");
            var address2 = Address.Of("testName2", "testLName2", "test2@gmail.com", "testAL2", "testCountry2", "testState2", "223456");

            var payment1 = Payment.Of("testName1", "5555555555554444", "12/28", "355", 1);
            var payment2 = Payment.Of("testName2", "8888555577773333", "06/30", "222", 2);

            var order1 = Order.Create(
                            OrderId.Of(Guid.NewGuid()),
                            CustomerId.Of(new Guid("722576ef-ac00-4a8e-808c-c145ef2d8ad0")),
                            OrderName.Of("ORD_1"),
                            shippingAddress: address1,
                            billingAddress: address1,
                            payment1);

            order1.Add(ProductId.Of(new Guid("ac55536d-7e23-4826-a53d-8b8e7f29d5f9")), 2, 500);
            order1.Add(ProductId.Of(new Guid("d5a6eb52-0196-4b4c-b670-dad1bab6a259")), 1, 650);

            var order2 = Order.Create(
                            OrderId.Of(Guid.NewGuid()),
                            CustomerId.Of(new Guid("257533ac-afa1-476a-bb2c-d9ca637c550c")),
                            OrderName.Of("ORD_2"),
                            shippingAddress: address2,
                            billingAddress: address2,
                            payment2);

            order2.Add(ProductId.Of(new Guid("f23a2cad-a23c-418b-8908-9a6b5228967b")), 2, 400);
            order2.Add(ProductId.Of(new Guid("ff34bc79-2c99-4d08-809e-2259eb528b1b")), 3, 450);

            return new List<Order> { order1, order2 };
        }
    }

}
