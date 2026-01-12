namespace Application.UseCases.Checkout.Commands;

using Application.DTOs;
using MediatR;

public record AddItemToCartCommand(
    string CartId,
    string ProductId,
    string Name,
    int Quantity,
    decimal UnitPrice
) : IRequest<CartDto>;
