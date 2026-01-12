namespace Application.UseCases.Checkout.Commands;

using MediatR;

public record SyncCheckoutWithUcpCommand(string CartId) : IRequest<string>;
