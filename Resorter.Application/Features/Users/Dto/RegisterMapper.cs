using Resorter.Application.Entities;
using Resorter.Application.Features.Users.Commands.Register;

namespace Resorter.Application.Features.Users.Dto;

public static class RegisterMapper
{
    public static User RegisterMap(this RegisterCommand command)
    {
        return new User
        {
            Name = command.Name,
            UserName = command.Email,
            Email = command.Email,
            PhoneNumber = command.PhoneNumber,
        };
    }
}
