using Mediator;
using Microsoft.AspNetCore.Mvc;
using Reborn.Fashion.Application.UseCases.Listings;

namespace Reborn.Fashion.Api.Controllers;

public record PlaceBidRequestBody(Guid UserId, decimal Amount);

[ApiController]
public class PlaceBidController(IMediator mediator) : ControllerBase
{
    [HttpPost("/listings/{id}/place-bid")]
    public async Task HandleAsync([FromRoute] Guid id, [FromBody] PlaceBidRequestBody body)
    {
        var command = new PlaceBidCommand(body.UserId, id, body.Amount);
        await mediator.Send(command);
    }
}
