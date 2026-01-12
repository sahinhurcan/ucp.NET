namespace Domain.Entities;

using Domain.Common;

public class ShoppingCart : BaseEntity
{
    public string? UserId { get; set; }
    public string? UcpCheckoutId { get; set; }
    public string State { get; set; } = "active";
    public List<CartItem> Items { get; set; } = new();
    public decimal Subtotal { get; set; }
    public decimal Tax { get; set; }
    public decimal Total { get; set; }
}

public class CartItem
{
    public string ProductId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;
}
