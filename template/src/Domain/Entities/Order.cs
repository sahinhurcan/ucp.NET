namespace Domain.Entities;

using Domain.Common;

public class Order : BaseEntity
{
    public string? UserId { get; set; }
    public string UcpOrderId { get; set; } = string.Empty;
    public string State { get; set; } = "pending";
    public List<OrderItem> Items { get; set; } = new();
    public decimal Subtotal { get; set; }
    public decimal Tax { get; set; }
    public decimal ShippingCost { get; set; }
    public decimal Total { get; set; }
    public string? ShippingAddress { get; set; }
    public string? PaymentMethod { get; set; }
}

public class OrderItem
{
    public string ProductId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;
}
