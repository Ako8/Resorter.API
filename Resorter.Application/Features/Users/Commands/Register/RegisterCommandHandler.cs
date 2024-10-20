using MediatR;
using Microsoft.AspNetCore.Identity;
using Resorter.Application.Entities;
using Resorter.Application.Features.Users.Dto;
using Resorter.Domain.Constants;
using Resorter.Infrastructure.Repositories;

namespace Resorter.Application.Features.Users.Commands.Register;

public class RegisterCommandHandler
    (
        UserManager<User> userManager,
        IPriceConditionRepository priceConditionRepository
    ) : IRequestHandler<RegisterCommand, RegisterDto>
{
    public async Task<RegisterDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = request.RegisterMap();
        var result = await userManager.CreateAsync( user, request.Password);

        var season = DefaultData.Season(user);
        priceConditionRepository.CreateSeasons(season);

        var tariff = DefaultData.Tariff(user);
        priceConditionRepository.CreateTariffs(tariff);

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
