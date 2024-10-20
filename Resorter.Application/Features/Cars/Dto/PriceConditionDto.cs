using Resorter.Application.Entities;

namespace Resorter.Application.Features.Cars.Dto;

public class PriceConditionDto
{
    public int SeasonId { get; set; }
    public int TariffId { get; set; }
    public decimal Price { get; set; }
}