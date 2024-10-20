using MediatR;
using Resorter.Application.Entities;
using Resorter.Application.Features.Cars.Dto;
using Resorter.Domain.Exceptions;
using Resorter.Infrastructure.Repositories;

namespace Resorter.Application.Features.Cars.Commands.CreateCar;

public class CreateCarCommandHandler
    (
        ICarRepository carRepository,
        IPriceConditionRepository priceConditionRepository
    ) : IRequestHandler<CreateCarCommand, int>
{
    public async Task<int> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {

        var carSeasonIds = request.PriceConditions.Select(pc => pc.SeasonId).Distinct().ToList();
        var carTariffIds = request.PriceConditions.Select(pc => pc.TariffId).Distinct().ToList();

        var seasons = await priceConditionRepository.GetSeasonsByIds(carSeasonIds);
        if (seasons.Keys.Count != carSeasonIds.Count)
        {
            throw new NotFoundException(nameof(Season), "that Id");
        }

        var tariffs = await priceConditionRepository.GetTariffsByIds(carTariffIds);
        if (tariffs.Keys.Count != carTariffIds.Count)
        {
            throw new NotFoundException(nameof(Tariff), "that Id");
        }


        var car = request.ToEntity();

        int id = await carRepository.Create(car);
        return id;
    }
}
