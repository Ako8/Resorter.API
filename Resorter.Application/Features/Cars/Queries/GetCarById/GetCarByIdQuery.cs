using MediatR;
using Resorter.Application.Dtos;

namespace Resorter.Application.Features.Cars.Queries.GetCarById;

public class GetCarByIdQuery(int CarId) : IRequest<UpdateCarDto>
{
    public int CarId { get; set; } = CarId;
}
