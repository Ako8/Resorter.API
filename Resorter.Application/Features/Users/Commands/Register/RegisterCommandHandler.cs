using MediatR;
using Microsoft.AspNetCore.Identity;
using Resorter.Application.Entities;
using Resorter.Application.Features.Users.Dto;
using Resorter.Domain.Constants;

namespace Resorter.Application.Features.Users.Commands.Register;

public class RegisterCommandHandler
    (
        UserManager<User> userManager
    ) : IRequestHandler<RegisterCommand, RegisterDto>
{
    public async Task<RegisterDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = request.RegisterMap();
        var result = await userManager.CreateAsync( user, request.Password);

        if (!result.Succeeded)
        {
            return new RegisterDto
            {
                Succeeded = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        await userManager.AddToRoleAsync(user, UserRoles.User);

        return new RegisterDto
        {
            Succeeded = result.Succeeded,
            Errors = result.Errors.Select(e => e.Description)
        };
    }
}
