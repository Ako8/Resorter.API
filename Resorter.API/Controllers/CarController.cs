using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resorter.Application.Features.Cars.Queries.GetFilteredCars;

namespace Resorter.API.Controllers;


[ApiController]
[Route("/api/cars")]
public class CarController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetFilteredCars([FromQuery] GetFilteredCarsQuery filter)
    {
        var cars = await mediator.Send(filter);
        return Ok(cars);
    }
}
