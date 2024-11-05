using Resorter.Application.Entities;
using Resorter.Application.Features.Users.Commands.Register;
using Resorter.Domain.Entities;
using Resorter.Domain.Junctions;

namespace Resorter.Application.Features.Users.Dto;

public static class RegisterMapper
{
    public static User RegisterMap(this RegisterCommand command, IEnumerable<Season> seasons, IEnumerable<Tariff> tariffs )
    {
        return new User
        {
            Name = command.Name,
            UserName = command.Email,
            Email = command.Email,
            PhoneNumber = command.PhoneNumber,
            UserSeasons = [new UserSeason() { Season = seasons.First(), SeasonId = seasons.First().Id }],
            UserTariffs = [new UserTariff() { Tariff = tariffs.First(), TariffId = tariffs.First().Id}],
            UserAddresses = [],
            UserCars = [],
        };
    }
}
