using Mediator;
using Microsoft.AspNetCore.Mvc;
using Reborn.Fashion.Application.UseCases.Listings;

namespace Reborn.Fashion.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SeedDataController(IMediator mediator) : ControllerBase
{
    [HttpPost("/seed")]
    public async Task HandleAsync()
    {
        var command = new SeedDataCommand();
        await mediator.Send(command);
    }
}
