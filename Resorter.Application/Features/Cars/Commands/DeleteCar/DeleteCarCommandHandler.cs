using MediatR;
using Resorter.Domain.Entities;
using Resorter.Domain.Exceptions;
using Resorter.Domain.Repositories;

namespace Resorter.Application.Features.Cars.Commands.DeleteCar;

public class DeleteCarCommandHandler
    (
        ICarRepository carRepository
    ) : IRequestHandler<DeleteCarCommand>
{
    public async Task Handle(DeleteCarCommand request, CancellationToken cancellationToken)
    {
        var car = await carRepository.GetByIdAsync( request.CarId )
            ?? throw new NotFoundException(nameof(Car), request.CarId.ToString());

        await carRepository.DeleteAsync(car);
        await carRepository.SaveChanges();
    }
}
