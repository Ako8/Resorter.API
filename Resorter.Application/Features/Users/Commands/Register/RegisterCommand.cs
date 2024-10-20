using MediatR;
using Resorter.Application.Features.Users.Dto;
using System.ComponentModel.DataAnnotations;

namespace Resorter.Application.Features.Users.Commands.Register;

public class RegisterCommand : IRequest<RegisterDto>
{
    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Phone number is required.")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; }
}
