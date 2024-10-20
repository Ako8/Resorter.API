using MediatR;
using Resorter.Application.Features.Cars.Dto;
using Resorter.Infrastructure.Repositories;

namespace Resorter.Application.Features.Cars.Queries.GetAllCars;

public class GetAllCarsQueryHandler
    (
        ICarRepository carRepository
    ) : IRequestHandler<GetAllCarsQuery, IEnumerable<CarDto>>
{
    public async Task<IEnumerable<CarDto>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
    {
        var cars = carRepository.GetAllMatchingAsync(request.searchPhrase);
        if (cars == null) throw new Exception("No car was found");

        var dtocars = await cars;
        return dtocars.CarsDtoMap();
    }
}
