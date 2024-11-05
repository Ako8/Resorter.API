namespace Resorter.Application.Dtos;

public class PriceConditionDto
{
    public int SeasonId { get; set; }
    public int TariffId { get; set; }
    public decimal Price { get; set; }
}
