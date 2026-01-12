namespace Application.UseCases.Orders.Commands;

using Application.DTOs;
using MediatR;

public record CompleteOrderCommand(string CartId) : IRequest<OrderDto>;
