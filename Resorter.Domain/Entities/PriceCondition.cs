namespace Resorter.Domain.Entities;

public class PriceCondition
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public Car Car { get; set; }
    public int SeasonId { get; set; }
    public Season Season { get; set; }
    public int TariffId { get; set; }
    public Tariff Tariff { get; set; }
    public decimal Price { get; set; }
}
