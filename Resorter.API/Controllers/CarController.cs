using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resorter.Application.Features.Cars.Commands.CreateCar;
using Resorter.Application.Features.Cars.Commands.DeleteCar;
using Resorter.Application.Features.Cars.Commands.UpdateCar;
using Resorter.Application.Features.Cars.Queries.GetCarById;
using Resorter.Application.Features.Cars.Queries.GetFilteredCars;

namespace Resorter.API.Controllers;


[ApiController]
[Route("/api/cars")]
public class CarController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCarByIdAsync([FromRoute] int id)
    {
        var car = await mediator.Send(new GetCarByIdQuery(id));
        return Ok(car);
    }



    [HttpGet]
    public async Task<IActionResult> GetFilteredCars([FromQuery] GetFilteredCarsQuery filter)
    {
        var cars = await mediator.Send(filter);
        return Ok(cars);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCar(CreateCarCommand command)
    {
        await mediator.Send(command);
        return Created();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCar([FromRoute] int id)
    {
        await mediator.Send(new DeleteCarCommand(id));
        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateCar([FromRoute] int id)
    {
        await mediator.Send(new UpdateCarCommand(id));
        return NoContent();
    }
}
