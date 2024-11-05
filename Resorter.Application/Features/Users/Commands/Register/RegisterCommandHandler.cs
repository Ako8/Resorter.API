using MediatR;
using Microsoft.AspNetCore.Identity;
using Resorter.Application.Dtos;
using Resorter.Application.Entities;
using Resorter.Application.Features.Users.Dto;
using Resorter.Domain.Constants;
using Resorter.Domain.Entities;
using Resorter.Domain.Repositories;
using Resorter.Domain.Junctions;

namespace Resorter.Application.Features.Users.Commands.Register;

public class RegisterCommandHandler
    (
        UserManager<User> userManager,
        ISeasonRepository seasonRepository,
        ITariffRepository tariffRepository
    ) : IRequestHandler<RegisterCommand, RegisterDto>
{
    public async Task<RegisterDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await userManager.FindByEmailAsync(request.Email);
        if (existingUser != null)
        {   
            return new RegisterDto
            {
                Succeeded = false,
                Errors = new[] { "User with this email already exists." }
            };
        }
        var seasons = await seasonRepository.AddRangeAsync(DefaultData.Season());
        var tariffs = await tariffRepository.AddRangeAsync(DefaultData.Tariff());

        
        var user = request.RegisterMap(seasons, tariffs);

        user.NormalizedEmail = userManager.NormalizeEmail(request.Email);
        user.NormalizedUserName = userManager.NormalizeName(request.Email);


        var result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            return new RegisterDto
            {
                Succeeded = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        await userManager.AddToRoleAsync(user, UserRoles.User);

        

        await tariffRepository.SaveChanges();


        return new RegisterDto
        {
            Succeeded = result.Succeeded,
            Errors = result.Errors.Select(e => e.Description)
        };
    }
}
