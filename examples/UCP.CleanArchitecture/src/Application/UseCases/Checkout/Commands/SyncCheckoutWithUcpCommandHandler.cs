namespace Application.UseCases.Checkout.Commands;

using Domain.Interfaces;
using MediatR;
using UCP.NET.Client;
using UCP.NET.Models;

public class SyncCheckoutWithUcpCommandHandler : IRequestHandler<SyncCheckoutWithUcpCommand, string>
{
    private readonly IShoppingCartRepository _cartRepository;
    private readonly IUcpShoppingClient _ucpClient;

    public SyncCheckoutWithUcpCommandHandler(
        IShoppingCartRepository cartRepository,
        IUcpShoppingClient ucpClient)
    {
        _cartRepository = cartRepository;
        _ucpClient = ucpClient;
    }

    public async Task<string> Handle(SyncCheckoutWithUcpCommand request, CancellationToken cancellationToken)
    {
        var cart = await _cartRepository.GetByIdAsync(request.CartId, cancellationToken);
        
        if (cart == null)
            throw new InvalidOperationException($"Cart with ID {request.CartId} not found");

        var ucpRequest = new CheckoutCreateRequest
        {
            Ucp = new UcpMetadata
            {
                Version = "2026-01-11",
                Capabilities = new List<Capability>
                {
                    new Capability { Name = "checkout" }
                }
            },
            LineItems = cart.Items.Select(item => new LineItem
            {
                Id = item.ProductId,
                Quantity = item.Quantity,
                Item = new ItemInfo
                {
                    Name = item.Name,
                    Description = $"Product {item.Name}",
                }
            }).ToList()
        };

        var response = await _ucpClient.CreateCheckoutAsync(ucpRequest, cancellationToken);

        cart.UcpCheckoutId = response.Id;
        cart.UpdatedAt = DateTime.UtcNow;
        
        await _cartRepository.UpdateAsync(cart, cancellationToken);

        return response.Id;
    }
}
