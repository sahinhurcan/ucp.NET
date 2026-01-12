namespace Application.UseCases.Checkout.Queries;

using Application.DTOs;
using Domain.Interfaces;
using MediatR;

public class GetCartQueryHandler : IRequestHandler<GetCartQuery, CartDto?>
{
    private readonly IShoppingCartRepository _cartRepository;

    public GetCartQueryHandler(IShoppingCartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<CartDto?> Handle(GetCartQuery request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetByIdAsync(request.CartId, cancellationToken);
        
        if (cart == null)
            return null;

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
