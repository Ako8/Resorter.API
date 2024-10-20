using MediatR;
using Resorter.Application.Features.Cars.Dto;

namespace Resorter.Application.Features.Cars.Queries.GetCar;

public class GetCarByIdQuery(int CarId) : IRequest<CarDto>
{
    public int CarId { get; set; } = CarId;
}
