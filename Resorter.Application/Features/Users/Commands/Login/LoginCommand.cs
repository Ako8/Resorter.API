using MediatR;
using Resorter.Application.Dtos;

namespace Resorter.Application.Features.Users.Commands.Login;

public class LoginCommand : IRequest<LoginDto>
{
    public string Email { get; set; }
    public string Password { get; set; }
}
