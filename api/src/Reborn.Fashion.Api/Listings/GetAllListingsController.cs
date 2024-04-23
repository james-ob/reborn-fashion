using Mediator;
using Microsoft.AspNetCore.Mvc;
using Reborn.Fashion.Application.UseCases.Listings;

namespace Reborn.Fashion.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GetAllListingsController(IMediator mediator) : ControllerBase
{
    [HttpGet("/listings")]
    public async Task<GetAllListingsResponse[]> HandleAsync()
    {
        var request = new GetAllListingsRequest();
        var response = await mediator.Send(request);
        return response;
    }
}
