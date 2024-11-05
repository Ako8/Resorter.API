using MediatR;
using Resorter.Application.Features.Cars.RequestHelpers;
using Resorter.Domain.Entities;
using Resorter.Domain.Repositories;
using Resorter.Domain.Junctions;

namespace Resorter.Application.Features.Cars.Commands.CreateCar;

public class CreateCarCommandHandler
    (
        ICarRepository carRepository,
        IPriceConditionRepository priceCondRepository,
        ISeasonRepository seasonRepository,
        ITariffRepository tariffRepository
    ) : IRequestHandler<CreateCarCommand>
{
    public async Task Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var seasonIds = request.PriceConditions.Select(pc => pc.SeasonId).Distinct().ToList();
        var tariffIds = request.PriceConditions.Select(pc => pc.TariffId).Distinct().ToList();

        var seasons = await seasonRepository.GetByIdsAndUserAsync(seasonIds, request.UserId);
        var tariffs = await tariffRepository.GetByIdsAndUserAsync(tariffIds, request.UserId);

        CreateCarValidation.ValidatePriceConditions(request.PriceConditions, seasons, tariffs);

        var car = request.CreateCarMapper();
        await carRepository.AddAsync(car);

        var priceConditions = request.PriceConditions
            .Select(pc => new PriceCondition
            {
                Car = car,
                SeasonId = pc.SeasonId,
                TariffId = pc.TariffId,
                Price = pc.Price
            });

        await priceCondRepository.AddRangeAsync(priceConditions);


        car.UserCars.Add(new UserCar { Car = car, UserId = request.UserId });
        await carRepository.SaveChanges();
    }
}
