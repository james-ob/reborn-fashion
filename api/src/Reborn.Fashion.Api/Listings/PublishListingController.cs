using Mediator;
using Microsoft.AspNetCore.Mvc;
using Reborn.Fashion.Application.UseCases.Listings;

namespace Reborn.Fashion.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PublishListingController(IMediator mediator) : ControllerBase
{
    [HttpPost("/listings/{listingId}/publish")]
    public async Task HandleAsync([FromRoute] Guid listingId)
    {
        var request = new PublishListingCommand(listingId);
        await mediator.Send(request);
    }
}
