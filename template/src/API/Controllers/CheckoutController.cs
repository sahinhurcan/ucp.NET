namespace API.Controllers;

using Application.DTOs;
using Application.UseCases.Checkout.Commands;
using Application.UseCases.Checkout.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CheckoutController : ControllerBase
{
    private readonly IMediator _mediator;

    public CheckoutController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CartDto>> CreateCheckout([FromQuery] string? userId)
    {
        var command = new CreateCheckoutCommand(userId);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("{cartId}")]
    public async Task<ActionResult<CartDto>> GetCart(string cartId)
    {
        var query = new GetCartQuery(cartId);
        var result = await _mediator.Send(query);
        
        if (result == null)
            return NotFound();
            
        return Ok(result);
    }

    [HttpPost("{cartId}/items")]
    public async Task<ActionResult<CartDto>> AddItemToCart(
        string cartId,
        [FromBody] AddItemToCartDto dto)
    {
        var command = new AddItemToCartCommand(
            cartId,
            dto.ProductId,
            dto.Name,
            dto.Quantity,
            dto.UnitPrice
        );
        
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
