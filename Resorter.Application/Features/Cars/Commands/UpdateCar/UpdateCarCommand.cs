using MediatR;
using Resorter.Application.Dtos;
using Resorter.Domain.Constants;
using Resorter.Domain.Entities;

namespace Resorter.Application.Features.Cars.Commands.UpdateCar;

public class UpdateCarCommand(int CarId) : IRequest
{
    public int CarId { get; set; } = CarId;
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
    public List<PriceConditionDto> PriceConditions { get; set; }
}
