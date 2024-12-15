namespace Ordering.Infrastructure.Data.Extensions;

public class InitialData
{
    public static IEnumerable<Customer> Customers =>
        new List<Customer>
        {
            Customer.Create(CustomerId.Of(new Guid("722576ef-ac00-4a8e-808c-c145ef2d8ad0")), "testName1", "test1@gmail.com"),
            Customer.Create(CustomerId.Of(new Guid("257533ac-afa1-476a-bb2c-d9ca637c550c")), "testName2", "test2@gmail.com" )
        };
}
