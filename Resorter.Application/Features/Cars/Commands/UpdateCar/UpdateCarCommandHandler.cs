using MediatR;
using Resorter.Application.Entities;
using Resorter.Application.Features.Cars.Dto;
using Resorter.Domain.Exceptions;
using Resorter.Infrastructure.Repositories;

namespace Resorter.Application.Features.Cars.Commands.UpdateCar;

public class UpdateCarCommandHandler
    (
        ICarRepository carRepository,
        IPriceConditionRepository priceConditionRepository
    ) : IRequestHandler<UpdateCarCommand>
{
    public async Task Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        var car = await carRepository.GetById(request.Id)
            ?? throw new NotFoundException(nameof(Car), request.Id.ToString());


        await UpdatePriceConditions(car, request.PriceConditions);
        request.UpdateMap(car);

        await carRepository.SaveChanges();
    }


    private async Task UpdatePriceConditions(Car car, IEnumerable<PriceConditionDto> updatedPriceConditions)
    {
        var currentPriceConditions = car.PriceConditions.ToDictionary(pc => (pc.TariffId, pc.SeasonId));
        var updatedKeys = new HashSet<(int TariffId, int SeasonId)>();

        var seasonIds = updatedPriceConditions.Select(pc => pc.SeasonId).Distinct().ToList();
        var tariffIds = updatedPriceConditions.Select(pc => pc.TariffId).Distinct().ToList();

        var seasons = await priceConditionRepository.GetSeasonsByIds(seasonIds);
        var tariffs = await priceConditionRepository.GetTariffsByIds(tariffIds);

        foreach (var updatedCondition in updatedPriceConditions)
        {
            if (!seasons.ContainsKey(updatedCondition.SeasonId))
                throw new NotFoundException(nameof(Season), updatedCondition.SeasonId.ToString());
            if (!tariffs.ContainsKey(updatedCondition.TariffId))
                throw new NotFoundException(nameof(Tariff), updatedCondition.TariffId.ToString());

            var key = (updatedCondition.TariffId, updatedCondition.SeasonId);
            updatedKeys.Add(key);

            if (currentPriceConditions.TryGetValue(key, out var existingCondition))
            {
                // Update existing price condition
                existingCondition.Price = updatedCondition.Price;
            }
            else
            {
                // Create new price condition
                var newPriceCondition = new PriceCondition
                {
                    CarId = car.Id,
                    TariffId = updatedCondition.TariffId,
                    SeasonId = updatedCondition.SeasonId,
                    Price = updatedCondition.Price
                };
                await priceConditionRepository.CreatePriceCondition(newPriceCondition);
            }
        }

        // Remove price conditions that are not in the updated list
        var conditionsToRemove = currentPriceConditions.Where(kvp => !updatedKeys.Contains(kvp.Key)).Select(kvp => kvp.Value);
        foreach (var conditionToRemove in conditionsToRemove)
        {
            await priceConditionRepository.DeletePriceCondition(conditionToRemove);
        }
    }
}
