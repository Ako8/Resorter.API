using Resorter.Application.Dtos;
using Resorter.Application.Entities;
using Resorter.Application.Features.Cars.Commands.CreateCar;
using Resorter.Application.Features.Cars.Commands.UpdateCar;
using Resorter.Application.Features.Cars.Queries.GetCarById;
using Resorter.Domain.Entities;

namespace Resorter.Application.Features.Cars.RequestHelpers;

public static class CarMappers
{
    public static IEnumerable<GetCarDto> GetAllCarMapper(this IEnumerable<Car> cars, int bookRange, int minPrice, int maxPrice)
    {
        if (cars is null)
        {
            throw new ArgumentNullException(nameof(cars));
        }

        var result =  cars.Select(car => new GetCarDto
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
            PriceADay = car.PriceConditions.Where(con => con.Season.StartDate <= DateTime.UtcNow && con.Season.EndDate >= DateTime.UtcNow).FirstOrDefault()!.Price,
            TotalPrice = car.PriceConditions.Where(con => con.Season.StartDate <= DateTime.UtcNow && con.Season.EndDate >= DateTime.UtcNow).FirstOrDefault()!.Price * bookRange,
        });

        return result.Where(c => c.PriceADay >= minPrice && c.PriceADay <= maxPrice);
    }

    public static Car CreateCarMapper(this CreateCarCommand command)
    {
        return new Car
        {
            RegistrationCertificate = command.RegistrationCertificate,
            Brand = command.Brand,
            Model = command.Model,
            LicensePlate = command.LicensePlate,
            YearOfManufacture = command.YearOfManufacture,
            BodyColor = command.BodyColor,
            BodyType = command.BodyType,
            Engine = command.Engine,
            Specifications = command.Specifications,
            Insurance = command.Insurance,
            Chassis = command.Chassis,
            UserCars = []
        };
    }


    public static IEnumerable<PriceCondition> CreatePriceConditionDtoMapper(this CreateCarCommand command, Car car)
    {
        return command.PriceConditions.Select(con => new PriceCondition()
        { 
            Car = car,
            SeasonId = con.SeasonId,
            TariffId = con.TariffId,
            Price = con.Price
        });
    }

    public static UpdateCarDto GetForUpdateCarMapper(this Car car)
    {
        return new UpdateCarDto
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
            //Seasons = user.UserSeasons
            //    .Select(us => us.Season)
            //    .Select(s => new SeasonDto
            //    {
            //        Id = s.Id,
            //        StartDate = s.StartDate,
            //        EndDate = s.EndDate
            //    }).ToList(),
            //Tariffs = user.UserTariffs
            //    .Select(ut => ut.Tariff)
            //    .Select(t => new TariffDto
            //    {
            //        Id = t.Id,
            //        MinDays = t.MinDays,
            //        MaxDays = t.MaxDays
            //    }).ToList(),
            PriceConditions = car.PriceConditions.Select(con => new PriceConditionDto
            {
                SeasonId = con.SeasonId,
                TariffId = con.TariffId,
                Price = con.Price
            })
        };
    }


    public static void UpdateCarMapper(this UpdateCarCommand command, Car car)
    {
        car.YearOfManufacture = command.YearOfManufacture;
        car.BodyColor = command.BodyColor; 
        car.BodyType = command.BodyType;
        car.Engine = command.Engine;
        car.Specifications = command.Specifications;
        car.Chassis = command.Chassis;
        car.Insurance = command.Insurance;
        car.LicensePlate = command.LicensePlate;
        car.Brand = command.Brand;
        car.Model = command.Model;
    }
}