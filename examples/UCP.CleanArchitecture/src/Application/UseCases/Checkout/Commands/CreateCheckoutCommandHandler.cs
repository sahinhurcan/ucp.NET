namespace Application.UseCases.Checkout.Commands;

using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

public class CreateCheckoutCommandHandler : IRequestHandler<CreateCheckoutCommand, CartDto>
{
    private readonly IShoppingCartRepository _cartRepository;

    public CreateCheckoutCommandHandler(IShoppingCartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public async Task<CartDto> Handle(CreateCheckoutCommand request, CancellationToken cancellationToken)
    {
        var cart = new ShoppingCart
        {
            UserId = request.UserId,
            State = "active"
        };

        var created = await _cartRepository.CreateAsync(cart, cancellationToken);

        return new CartDto
        {
            Id = created.Id,
            State = created.State,
            Items = new List<CartItemDto>(),
            Subtotal = 0,
            Tax = 0,
            Total = 0
        };
    }
}
