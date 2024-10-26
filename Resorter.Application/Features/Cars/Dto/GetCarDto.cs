using Resorter.Domain.Constants;
using Resorter.Domain.Entities;

namespace Resorter.Application.Features.Cars.Dto;

public class GetCarDto
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
    public decimal PriceADay { get; set; }
    public decimal TotalPrice { get; set; }
    public string Discount { get; set; }
}
