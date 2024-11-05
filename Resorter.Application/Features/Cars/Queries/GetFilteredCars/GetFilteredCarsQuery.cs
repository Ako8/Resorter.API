using MediatR;
using Resorter.Application.Dtos;
using Resorter.Domain.Constants;

namespace Resorter.Application.Features.Cars.Queries.GetFilteredCars;

public class GetFilteredCarsQuery : IRequest<IEnumerable<GetCarDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; }
    public DateTime StartDate { get; set; } = DateTime.UtcNow.AddDays(2);
    public DateTime EndDate { get; set; } = DateTime.UtcNow.AddDays(16);
    public string PickUp { get; set; } = "Tbilisi";
    public string DropOff { get; set; } = "Tbilisi";
    public int MinPrice { get; set; }
    public int MaxPrice { get; set; } = 999999;
    public List<BodyTypeEnum> BodyTypes { get; set; } = [];
    public List<FuelTypeEnum> FuelTypes { get; set; } = [];
    public List<TransmissionEnum> Transmissions { get; set; } = [];
    public List<DriveTypeEnum> DriveTypes { get; set; } = [];
    public decimal? FuelConsumptionMin { get; set; } 
    public decimal? FuelConsumptionMax { get; set; } 
    public int Year { get; set; }
}
