using MediatR;
using Resorter.Application.Dtos;
using Resorter.Application.Features.Cars.RequestHelpers;
using Resorter.Domain.Entities;
using Resorter.Domain.Repositories;

namespace Resorter.Application.Features.Cars.Queries.GetFilteredCars;

public class GetFilteredCarsQueryHandler
    (
        ICarRepository carRepository
    ) : IRequestHandler<GetFilteredCarsQuery, IEnumerable<GetCarDto>>
{
    public async Task<IEnumerable<GetCarDto>> Handle(GetFilteredCarsQuery request, CancellationToken cancellationToken)
    {
        var filteredCars = await carRepository.GetAllFilteredAsync(request);
        var bookRange = (request.EndDate.Date - request.StartDate.Date).Days;
        var result = filteredCars.GetAllCarMapper(bookRange, request.MinPrice, request.MaxPrice);

        return result;
    }
}
