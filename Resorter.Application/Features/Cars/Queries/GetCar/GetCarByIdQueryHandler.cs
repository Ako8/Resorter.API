using MediatR;
using Resorter.Application.Entities;
using Resorter.Application.Features.Cars.Dto;
using Resorter.Domain.Exceptions;
using Resorter.Infrastructure.Repositories;

namespace Resorter.Application.Features.Cars.Queries.GetCar;

public class GetCarByIdQueryHandler
    (
        ICarRepository carRepository
    ) : IRequestHandler<GetCarByIdQuery, CarDto>
{
    public async Task<CarDto> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
    {
        var car = await carRepository.GetById(request.CarId)
            ?? throw new NotFoundException(nameof(Car), request.CarId.ToString());


        return car.CarDtoMap();
    }
}
