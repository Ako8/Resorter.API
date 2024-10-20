using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resorter.Application.Features.Settings.Commands.CreateSeasons;
using Resorter.Application.Features.Settings.Commands.CreateTariffs;
using Resorter.Application.Features.Settings.Queries.GetSeasonsAndTariffs;

namespace Resorter.API.Controllers;

[ApiController]
[Route("api/settings")]
public class SettingsController(IMediator mediator) : ControllerBase
{
    [HttpGet("priceCondition")]
    public async Task<IActionResult> GetSeasonsAndTariffs()
    {
        var seasonsAndTariffs = await mediator.Send(new GetSeasonsAndTariffsQuery());
        return Ok(seasonsAndTariffs);
    }

    [HttpPost("seasons")]
    public async Task<IActionResult> CreateSeasons([FromBody] CreateSeasonsCommand command)
    {
        await mediator.Send(command);
        return Created();
    }

    [HttpPost("tariffs")]
    public async Task<IActionResult> CreateTariffs([FromBody] CreateTariffsCommand command)
    {
        await mediator.Send(command);
        return Created();
    }
}
