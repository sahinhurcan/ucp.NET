namespace Application.UseCases.Checkout.Commands;

using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

public class AddItemToCartCommandHandler : IRequestHandler<AddItemToCartCommand, CartDto>
{
    private readonly IShoppingCartRepository _cartRepository;

    public AddItemToCartCommandHandler(IShoppingCartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<CartDto> Handle(AddItemToCartCommand request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetByIdAsync(request.CartId, cancellationToken);
        
        if (cart == null)
            throw new InvalidOperationException($"Cart with ID {request.CartId} not found");

        var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == request.ProductId);
        
        if (existingItem != null)
        {
            existingItem.Quantity += request.Quantity;
        }
        else
        {
            cart.Items.Add(new CartItem
            {
                ProductId = request.ProductId,
                Name = request.Name,
                Quantity = request.Quantity,
                UnitPrice = request.UnitPrice
            });
        }

        cart.Subtotal = cart.Items.Sum(i => i.TotalPrice);
        cart.Tax = cart.Subtotal * 0.1m; // 10% tax for example
        cart.Total = cart.Subtotal + cart.Tax;
        cart.UpdatedAt = DateTime.UtcNow;

        await _cartRepository.UpdateAsync(cart, cancellationToken);

        return new CartDto
        {
            Id = cart.Id,
            State = cart.State,
            Items = cart.Items.Select(i => new CartItemDto
            {
                ProductId = i.ProductId,
                Name = i.Name,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice,
                TotalPrice = i.TotalPrice
            }).ToList(),
            Subtotal = cart.Subtotal,
            Tax = cart.Tax,
            Total = cart.Total
        };
    }
}
