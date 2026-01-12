namespace Application.DTOs;

public class OrderDto
{
    public string Id { get; set; } = string.Empty;
    public string UcpOrderId { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public List<OrderItemDto> Items { get; set; } = new();
    public decimal Subtotal { get; set; }
    public decimal Tax { get; set; }
    public decimal ShippingCost { get; set; }
    public decimal Total { get; set; }
    public string? ShippingAddress { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class OrderItemDto
{
    public string ProductId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
}
