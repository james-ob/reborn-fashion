using Mediator;
using Microsoft.AspNetCore.Mvc;
using Reborn.Fashion.Application.UseCases.Listings;

namespace Reborn.Fashion.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GetListingController(IMediator mediator) : ControllerBase
{
    [HttpGet("/listings/{listingId}")]
    public async Task<GetListingResponse> HandleAsync([FromRoute] Guid listingId)
    {
        var request = new GetListingRequest(listingId);
        var response = await mediator.Send(request);
        return response;
    }
}
