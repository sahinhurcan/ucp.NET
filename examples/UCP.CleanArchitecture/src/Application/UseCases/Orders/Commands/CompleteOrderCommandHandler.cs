namespace Application.UseCases.Orders.Commands;

using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using UCP.NET.Client;

public class CompleteOrderCommandHandler : IRequestHandler<CompleteOrderCommand, OrderDto>
{
    private readonly IShoppingCartRepository _cartRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IUcpShoppingClient _ucpClient;

    public CompleteOrderCommandHandler(
        IShoppingCartRepository cartRepository,
        IOrderRepository orderRepository,
        IUcpShoppingClient ucpClient)
    {
        _cartRepository = cartRepository;
        _orderRepository = orderRepository;
        _ucpClient = ucpClient;
    }

    public async Task<OrderDto> Handle(CompleteOrderCommand request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetByIdAsync(request.CartId, cancellationToken);
        
        if (cart == null)
            throw new InvalidOperationException($"Cart with ID {request.CartId} not found");

        if (string.IsNullOrEmpty(cart.UcpCheckoutId))
            throw new InvalidOperationException("Cart must be synced with UCP before completing order");

        // Complete checkout with UCP
        var ucpOrder = await _ucpClient.CompleteCheckoutAsync(cart.UcpCheckoutId, cancellationToken);

        // Create local order
        var order = new Order
        {
            UserId = cart.UserId,
            UcpOrderId = ucpOrder.Id,
            State = ucpOrder.State,
            Items = cart.Items.Select(i => new OrderItem
            {
                ProductId = i.ProductId,
                Name = i.Name,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice
            }).ToList(),
            Subtotal = cart.Subtotal,
            Tax = cart.Tax,
            Total = cart.Total
        };

        var created = await _orderRepository.CreateAsync(order, cancellationToken);

        // Delete cart
        await _cartRepository.DeleteAsync(cart.Id, cancellationToken);

        return new OrderDto
        {
            Id = created.Id,
            UcpOrderId = created.UcpOrderId,
            State = created.State,
            Items = created.Items.Select(i => new OrderItemDto
            {
                ProductId = i.ProductId,
                Name = i.Name,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice,
                TotalPrice = i.TotalPrice
            }).ToList(),
            Subtotal = created.Subtotal,
            Tax = created.Tax,
            ShippingCost = created.ShippingCost,
            Total = created.Total,
            CreatedAt = created.CreatedAt
        };
    }
}
