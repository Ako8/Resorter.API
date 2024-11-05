using Resorter.Domain.Constants;
using Resorter.Domain.Entities;

namespace Resorter.Application.Dtos;

public class UpdateCarDto
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string LicensePlate { get; set; }
    public int YearOfManufacture { get; set; }
    public BodyColorEnum BodyColor { get; set; }
    public BodyTypeEnum BodyType { get; set; }
    public Engine Engine { get; set; }
    public Specifications Specifications { get; set; }
    public Chassis Chassis { get; set; }
    public Insurance Insurance { get; set; }
    public IEnumerable<TariffDto> Tariffs { get; set; }
    public IEnumerable<SeasonDto> Seasons { get; set; }
    public IEnumerable<PriceConditionDto> PriceConditions { get; set; }
}
