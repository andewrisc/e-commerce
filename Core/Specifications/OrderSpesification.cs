using Core.Entities.OrderAggregate;

namespace Core.Specifications;

public class OrderSpesification : BaseSpesification<Order>
{
    public OrderSpesification(string email) : base(x => x.BuyerEmail == email)
    {
        AddInclude(x => x.OrdersItems);
        AddInclude(x => x.DeliveryMethod);
        AddOrderByDescending(x => x.OrderDate);
    }

    public OrderSpesification(string email, int id) : base(x => x.BuyerEmail == email && x.Id == id)
    {
        AddInclude("OrdersItems");
        AddInclude("DeliveryMethod");
    }

    public OrderSpesification(string paymentIntentId, bool isPaymentIntent) : base(x => x.PaymentIntentId == paymentIntentId)
    {
        AddInclude("OrdersItems");
        AddInclude("DeliveryMethod");
    }
}
