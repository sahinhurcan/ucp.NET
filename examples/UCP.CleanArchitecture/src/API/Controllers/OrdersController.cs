namespace API.Controllers;

using Application.DTOs;
using Application.UseCases.Orders.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("complete")]
    public async Task<ActionResult<OrderDto>> CompleteOrder([FromQuery] string cartId)
    {
        var command = new CompleteOrderCommand(cartId);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
