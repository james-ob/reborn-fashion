using Mediator;
using Microsoft.AspNetCore.Mvc;
using Reborn.Fashion.Application.UseCases.Listings;

namespace Reborn.Fashion.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CreateListingController(IMediator mediator) : ControllerBase
{
    [HttpPost("/listings")]
    public async Task<Guid> HandleAsync([FromBody] CreateListingCommand request)
    {
        var response = await mediator.Send(request);
        return response;
    }
}
