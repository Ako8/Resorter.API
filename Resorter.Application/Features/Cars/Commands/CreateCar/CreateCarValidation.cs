using Resorter.Application.Dtos;
using Resorter.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Resorter.Application.Features.Cars.Commands.CreateCar;

public static class CreateCarValidation
{
    public static void ValidatePriceConditions(
        IEnumerable<PriceConditionDto> priceConditions,
        IReadOnlyList<Season> seasons,
        IReadOnlyList<Tariff> tariffs)
    {
        if (!seasons.Any() || !tariffs.Any())
            throw new ValidationException("Seasons or tariffs not found");

        var duplicates = priceConditions
            .GroupBy(pc => new { pc.SeasonId, pc.TariffId })
            .Where(g => g.Count() > 1);

        if (duplicates.Any())
            throw new ValidationException("Duplicate season-tariff combinations found");

        var expectedCombinations = seasons.Count * tariffs.Count;
        if (priceConditions.Count() != expectedCombinations)
            throw new ValidationException("Missing price conditions");
    }
}
