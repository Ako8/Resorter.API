using MediatR;
using Resorter.Application.Features.Cars.Dto;

namespace Resorter.Application.Features.Cars.Queries.GetAllCars;

public class GetAllCarsQuery : IRequest<IEnumerable<CarDto>>
{
    public string? searchPhrase { get; set; }
}
