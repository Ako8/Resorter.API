using MediatR;

namespace Resorter.Application.Features.Cars.Commands.DeleteCar;

public class DeleteCarCommand(int CarId) : IRequest
{
    public int CarId { get; set; } = CarId;
}
