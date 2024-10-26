using Resorter.Domain.Entities;

namespace Resorter.Application.Features.Cars.Dto;

public static class RequestHelpers
{
    public static IEnumerable<GetCarDto> MapToGetAll(this IEnumerable<Car> cars, int bookRange)
    {
        if (cars is null)
        {
            throw new ArgumentNullException(nameof(cars));
        }

        return cars.Select(car => new GetCarDto
        {
            Id = car.Id,
            Brand = car.Brand,
            Model = car.Model,
            LicensePlate = car.LicensePlate,
            YearOfManufacture = car.YearOfManufacture,
            BodyColor = car.BodyColor,
            BodyType = car.BodyType,
            Engine = car.Engine,
            Specifications = car.Specifications,
            Insurance = car.Insurance,
            Chassis = car.Chassis,
            PriceADay = car.PriceConditions.First(con => con.CarId == car.Id).Price,
            TotalPrice = car.PriceConditions.First(con => con.CarId == car.Id).Price * bookRange,
        });
    }
}