using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resorter.Application.Features.Users.Commands.Login;
using Resorter.Application.Features.Users.Commands.Register;

namespace Resorter.API.Controllers;

[ApiController]
[Route("/api/identity")]
public class IdentityController(IMediator mediator) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterCommand command)
    {

        var result = await mediator.Send(command);
        if (result.Succeeded) 
            return Ok( new { Message = "User registered successfully" });
        return BadRequest( new { Errors = result.Errors });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var result = await mediator.Send(command);
        if (result.Succeeded)
            return Ok(new { Token = result.Token, Message = "Login successfull" });
        return BadRequest(new { Message = "Invalid email or password" });
    }
}
 