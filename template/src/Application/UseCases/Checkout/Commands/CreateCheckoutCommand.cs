namespace Application.UseCases.Checkout.Commands;

using Application.DTOs;
using MediatR;

public record CreateCheckoutCommand(string? UserId) : IRequest<CartDto>;
