using Resorter.Application.Entities;

namespace Resorter.Application.Features.Cars.Dto;

public class CarDto
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string LicensePlate { get; set; }
    public string YearOfManufacturer { get; set; }
    public string BodyColor { get; set; }
    public string BodyType { get; set; }
    public string UserId { get; set; }
    public Insurance Insurance { get; set; }
    public Engine Engine { get; set; }
    public Specifications Specifications { get; set; }
    public Chassis Chassis { get; set; }
    public string Discount { get; set; }
    public decimal Price { get; set; }
}
