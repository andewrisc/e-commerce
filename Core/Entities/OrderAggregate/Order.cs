namespace Core.Entities.OrderAggregate;

public class Order : BaseEntity
{
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public required string BuyerEmail { get; set; }
    public ShippingAddress ShippingAddress { get; set; } = null!;
    public DeliveryMethod DeliveryMethod { get; set; } = null!;
    public PaymentSummary PaymentSummary { get; set; } = null!;
    public List<OrderItem> OrdersItems { get; set; } = [];
    public decimal SubTotal { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public required string PaymentIntentId { get; set; }

    public decimal GetTotal()
    {
        return SubTotal + DeliveryMethod.Price;
    }
}