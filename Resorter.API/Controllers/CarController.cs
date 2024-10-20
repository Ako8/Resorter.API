using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resorter.Application.Features.Cars.Commands.CreateCar;
using Resorter.Application.Features.Cars.Commands.UpdateCar;
using Resorter.Application.Features.Cars.Queries.GetAllCars;
using Resorter.Application.Features.Cars.Queries.GetCar;

namespace Resorter.API.Controllers;

[ApiController]
[Route("api/cars")]
public class CarController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCar([FromQuery] GetAllCarsQuery query)
    {
        var cars = await mediator.Send(query);
        return Ok(cars);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCarById([FromRoute] int id)
    {
        var car = await mediator.Send(new GetCarByIdQuery(id));
        return Ok(car);
    }

    [HttpPost]
    public async Task<IActionResult> AddCar([FromBody] CreateCarCommand command)
    {
        int id = await mediator.Send(command);
        return Created();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateCar([FromRoute] int id, [FromBody] UpdateCarCommand command)
    {
        command.Id = id;
        await mediator.Send(command);
        return NoContent();
    }
}
