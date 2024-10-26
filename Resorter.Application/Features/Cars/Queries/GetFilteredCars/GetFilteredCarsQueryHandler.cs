using MediatR;
using Resorter.Application.Features.Cars.Dto;
using Resorter.Domain.Entities;
using Resorter.Domain.Repositories;

namespace Resorter.Application.Features.Cars.Queries.GetFilteredCars;

public class GetFilteredCarsQueryHandler
    (
        ICrudRepository<Car> carRepository
    ) : IRequestHandler<GetFilteredCarsQuery, IEnumerable<GetCarDto>>
{
    public async Task<IEnumerable<GetCarDto>> Handle(GetFilteredCarsQuery request, CancellationToken cancellationToken)
    {
        var filteredCars = await carRepository.GetAllFilteredAsync(request);
        var bookRange = request.EndDate - request.StartDate;
        var result = filteredCars.MapToGetAll(bookRange.Days);

        return result;
    }
}
