using MediatR;
using Resorter.Application.Entities;
using Resorter.Application.Features.Cars.Dto;

namespace Resorter.Application.Features.Cars.Commands.CreateCar;

public class CreateCarCommand : IRequest<int>
{
    public string RegistrationCertificate { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string LicensePlate { get; set; }
    public string YearOfManufacturer { get; set; }
    public string BodyColor { get; set; }
    public string BodyType { get; set; }
    public Insurance Insurance { get; set; }
    public Engine Engine { get; set; }
    public Specifications Specifications { get; set; }
    public Chassis Chassis { get; set; }
    public List<PriceConditionDto> PriceConditions { get; set; }
}
