using MediatR;
using Resorter.Application.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Resorter.Application.Features.Users.Commands.Register;

public class RegisterCommand : IRequest<RegisterDto>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}
