using Domain.Customers;
using Domain.Products;

namespace Domain.Orders;

public class Order
{
    private readonly HashSet<LineItem> _lineItems = new();
    private Order()
    {

    }
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }

    public static Order Create(Customer customer)
    {
        var order = new Order()
        {
            Id = Guid.NewGuid(),
            CustomerId = customer.Id
        };

        return order;
    }
    public void Add(Book book)
    {
        var lineItem = new LineItem(Guid.NewGuid(), Id, book.Id, book.Price);

        _lineItems.Add(lineItem);
    }
}

public class LineItem
{
    internal LineItem(Guid id,
                      Guid orderId,
                      Guid bookId,
                      Money price)
    {
        Id = id;
        OrderId = orderId;
        BookId = bookId;
        Price = price;
    }
    public Guid Id { get; private set; }
    public Guid OrderId { get; private set; }
    public Guid BookId { get; private set; }
    public Money Price { get; private set; }
}
