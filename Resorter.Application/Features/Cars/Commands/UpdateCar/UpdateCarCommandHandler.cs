using MediatR;
using Resorter.Application.Features.Cars.RequestHelpers;
using Resorter.Domain.Entities;
using Resorter.Domain.Exceptions;
using Resorter.Domain.Repositories;

namespace Resorter.Application.Features.Cars.Commands.UpdateCar;

public class UpdateCarCommandHandler
    (
        ICarRepository carRepository
    ) : IRequestHandler<UpdateCarCommand>
{
    public async Task Handle(UpdateCarCommand request, CancellationToken cancellationToken)
    {
        var car = await carRepository.GetByIdAsync(request.CarId)
            ?? throw new NotFoundException(nameof(Car), request.CarId.ToString());

        request.UpdateCarMapper(car);
        await carRepository.SaveChanges();
    }
}

