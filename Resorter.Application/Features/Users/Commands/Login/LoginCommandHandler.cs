
using MediatR;
using Microsoft.AspNetCore.Identity;
using Resorter.Application.Entities;
using Resorter.Application.Features.Users.Dto;
using Resorter.Domain.Services;
using Resorter.Domain.Exceptions;

namespace Resorter.Application.Features.Users.Commands.Login;

public class LoginCommandHandler
    (
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IJwtTokenService jwtTokenService
    ) : IRequestHandler<LoginCommand, LoginDto>
{
    public async Task<LoginDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByNameAsync(request.Email);
        
        if (user == null)
            throw new NotFoundException(nameof(User), request.Email.ToString());

        var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);
        if (!result.Succeeded)
            throw new Exception("Invalid email or password.");

        var userRoles = await userManager.GetRolesAsync(user);
        var token = jwtTokenService.GenerateJwtToken(user, userRoles);

        return new LoginDto
        {
            Succeeded = true,
            Token = token,
        };
    }
}
