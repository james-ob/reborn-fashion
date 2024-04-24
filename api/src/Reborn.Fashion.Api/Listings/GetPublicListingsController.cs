using Mediator;
using Microsoft.AspNetCore.Mvc;
using Reborn.Fashion.Application.UseCases.Listings;

namespace Reborn.Fashion.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GetPublicListingsController(IMediator mediator) : ControllerBase
{
    [HttpGet("/listings")]
    public async Task<GetPublicListingsResponse[]> HandleAsync()
    {
        var request = new GetPublicListingsRequest();
        var response = await mediator.Send(request);
        return response;
    }
}
