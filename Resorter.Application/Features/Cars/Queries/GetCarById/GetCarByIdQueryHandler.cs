using MediatR;
using Resorter.Application.Dtos;
using Resorter.Application.Features.Cars.RequestHelpers;
using Resorter.Domain.Entities;
using Resorter.Domain.Exceptions;
using Resorter.Domain.Repositories;

namespace Resorter.Application.Features.Cars.Queries.GetCarById;

public class GetCarByIdQueryHandler
    (
        ICarRepository carRepository
    ) : IRequestHandler<GetCarByIdQuery, UpdateCarDto>
{
    public async Task<UpdateCarDto> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
    {
        var car = await carRepository.GetByIdAsync(request.CarId)
            ?? throw new NotFoundException(nameof(Car), request.CarId.ToString());


        var carDto = car.GetForUpdateCarMapper();

        return carDto;
    }
}
