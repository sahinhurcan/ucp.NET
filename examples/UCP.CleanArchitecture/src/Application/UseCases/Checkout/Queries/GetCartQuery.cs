namespace Application.UseCases.Checkout.Queries;

using Application.DTOs;
using MediatR;

public record GetCartQuery(string CartId) : IRequest<CartDto?>;
